// Подключение стандартного пространства имён System.Collections.Generic
// для работы с обобщёнными коллекциями (например, List<T>)
using System.Collections.Generic;

// Подключение пользовательского пространства имён TankApp.Models,
// в котором определены классы моделей: Tank, Unit, Factory, Deal и др.
using TankApp.Models;

// Подключение пользовательского пространства имён TankApp.Services,
// где находятся сервисные классы приложения, включая JsonService и DataLoader
using TankApp.Services;

namespace TankApp.Services
{
    /// <summary>
    /// Статический класс DataLoader предоставляет методы для загрузки данных о различных сущностях из JSON-файлов.
    /// </summary>
    public static class DataLoader
    {
        /// <summary>
        /// Загружает список резервуаров (Tank) из файла "Data/tanks.json".
        /// </summary>
        /// <returns>Список объектов типа Tank</returns>
        public static List<Tank> LoadTanks() => JsonService<Tank>.Load("Data/tanks.json");

        /// <summary>
        /// Загружает список установок (Unit) из файла "Data/units.json".
        /// </summary>
        /// <returns>Список объектов типа Unit</returns>
        public static List<Unit> LoadUnits() => JsonService<Unit>.Load("Data/units.json");

        /// <summary>
        /// Загружает список заводов (Factory) из файла "Data/factories.json".
        /// </summary>
        /// <returns>Список объектов типа Factory</returns>
        public static List<Factory> LoadFactories() => JsonService<Factory>.Load("Data/factories.json");

        /// <summary>
        /// Загружает список сделок (Deal) из файла "Data/deals.json".
        /// </summary>
        /// <returns>Список объектов типа Deal</returns>
        public static List<Deal> LoadDeals() => JsonService<Deal>.Load("Data/deals.json");
    }
}