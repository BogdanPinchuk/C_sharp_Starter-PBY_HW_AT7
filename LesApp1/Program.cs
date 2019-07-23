using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
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
            int[] a = new int[2];

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

            #region Введення дійсних чисел
            Console.WriteLine("\nВведіть дійсні числа:\n");

            // числа які вводитиме користувач
            double[] b = new double[2];

            // введення чисел
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write($"\tb{i} = ");
                // перевірка правильності вводу
                bool error = double.TryParse(Console.ReadLine().Replace(".", ","), out b[i]);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }
            #endregion

            // розрахунок
            double am = Average4number(ref a, ref b);

            Console.WriteLine($"\n\tСереднє арифметичне: {am:N2};\n");

            // вивести числа після інкрементації
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"\ta{i} = {a[i]:N0}");
            }

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine($"\tb{i} = {b[i]:N2}");
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Розрахунок середнього арифметичного і інкрементація
        /// </summary>
        /// <param name="a">масив цілих чисел</param>
        /// <param name="b">масив дійсних чисел</param>
        /// <returns></returns>
        static double Average4number(ref int[] a, ref double[] b)
        {
            // середнє арифметичне
            double res = (a.Sum() + b.Sum()) / (a.Length + b.Length);

            for (int i = 0; i < a.Length; i++)
            {
                a[i]++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i]++;
            }

            return res;
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
