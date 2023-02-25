using System;

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
        /// <param name="act">Тип операции</param>
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
        public static class Extensions
        {
            /// <summary>
            /// Печатает на экран матрицу
            /// </summary>
            /// <typeparam name="T">Исходный тип</typeparam>
            /// <param name="matr">Исходная матрица</param>
            public static void PrintMatr<T>(T[,] matr)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                        Console.Write($"{matr[i, j],-3}");
                    Console.WriteLine();
                }
            }
            /// <summary>
            /// Печатает на экран массив
            /// </summary>
            /// <typeparam name="T">Исходный тип</typeparam>
            /// <param name="matr">Исходный массив</param>
            public static void PrintArr<T>(T[] matr)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                    Console.Write($"{matr[i]}");
            }
        }
        /// <summary>
        /// Проецируюет значения матрица типа T в возвращаюмую матрицу типа S
        /// </summary>
        /// <typeparam name="T">Исходный тип</typeparam>
        /// <typeparam name="S">Получаемый тип</typeparam>
        /// <param name="matr">Исходная матрица</param>
        /// <param name="f">Функция преобразования элемента из типа T в тип S</param>
        /// <returns>Матрица типа S</returns>
        static S[,] SelectMatr<T, S>(T[,] matr, Func<T, S> f)
        {
            S[,] res = new S[matr.GetLength(0), matr.GetLength(1)];
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    res[i, j] = f(matr[i, j]);
            return res;
        }

        /// <summary>
        /// Возвращает, является ли строка счастливой
        /// </summary>
        /// <remarks>
        /// Будем называть строку счастливой, если, просуммировав коды символов,<br></br>
        /// составляющих эту строку, получается число, оканчивающееся на цифру 7
        /// </remarks>
        /// <param name="s">Исходжная строка</param>
        /// <returns>Является ли строка счастливой?</returns>
        static bool StringIsHappy(string s) => s.ToCharArray().Sum(x => x) % 10 == 7;

        static int IntToBool(bool b) => b? 1 : 0;
        static void Main(string[] args)
        {
            // Задание 1
            Action(ActionType.Sum, 4, 12.0, 100L);
            // Задание 2
            Console.WriteLine(StringIsHappy(" 7"));
            // Задание 3
            Extensions.PrintMatr(new int[,] { { 10, 2, 30 }, { 4, 50, 6 }, { 70, 8, 90 } });
            // Задание 4
            Extensions.PrintMatr(SelectMatr(new bool[,] { { true, false }, { false, true } }, IntToBool));
        }
    }
}