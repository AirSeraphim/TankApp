// Подключение пользовательского пространства имён TankApp.Interfaces,
// чтобы получить доступ к интерфейсу IEntity, который реализуется в этом классе
using TankApp.Interfaces;

// Определение пространства имён TankApp.Models — здесь находятся модели предметной области приложения
namespace TankApp.Models
{
    /// <summary>
    /// Класс Tank представляет резервуар в системе.
    /// Реализует интерфейс IEntity, обеспечивая базовые свойства (Id и Name) для всех сущностей.
    /// </summary>
    public class Tank : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор резервуара (GUID).
        /// Генерируется автоматически при создании объекта.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Название резервуара. Может задаваться и изменяться.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ёмкость резервуара (например, в литрах или кубометрах).
        /// Может задаваться и изменяться.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Имя установки, к которой относится данный резервуар.
        /// Используется для поиска соответствующей установки в коллекции.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Метод для поиска установки (Unit), которая соответствует текущему резервуару по имени.
        /// </summary>
        /// <param name="units">Коллекция доступных установок (только для чтения)</param>
        /// <returns>Найденная установка (объект типа Unit)</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если установка с указанным именем не найдена
        /// </exception>
        public Unit FindUnit(IReadOnlyCollection<Unit> units)
        {
            // Пытаемся найти первую установку с совпадающим именем
            var unit = units.FirstOrDefault(u => u.Name == UnitName);

            // Если установка не найдена — выбрасываем исключение
            if (unit == null)
                throw new InvalidOperationException($"Не найдена установка с именем '{UnitName}'!");

            // Возвращаем найденную установку
            return unit;
        }
    }
}