// Подключение стандартного пространства имён System,
// содержащего базовые классы и типы .NET
using System;

// Подключение пространства имён System.Collections.Generic,
// необходимого для работы с обобщёнными коллекциями (например, List<T>, IEnumerable<T>)
using System.Collections.Generic;

// Подключение пространства имён System.IO,
// необходимого для работы с файлами (чтение и запись)
using System.IO;

// Подключение пространства имён System.Text.Json,
// используемого для сериализации и десериализации JSON-данных
using System.Text.Json;

namespace TankApp.Services
{
    /// <summary>
    /// Обобщённый статический класс JsonService<T> предоставляет универсальные методы
    /// для загрузки и сохранения данных в формате JSON.
    /// </summary>
    /// <typeparam name="T">Тип объектов, которые будут сериализоваться или десериализоваться</typeparam>
    public static class JsonService<T>
    {
        /// <summary>
        /// Метод Load загружает данные из JSON-файла по указанному пути.
        /// Если файл не существует, возвращается пустой список.
        /// </summary>
        /// <param name="path">Путь к JSON-файлу</param>
        /// <returns>Список объектов типа T, загруженных из файла</returns>
        public static List<T> Load(string path)
        {
            // Проверяем, существует ли файл по указанному пути
            if (!File.Exists(path))
                return new List<T>(); // Если файла нет — возвращаем пустой список

            // Читаем содержимое файла
            var json = File.ReadAllText(path);

            // Десериализуем JSON в список объектов типа T и возвращаем его
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        /// <summary>
        /// Метод Save сохраняет коллекцию данных в JSON-файл по указанному пути.
        /// Данные записываются в удобочитаемом формате (с отступами).
        /// </summary>
        /// <param name="path">Путь к файлу, в который будут сохранены данные</param>
        /// <param name="data">Коллекция данных для сохранения</param>
        public static void Save(string path, IEnumerable<T> data)
        {
            // Настройки сериализации: делаем вывод красивым и удобочитаемым
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Сериализуем коллекцию в JSON-строку
            var json = JsonSerializer.Serialize(data, options);

            // Записываем JSON-строку в файл
            File.WriteAllText(path, json);
        }
    }
}