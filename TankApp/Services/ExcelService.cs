// ����������� ������������ ������������ ��� System.Collections.Generic
// ��� ������������� ���������� ���������, ����� ��� IEnumerable<T> � List<T>
using System.Collections.Generic;

// ����������� ����������������� ������������ ��� TankApp.Models,
// � ������� �������� ����� Tank � ������ ������ ���������� �������
using TankApp.Models;

// ������ ������������ ��� Microsoft.Office.Interop.Excel ��� ����������� Excel.
// ��� ��������� �������� � Excel ����� COM-��������� (������� �������������� Microsoft Office)
using Excel = Microsoft.Office.Interop.Excel;

namespace TankApp.Services
{
    /// <summary>
    /// ����������� ����� ExcelService ������������� ������ ��� ������ � ������ ������ � ����������� �/�� Excel-������.
    /// </summary>
    public static class ExcelService
    {
        /// <summary>
        /// ����� ���������� ��������� ����������� � Excel-���� �� ���������� ����.
        /// </summary>
        /// <param name="filePath">���� � �����, ���� ����� ��������� ������</param>
        /// <param name="tanks">��������� ����������� ��� ������</param>
        public static void WriteTanksToExcel(string filePath, IEnumerable<Tank> tanks)
        {
            // ������� ��������� ���������� Excel
            var app = new Excel.Application();
            app.Visible = false; // ������ ���������� ��������� ��� ������������

            // ������ ����� ������� ����� � �������� ������ ����
            var workbook = app.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];

            // ���������� ��������� ��������
            worksheet.Cells[1, 1] = "Name";
            worksheet.Cells[1, 2] = "Capacity";
            worksheet.Cells[1, 3] = "UnitName";

            // �������� ������ ������ �� ������ ������ (������ � ���������)
            int row = 2;
            foreach (var tank in tanks)
            {
                worksheet.Cells[row, 1] = tank.Name;
                worksheet.Cells[row, 2] = tank.Capacity;
                worksheet.Cells[row, 3] = tank.UnitName;
                row++;
            }

            // ��������� ����� �� ���������� ����
            workbook.SaveAs(filePath);

            // ��������� ����� � ��������� ������ � Excel
            workbook.Close();
            app.Quit();
        }

        /// <summary>
        /// ����� ������ ������ �� Excel-����� � ���������� ������ �����������.
        /// </summary>
        /// <param name="filePath">���� � Excel-�����, �� �������� ����� ������� ������</param>
        /// <returns>������ �������� ���� Tank</returns>
        public static List<Tank> ReadTanksFromExcel(string filePath)
        {
            // ������� ��������� ���������� Excel
            var app = new Excel.Application();

            // ��������� ������� ����� �� ���������� ����
            var workbook = app.Workbooks.Open(filePath);

            // �������� ������ ���� � �������� �������������� �����
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];
            var range = worksheet.UsedRange;

            // ������ ������ ��� �������� �����������
            var tanks = new List<Tank>();

            // ������ ������ ������� �� ������ ������ (������ � ���������)
            for (int i = 2; i <= range.Rows.Count; i++)
            {
                tanks.Add(new Tank
                {
                    Name = ((Excel.Range)range.Cells[i, 1]).Text.ToString(),
                    Capacity = int.Parse(((Excel.Range)range.Cells[i, 2]).Text.ToString()),
                    UnitName = ((Excel.Range)range.Cells[i, 3]).Text.ToString()
                });
            }

            // ��������� ����� � ��������� ������ � Excel
            workbook.Close();
            app.Quit();

            return tanks;
        }
    }
}