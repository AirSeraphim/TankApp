// Подключение пользовательского пространства имён TankApp.Interfaces,
// чтобы иметь доступ к интерфейсу IEntity, который реализуется в этом классе
using TankApp.Interfaces;

// Определение пространства имён TankApp.Models — здесь находятся модели предметной области приложения
namespace TankApp.Models
{
    /// <summary>
    /// Класс Factory представляет завод (производственное предприятие) в системе.
    /// Реализует интерфейс IEntity, обеспечивая базовые свойства для всех сущностей.
    /// </summary>
    public class Factory : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор завода (GUID).
        /// Генерируется автоматически при создании объекта.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Название завода. Может задаваться и изменяться.
        /// </summary>
        public string Name { get; set; }
    }
}