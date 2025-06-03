// ����������� ������������ ������������ ��� System,
// ����������� ������� ������ � ���� .NET
using System;

// ����������� ������������ ��� System.Collections.Generic,
// ������������ ��� ������ � ����������� ����������� (��������, List<T>, IEnumerable<T>)
using System.Collections.Generic;

// ����������� ������������ ��� System.IO,
// ������������ ��� ������ � ������� (������ � ������)
using System.IO;

// ����������� ������������ ��� System.Text.Json,
// ������������� ��� ������������ � �������������� JSON-������
using System.Text.Json;

namespace TankApp.Services
{
    /// <summary>
    /// ���������� ����������� ����� JsonService<T> ������������� ������������� ������
    /// ��� �������� � ���������� ������ � ������� JSON.
    /// </summary>
    /// <typeparam name="T">��� ��������, ������� ����� ��������������� ��� �����������������</typeparam>
    public static class JsonService<T>
    {
        /// <summary>
        /// ����� Load ��������� ������ �� JSON-����� �� ���������� ����.
        /// ���� ���� �� ����������, ������������ ������ ������.
        /// </summary>
        /// <param name="path">���� � JSON-�����</param>
        /// <returns>������ �������� ���� T, ����������� �� �����</returns>
        public static List<T> Load(string path)
        {
            // ���������, ���������� �� ���� �� ���������� ����
            if (!File.Exists(path))
                return new List<T>(); // ���� ����� ��� � ���������� ������ ������

            // ������ ���������� �����
            var json = File.ReadAllText(path);

            // ������������� JSON � ������ �������� ���� T � ���������� ���
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        /// <summary>
        /// ����� Save ��������� ��������� ������ � JSON-���� �� ���������� ����.
        /// ������ ������������ � ������������� ������� (� ���������).
        /// </summary>
        /// <param name="path">���� � �����, � ������� ����� ��������� ������</param>
        /// <param name="data">��������� ������ ��� ����������</param>
        public static void Save(string path, IEnumerable<T> data)
        {
            // ��������� ������������: ������ ����� �������� � �������������
            var options = new JsonSerializerOptions { WriteIndented = true };

            // ����������� ��������� � JSON-������
            var json = JsonSerializer.Serialize(data, options);

            // ���������� JSON-������ � ����
            File.WriteAllText(path, json);
        }
    }
}