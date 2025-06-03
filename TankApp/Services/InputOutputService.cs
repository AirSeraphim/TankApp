// Подключение стандартного пространства имён System,
// необходимого для работы с базовыми типами и классами, такими как Console и DateTime
using System;

// Подключение пользовательского пространства имён TankApp.Events,
// в котором определён аргумент события UserEnteredNumberEventArgs
using TankApp.Events;

namespace TankApp.Services
{
    /// <summary>
    /// Класс InputOutputService предоставляет функционал для чтения ввода пользователя из консоли
    /// и уведомления о введённых числах через событие.
    /// </summary>
    public class InputOutputService
    {
        /// <summary>
        /// Событие, которое возникает при корректном вводе пользователем числа.
        /// Передаёт объект типа UserEnteredNumberEventArgs, содержащий само число и время его ввода.
        /// </summary>
        public event EventHandler<UserEnteredNumberEventArgs> NumberEntered;

        /// <summary>
        /// Метод запускает цикл чтения ввода от пользователя.
        /// Пользователь может вводить числа или команду "exit" для выхода.
        /// При вводе числа вызывается событие NumberEntered.
        /// </summary>
        public void StartReading()
        {
            while (true)
            {
                // Выводим приглашение к вводу
                Console.Write("Введите число или 'exit' для выхода: ");

                // Читаем строку, введённую пользователем
                var input = Console.ReadLine();

                // Если пользователь ввёл "exit", выходим из цикла
                if (input.ToLower() == "exit") break;

                // Пробуем преобразовать ввод в целое число
                if (int.TryParse(input, out int number))
                {
                    // Если преобразование успешно — вызываем событие
                    OnNumberEntered(new UserEnteredNumberEventArgs
                    {
                        Input = number,         // Сохраняем введённое число
                        EnteredAt = DateTime.Now // Фиксируем время ввода
                    });
                }
                else
                {
                    // Если ввод некорректен — выводим сообщение об ошибке
                    Console.WriteLine("Неверный формат. Попробуйте снова.");
                }
            }
        }

        /// <summary>
        /// Защищённый виртуальный метод, вызывающий событие NumberEntered.
        /// Предоставляет возможность переопределения в производных классах.
        /// </summary>
        /// <param name="e">Аргумент события, содержащий информацию о введённом числе</param>
        protected virtual void OnNumberEntered(UserEnteredNumberEventArgs e)
        {
            // Вызываем событие, если есть подписчики
            NumberEntered?.Invoke(this, e);
        }
    }
}