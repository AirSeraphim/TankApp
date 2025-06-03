// Подключение стандартного пространства имён System, 
// которое содержит базовые классы и методы для работы в .NET
using System;

// Определение пространства имён TankApp.Events, 
// чтобы логически сгруппировать связанные типы (в данном случае — события)
namespace TankApp.Events
{
    // Класс UserEnteredNumberEventArgs представляет собой пользовательский аргумент события.
    // Используется при возникновении события, когда пользователь вводит число.
    public class UserEnteredNumberEventArgs : EventArgs
    {
        // Свойство Input хранит значение числа, введённого пользователем
        public int Input { get; set; }

        // Свойство EnteredAt указывает время, когда было введено число
        public DateTime EnteredAt { get; set; }
    }
}