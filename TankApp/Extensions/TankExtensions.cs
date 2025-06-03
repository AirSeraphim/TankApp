// ����������� ������������ ������������ ��� System, 
// ����������� ������� ������ � ������ .NET
using System;

// ����������� ������������ ��� System.Collections.Generic,
// ������������ ��� ������ � ����������� ����������� (��������, List<T>, IEnumerable<T>)
using System.Collections.Generic;

// ����������� ����������������� ������������ ��� TankApp.Models,
// ���, ������ �����, ���������� ������ Tank � Unit
using TankApp.Models;

// ����������� ������������ ������������ ��� TankApp.Extensions,
// � ������� ����� ���������� ������ ���������� ��� �������, ��������� � ������������
namespace TankApp.Extensions
{
    /// <summary>
    /// ����������� �����, ���������� ������ ���������� ��� ��������� �������� ���� Tank.
    /// </summary>
    public static class TankExtensions
    {
        /// <summary>
        /// ����� ����������, ������� ���� ������ ���������� ��������� (Unit) �� �������� ���������,
        /// ��������������� �� ����� ������ �� ������ ����������� (Tank).
        /// </summary>
        /// <param name="tanks">������ �����������, ��� ������� ����� ����� ���������</param>
        /// <param name="units">��������� ��������� ��������� (������ ��� ������)</param>
        /// <returns>��������� ��������� (������ Unit)</returns>
        /// <exception cref="InvalidOperationException">
        /// �������������, ���� �� ���� ��������� �� �������
        /// </exception>
        public static Unit FindUnit(this List<Tank> tanks, IReadOnlyCollection<Unit> units)
        {
            // ���������� ��� ���������� �� ������
            foreach (var tank in tanks)
            {
                // ���� ��������� � ����������� ������
                var unit = units.FirstOrDefault(u => u.Name == tank.UnitName);

                // ���� ��������� ������� � ���������� �
                if (unit != null)
                    return unit;
            }

            // ���� �� ���� ��������� �� ���� ������� � ����������� ����������
            throw new InvalidOperationException("�� ������� ��������� ��� ����������!");
        }

        /// <summary>
        /// ����� ����������, ����������� ����� ������� ���� ����������� � ������.
        /// </summary>
        /// <param name="tanks">������ �����������</param>
        /// <returns>����� ����� (����� �������� �������� Capacity)</returns>
        public static int GetTotalVolume(this List<Tank> tanks)
        {
            // ���������� ����� �������� ���� ����������� � ������
            return tanks.Sum(t => t.Capacity);
        }
    }
}