using System;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Лабораторная 4.1. Написать программу, которая читает с экрана число от 1 до 365 (номер дня в году),
         переводит этот число в месяц и день месяца.Например, число 40 соответствует 9 февраля(високосный год не учитывать).*/
            Console.WriteLine("Лабораторная 4.1");
            Console.Write("Введите номер дня в году (от 1 до 365): ");
            int dayOfYear;
            while (!int.TryParse(Console.ReadLine(), out dayOfYear) || dayOfYear < 1 || dayOfYear > 365)
            {
                Console.WriteLine("Пожалуйста, введите корректное число от 1 до 365.");
            }
            DateTime Date = new DateTime(2023, 1, 1).AddDays(dayOfYear - 1);
            Console.WriteLine($"Номер дня {dayOfYear} соответствует дате: {Date.ToString("d MMMM")}");


            /* Лабораторная 4.2. Добавить к задаче из предыдущего упражнения проверку числа введенного
            пользователем. Если число меньше 1 или больше 365, программа должна вырабатывать 
            исключение, и выдавать на экран сообщение. */
            Console.WriteLine("Лабораторная 4.2");
            try
            {
                Console.Write("Введите номер дня в году (от 1 до 365): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int day))
                {
                    if (day < 1 || day > 365)
                    {
                        throw new ArgumentOutOfRangeException("day", "Номер дня должен быть в диапазоне от 1 до 365.");
                    }
                    DateTime date = new DateTime(2023, 1, 1).AddDays(day - 1);
                    Console.WriteLine($"Номер дня {day} соответствует дате: {date.ToString("d MMMM")}");
                }
                else
                {
                    throw new FormatException("Введите корректное целое число.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");

            }

            /* Домашнее задание 4.1. Изменить программу из упражнений 4.1 и 4.2 так, чтобы она
            учитывала год (високосный или нет). Год вводится с экрана. (Год високосный, если он 
            делится на четыре без остатка, но если он делится на 100 без остатка, это не високосный год.
            Однако, если он делится без остатка на 400, это високосный год.) */
            Console.WriteLine("Домашнее задание 4.1");
            try
            {
                Console.Write("Введите год: ");
                string Year = Console.ReadLine();
                if (!int.TryParse(Year, out int year))
                {
                    throw new FormatException("Введите год корректно!");
                }
                Console.Write("Введите номер дня в году (от 1 до 365): ");
                string Day = Console.ReadLine();
                if (!int.TryParse(Day, out int day))
                {
                    throw new FormatException("Введите корректное число.");
                }

                if (day < 1 || day > 365)
                {
                    throw new ArgumentOutOfRangeException("day", "Номер дня должен быть в диапазоне от 1 до 365.");
                }
                bool LeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);// Проверяем високосный год

                DateTime date = new DateTime(year, 1, 1).AddDays(day - 1);
                if (LeapYear && day > 59) // 59(28 февраля в обычном году)
                {
                    date = date.AddDays(1); // Добавляем еще один день для високосного года
                }

                // Выводим результат
                Console.WriteLine($"Номер дня в году соответствует дате: {date.ToString("d MMMM yyyy")}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
