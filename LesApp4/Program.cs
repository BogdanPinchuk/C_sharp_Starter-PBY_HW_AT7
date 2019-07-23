using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ВАЖЛИВО !!!
// Чи можна даний алгоритм вважати алгоритмом Дейкстра?
// Якщо замість реалізації switch в головному тілі програми Main()
// я реалізував його в окремому методі Calc(...) і ArifOper(...)
// чи необхідно переписати алгоритм з детальним поелементним аналізом
// повністю введеного рядка?

namespace LesApp4
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // алгоритм Дейкстри
            for (; ; )
            {
                // змінні для розрахунку
                double a, b;
                // операція для виконання
                string oper;
                // доступ до наступної операції
                bool error = true;

                Console.ForegroundColor = ConsoleColor.Green;
                // введення вкладу
                Console.Write("\n\tКалькулятор: ");
                Console.ForegroundColor = ConsoleColor.Gray;

                // введення результату
                string s = Console.ReadLine().ToLower();

                // вихід
                DoExit(s);

                // введення даних
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nВведіть число: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("a = ");
                error = double.TryParse(Console.ReadLine().Replace(".", ","), out a);
                AnaliseOfInputNumber(error);

                // введення операції
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введіть операцію: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                s = Console.ReadLine();
                error = ArifOper(s, out oper);
                AnaliseOfInputNumber(error);

                // введення даних
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введіть число: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("b = ");
                error = double.TryParse(Console.ReadLine().Replace(".", ","), out b);
                AnaliseOfInputNumber(error);

                // виведення даних
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n\tРезультат: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"a {oper} b = {Calc(a, b, oper):N2};");
            }
        }

        /// <summary>
        /// Розрахунок відповідно до вибраної опрації
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        static double Calc(double a, double b, string oper)
        {
            // результат
            double res = default;

            // виконання арифметчиних операцій
            switch (oper)
            {
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;
                    break;
                case "*":
                    res = a * b;
                    break;
                case "/":
                    res = DoDiv(a, b);
                    break;
            }

            // вивід результату
            return res;
        }

        /// <summary>
        /// Частка чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static double DoDiv(double a, double b)
        {
            // перевірка на 0
            double temp = default;

            if (a == 0 && b == 0)
            {
                temp = double.NaN;
            }
            else if (a > 0 && b == 0)
            {
                temp = double.PositiveInfinity;
            }
            else if (a < 0 && b == 0)
            {
                temp = double.NegativeInfinity;
            }
            else
            {
                temp = a / b;
            }

            // вивід
            return temp;
        }

        /// <summary>
        /// Арифметична операція
        /// </summary>
        /// <returns></returns>
        static bool ArifOper(string s, out string oper)
        {
            // перевірка чи це є операцією
            bool res = true;

            // початкове значення
            oper = string.Empty;

            // запис операції
            switch (s)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    oper = s;
                    break;
                default:
                    res = false;
                    break;
            }

            return res;
        }

        /// <summary>
        /// Вихід по слову "exit"
        /// </summary>
        /// <param name="s"></param>
        static void DoExit(string s)
        {
            if (s == "exit")
            {
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                //Console.Clear();
                Main();
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
