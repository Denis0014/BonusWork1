using System;
using System.Reflection.Metadata.Ecma335;

namespace BonusWork1
{
    internal class Program
    {
        /// <summary>
        /// Типы операций в методе Action 
        /// </summary>
        /// <remarks>
        /// Sum: преобразовать все параметры к целым числам и вычислить их сумму.<br></br>
        /// Average: преобразовать все параметры к вещественным числам и вычислить их среднее арифметическое.<br></br>
        /// Multiply: Преобразовать все параметры к long и перемножить их.
        /// </remarks>
        enum ActionType { Sum, Average, Multiply };
        /// <summary>
        /// Cовершает одно из действий (ActionType) и выводит результат на экран, в зависимости от значения перечислимого типа
        /// </summary>
        /// <param name="act">Типы операций</param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <exception cref="ArgumentException">Действие не определено в этом методе</exception>
        static void Action(ActionType act, int a, double b, long c)
        {
            double res = 0;
            switch (act) 
            {
                case ActionType.Sum:
                    res = a + (int)b + (int)c;
                    Console.WriteLine((int)res);
                    break;
                case ActionType.Average:
                    res = ((double)a + b + (double)c) / 3;
                    Console.WriteLine((double)res);
                    break;
                case ActionType.Multiply:
                    res = (long)a * (long)b * c;
                    Console.WriteLine((long)res);
                    break;
                default:
                    throw new ArgumentException("Action: Неверный тип оперции");
            }
        }
        /// <summary>
        /// Возвращает, является ли строка счастливой
        /// </summary>
        /// <remarks>
        /// Будем называть строку счастливой, если, просуммировав коды символов,<br></br>
        /// составляющих эту строку, получается число, оканчивающееся на цифру 7
        /// </remarks>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool StringIsHappy(string s) => s.ToCharArray().Sum(x => x) % 10 == 7;

        static void Main(string[] args)
        {
            // Задание 1
            Action(ActionType.Sum, 4, 12.0, 100L);
            // Задание 2
            Console.WriteLine(StringIsHappy(" 7"));
        }
    }
}