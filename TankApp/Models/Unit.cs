// Подключение пользовательского пространства имён TankApp.Interfaces,
// чтобы получить доступ к интерфейсу IEntity, который реализуется в этом классе
using TankApp.Interfaces;

// Определение пространства имён TankApp.Models — здесь находятся модели предметной области приложения
namespace TankApp.Models
{
    /// <summary>
    /// Класс Unit представляет технологическую установку в системе.
    /// Реализует интерфейс IEntity, обеспечивая базовые свойства (Id и Name) для всех сущностей.
    /// </summary>
    public class Unit : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор установки (GUID).
        /// Генерируется автоматически при создании объекта.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Название установки. Может задаваться и изменяться.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имя завода, на котором расположена данная установка.
        /// Используется для поиска соответствующего завода в коллекции.
        /// </summary>
        public string FactoryName { get; set; }

        /// <summary>
        /// Метод для поиска завода (Factory), на котором расположена текущая установка.
        /// </summary>
        /// <param name="factories">Коллекция доступных заводов (только для чтения)</param>
        /// <returns>Найденный завод (объект типа Factory)</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается, если завод с указанным именем не найден
        /// </exception>
        public Factory FindFactory(IReadOnlyCollection<Factory> factories)
        {
            // Пытаемся найти первый завод с совпадающим именем
            var factory = factories.FirstOrDefault(f => f.Name == FactoryName);

            // Если завод не найден — выбрасываем исключение
            if (factory == null)
                throw new InvalidOperationException($"Не найден завод с именем '{FactoryName}'!");

            // Возвращаем найденный завод
            return factory;
        }
    }
}