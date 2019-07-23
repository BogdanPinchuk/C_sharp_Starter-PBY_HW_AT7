using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Введення цілих чисел
            Console.WriteLine("Введіть цілі числа:\n");

            // числа які вводитиме користувач
            int[] a = new int[5];

            // введення чисел
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"\ta{i} = ");
                // перевірка правильності вводу
                bool error = int.TryParse(Console.ReadLine(), out a[i]);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }
            #endregion

            // Інкременування чисел
            InctremNum(ref a);

            // вивиід на екран
            ShowNum(a);

            // повторення
            DoExitOrRepeat();
        }

        static void ShowNum(int[] a)
        {
            Console.WriteLine($"\nОсь результат інкрементування чисел:\n");

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"\ta{i} = {a[i]:N0};");
            }
        }

        /// <summary>
        /// Інкрементація чисел
        /// </summary>
        /// <param name="a">Масив цілих чисел</param>
        static void InctremNum(ref int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i]++;
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
