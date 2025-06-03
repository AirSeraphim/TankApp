// ����������� ������������ ������������ ��� System.Collections.Generic
// ��� ������ � ����������� ����������� (��������, List<T>)
using System.Collections.Generic;

// ����������� ����������������� ������������ ��� TankApp.Models,
// � ������� ���������� ������ �������: Tank, Unit, Factory, Deal � ��.
using TankApp.Models;

// ����������� ����������������� ������������ ��� TankApp.Services,
// ��� ��������� ��������� ������ ����������, ������� JsonService � DataLoader
using TankApp.Services;

namespace TankApp.Services
{
    /// <summary>
    /// ����������� ����� DataLoader ������������� ������ ��� �������� ������ � ��������� ��������� �� JSON-������.
    /// </summary>
    public static class DataLoader
    {
        /// <summary>
        /// ��������� ������ ����������� (Tank) �� ����� "Data/tanks.json".
        /// </summary>
        /// <returns>������ �������� ���� Tank</returns>
        public static List<Tank> LoadTanks() => JsonService<Tank>.Load("Data/tanks.json");

        /// <summary>
        /// ��������� ������ ��������� (Unit) �� ����� "Data/units.json".
        /// </summary>
        /// <returns>������ �������� ���� Unit</returns>
        public static List<Unit> LoadUnits() => JsonService<Unit>.Load("Data/units.json");

        /// <summary>
        /// ��������� ������ ������� (Factory) �� ����� "Data/factories.json".
        /// </summary>
        /// <returns>������ �������� ���� Factory</returns>
        public static List<Factory> LoadFactories() => JsonService<Factory>.Load("Data/factories.json");

        /// <summary>
        /// ��������� ������ ������ (Deal) �� ����� "Data/deals.json".
        /// </summary>
        /// <returns>������ �������� ���� Deal</returns>
        public static List<Deal> LoadDeals() => JsonService<Deal>.Load("Data/deals.json");
    }
}