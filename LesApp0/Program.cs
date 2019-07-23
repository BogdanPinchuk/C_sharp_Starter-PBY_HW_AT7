using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення даних
            Console.Write("\tВведіть необхідний рік: ");

            // перевірка правильності вводу
            bool error = int.TryParse(Console.ReadLine(), out int year);
            // аналіз чи можна далі продовжувати 
            AnaliseOfInputNumber(error);

            // аналіз високосного року
            if (year >= 0)
            {
                if (AnaliseYear(year))
                {
                    Console.WriteLine($"\n\tРік {year} - високосний.");
                }
                else
                {
                    Console.WriteLine($"\n\tРік {year} - не високосний.");
                }

            }
            else
            {
                Console.WriteLine("\n\tНеобхідно ввести рік від Різдва Христового");
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Аналіз чи рік є високосним, предікат
        /// </summary>
        /// <param name="year">Рік від Різдва Христового</param>
        /// <returns></returns>
        static bool AnaliseYear(int year)
        {
            return (year % 4 == 0) ? true : false;
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
                Console.Clear();
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
