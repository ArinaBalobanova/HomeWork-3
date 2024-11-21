using System;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Задание 1. Дана последовательность из 10 чисел. Определить, является ли эта последовательность
            упорядоченной по возрастанию.В случае отрицательного ответа определить
            порядковый номер первого числа, которое нарушает данную последовательность. Использовать break. */
            Console.WriteLine("1");
            int[] numbers = new int[10];
            Console.WriteLine("Введите 10 чисел:");
            for (int a = 0; a < 10; a++)
            {
                Console.Write($"Число {a + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[a]))
                {
                    Console.Write("Ошибка! Введите целое число еще раз: ");
                }
            }
            bool ordered = true;
            int mistake = -1;

            for (int a = 0; a < numbers.Length - 1; a++)
            {
                if (numbers[a] > numbers[a + 1])
                {
                    ordered = false;
                    mistake = a + 1; // +1, чтобы индекс соответствовал порядковому номеру
                    break;
                }
            }
            if (ordered)
            {
                Console.WriteLine("Последовательность является упорядоченной по возрастанию.");
            }
            else
            {
                Console.WriteLine($"Последовательность неупорядочена. Первое число, нарушающее последовательность: {mistake + 1}");
            }

            /* Задание 2.Игральным картам условно присвоены следующие порядковые номера в зависимости от
        их достоинства: «валету» — 11, «даме» — 12, «королю» — 13, «тузу» — 14.
        Порядковые номера остальных карт соответствуют их названиям («шестерка», «девятка» и т. п.).
        По заданному номеру карты k (6 <=k <= 14) определить достоинство соответствующей карты. Использовать try-catch-finally. */
            Console.WriteLine("2");

            Console.WriteLine("Введите порядковый номер карты (от 6 до 14):");
            string input = Console.ReadLine();
            int k;

            try
            {
                k = int.Parse(input);
                if (k < 6 || k > 14)
                {
                    throw new ArgumentOutOfRangeException("Картам соответствуют номера только от 6 до 14.");
                }
                string cardValue;

                switch (k)
                {
                    case 6:
                        cardValue = "Шестёрка";
                        break;
                    case 7:
                        cardValue = "Семёрка";
                        break;
                    case 8:
                        cardValue = "Восьмёрка";
                        break;
                    case 9:
                        cardValue = "Девятка";
                        break;
                    case 10:
                        cardValue = "Десятка";
                        break;
                    case 11:
                        cardValue = "Валет";
                        break;
                    case 12:
                        cardValue = "Дама";
                        break;
                    case 13:
                        cardValue = "Король";
                        break;
                    case 14:
                        cardValue = "Туз";
                        break;
                    default:
                        cardValue = "Неизвестная карта";
                        break;
                }

                Console.WriteLine($"Достоинство карты: {cardValue}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверно введено целое число!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Программа завершена.");
            }

            /* Задание 4. Составить программу, которая в зависимости от порядкового номера дня недели (1, 2,...,7)
            выводит на экран его название (понедельник, вторник, ..., воскресенье).Использовать enum. */
            Console.WriteLine("4");
            try
            {
                Console.WriteLine("Введите порядковый номер дня недели (1 - 7):");
                int dayNumber = int.Parse(Console.ReadLine());
                if (dayNumber < 1 || dayNumber > 7)
                {
                    throw new ArgumentOutOfRangeException("Введите корректный номер дня недели (от 1 до 7).");
                }

                DayOfWeek dayOfWeek = (DayOfWeek)dayNumber;

                switch (dayOfWeek)
                {
                    case DayOfWeek.Monday:
                        Console.WriteLine("Сегодня понедельник.");
                        break;
                    case DayOfWeek.Tuesday:
                        Console.WriteLine("Сегодня вторник.");
                        break;
                    case DayOfWeek.Wensday:
                        Console.WriteLine("Сегодня среда.");
                        break;
                    case DayOfWeek.Thursday:
                        Console.WriteLine("Сегодня четверг.");
                        break;
                    case DayOfWeek.Friday:
                        Console.WriteLine("Сегодня пятница.");
                        break;
                    case DayOfWeek.Saturday:
                        Console.WriteLine("Сегодня суббота.");
                        break;
                    case DayOfWeek.Sunday:
                        Console.WriteLine("Сегодня воскресенье.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректное целое число.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        enum DayOfWeek
        {
            Monday = 1,
            Tuesday,
            Wensday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}