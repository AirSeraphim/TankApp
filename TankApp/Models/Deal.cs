// Определение пространства имён TankApp.Models.
// Здесь находятся классы, представляющие модели предметной области приложения.
namespace TankApp.Models
{
    /// <summary>
    /// Класс Deal представляет сделку в системе.
    /// Содержит основные свойства, характеризующие сделку.
    /// </summary>
    public class Deal
    {
        /// <summary>
        /// Сумма сделки.
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Уникальный идентификатор сделки.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Дата совершения сделки.
        /// </summary>
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Запись (record) SumByMonth представляет агрегированную информацию о сумме сделок за определённый месяц.
    /// Records удобны для неизменяемых моделей и автоматически обеспечивают семантику равенства по значению.
    /// </summary>
    /// <param name="Month">Месяц, за который рассчитана сумма</param>
    /// <param name="Sum">Общая сумма сделок за указанный месяц</param>
    public record SumByMonth(DateTime Month, int Sum);
}