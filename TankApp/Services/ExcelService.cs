// Подключение стандартного пространства имён System.Collections.Generic
// для использования обобщённых коллекций, таких как IEnumerable<T> и List<T>
using System.Collections.Generic;

// Подключение пользовательского пространства имён TankApp.Models,
// в котором определён класс Tank и другие модели предметной области
using TankApp.Models;

// Импорт пространства имён Microsoft.Office.Interop.Excel под псевдонимом Excel.
// Это позволяет работать с Excel через COM-интерфейс (требует установленного Microsoft Office)
using Excel = Microsoft.Office.Interop.Excel;

namespace TankApp.Services
{
    /// <summary>
    /// Статический класс ExcelService предоставляет методы для чтения и записи данных о резервуарах в/из Excel-файлов.
    /// </summary>
    public static class ExcelService
    {
        /// <summary>
        /// Метод записывает коллекцию резервуаров в Excel-файл по указанному пути.
        /// </summary>
        /// <param name="filePath">Путь к файлу, куда будут сохранены данные</param>
        /// <param name="tanks">Коллекция резервуаров для записи</param>
        public static void WriteTanksToExcel(string filePath, IEnumerable<Tank> tanks)
        {
            // Создаем экземпляр приложения Excel
            var app = new Excel.Application();
            app.Visible = false; // Делаем приложение невидимым для пользователя

            // Создаём новую рабочую книгу и получаем первый лист
            var workbook = app.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];

            // Записываем заголовки столбцов
            worksheet.Cells[1, 1] = "Name";
            worksheet.Cells[1, 2] = "Capacity";
            worksheet.Cells[1, 3] = "UnitName";

            // Начинаем запись данных со второй строки (первая — заголовок)
            int row = 2;
            foreach (var tank in tanks)
            {
                worksheet.Cells[row, 1] = tank.Name;
                worksheet.Cells[row, 2] = tank.Capacity;
                worksheet.Cells[row, 3] = tank.UnitName;
                row++;
            }

            // Сохраняем книгу по указанному пути
            workbook.SaveAs(filePath);

            // Закрываем книгу и завершаем работу с Excel
            workbook.Close();
            app.Quit();
        }

        /// <summary>
        /// Метод читает данные из Excel-файла и возвращает список резервуаров.
        /// </summary>
        /// <param name="filePath">Путь к Excel-файлу, из которого будут считаны данные</param>
        /// <returns>Список объектов типа Tank</returns>
        public static List<Tank> ReadTanksFromExcel(string filePath)
        {
            // Создаем экземпляр приложения Excel
            var app = new Excel.Application();

            // Открываем рабочую книгу по указанному пути
            var workbook = app.Workbooks.Open(filePath);

            // Получаем первый лист и диапазон использованных ячеек
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];
            var range = worksheet.UsedRange;

            // Создаём список для хранения резервуаров
            var tanks = new List<Tank>();

            // Читаем данные начиная со второй строки (первая — заголовок)
            for (int i = 2; i <= range.Rows.Count; i++)
            {
                tanks.Add(new Tank
                {
                    Name = ((Excel.Range)range.Cells[i, 1]).Text.ToString(),
                    Capacity = int.Parse(((Excel.Range)range.Cells[i, 2]).Text.ToString()),
                    UnitName = ((Excel.Range)range.Cells[i, 3]).Text.ToString()
                });
            }

            // Закрываем книгу и завершаем работу с Excel
            workbook.Close();
            app.Quit();

            return tanks;
        }
    }
}