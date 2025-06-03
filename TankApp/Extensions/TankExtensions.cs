// Подключение стандартного пространства имён System, 
// содержащего базовые классы и методы .NET
using System;

// Подключение пространства имён System.Collections.Generic,
// необходимого для работы с обобщёнными коллекциями (например, List<T>, IEnumerable<T>)
using System.Collections.Generic;

// Подключение пользовательского пространства имён TankApp.Models,
// где, скорее всего, определены классы Tank и Unit
using TankApp.Models;

// Определение собственного пространства имён TankApp.Extensions,
// в котором будут находиться методы расширения для классов, связанных с резервуарами
namespace TankApp.Extensions
{
    /// <summary>
    /// Статический класс, содержащий методы расширения для коллекций объектов типа Tank.
    /// </summary>
    public static class TankExtensions
    {
        /// <summary>
        /// Метод расширения, который ищет первую подходящую установку (Unit) из заданной коллекции,
        /// соответствующую по имени первой из списка резервуаров (Tank).
        /// </summary>
        /// <param name="tanks">Список резервуаров, для которых нужно найти установку</param>
        /// <param name="units">Коллекция доступных установок (только для чтения)</param>
        /// <returns>Найденная установка (объект Unit)</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если ни одна установка не найдена
        /// </exception>
        public static Unit FindUnit(this List<Tank> tanks, IReadOnlyCollection<Unit> units)
        {
            // Перебираем все резервуары из списка
            foreach (var tank in tanks)
            {
                // Ищем установку с совпадающим именем
                var unit = units.FirstOrDefault(u => u.Name == tank.UnitName);

                // Если установка найдена — возвращаем её
                if (unit != null)
                    return unit;
            }

            // Если ни одна установка не была найдена — выбрасываем исключение
            throw new InvalidOperationException("Не найдена установка для резервуара!");
        }

        /// <summary>
        /// Метод расширения, вычисляющий общую ёмкость всех резервуаров в списке.
        /// </summary>
        /// <param name="tanks">Список резервуаров</param>
        /// <returns>Общий объем (сумма значений свойства Capacity)</returns>
        public static int GetTotalVolume(this List<Tank> tanks)
        {
            // Возвращаем сумму ёмкостей всех резервуаров в списке
            return tanks.Sum(t => t.Capacity);
        }
    }
}