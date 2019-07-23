using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        /// <summary>
        /// Варіанти процентів для нарахування
        /// </summary>
        enum Percent
        {
            /// <summary>
            /// Простий
            /// </summary>
            Simple,
            /// <summary>
            /// Складний, із помісячною капіталізацією
            /// </summary>
            ComplexMounth,
            /// <summary>
            /// Складний, із поквартальною капіталізацією
            /// </summary>
            ComplexQuartal
        }

        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Введення даних
            // введення вкладу
            Console.WriteLine("\nВведіть який вклад зробив користувач:\n");
            // введення чисел
            Console.Write($"\tPV = ");
            // перевірка правильності вводу
            bool error = double.TryParse(Console.ReadLine().Replace(".", ","), out double pv);
            // аналіз чи можна далі продовжувати
            if (!error || pv <= 0)
            {
                AnaliseOfInputNumber(false);
            }

            // введення вкладу
            Console.WriteLine("\nВведіть на скільки років зроблений вклад:\n");
            // введення чисел
            Console.Write($"\tt = ");
            // перевірка правильності вводу
            error = int.TryParse(Console.ReadLine(), out int t);
            // аналіз чи можна далі продовжувати 
            if (!error || t <= 0)
            {
                AnaliseOfInputNumber(false);
            }

            // виведення процентної ставки, задана в умові
            Console.WriteLine("\nРічна номінальна процентна ставка:\n");
            double r = 0.1;
            Console.WriteLine($"\tr = {r * 100:N2}%");
            #endregion

            #region Виведення даних
            // Коротка інформація для клієнта для оцінки
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n\tРезультуюча сума на рахунку за 5 років:");
            Console.WriteLine($"\t\t- за простими процентами: FV = {CalcMoneySing(pv, 5, r, Percent.Simple):N2};");
            Console.WriteLine($"\t\t- за складними процентами: FV = {CalcMoneySing(pv, 5, r, Percent.ComplexMounth):N2};");
            Console.ForegroundColor = ConsoleColor.Blue;

            // Результат за вказаними даними користувача
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\tРезультуюча сума на рахунку за {t} років:");
            Console.WriteLine($"\t\t- за простими процентами: FV = {CalcMoneySing(pv, t, r, Percent.Simple):N2};");
            Console.WriteLine($"\t\t- за складними процентами: FV = {CalcMoneySing(pv, t, r, Percent.ComplexMounth):N2};");
            Console.ForegroundColor = ConsoleColor.Gray;
            #endregion

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Розрахунок суми на рахунку за простими і складними процентами
        /// </summary>
        /// <param name="pv">Сума вкладу</param>
        /// <param name="t">Період на який зроблено вклад, років</param>
        /// <param name="r">Відсоткова річна ставка</param>
        /// <returns>Результуюча сума після закінчення періоду</returns>
        static double CalcMoneySing(double pv, int t, double r, Percent per)
        {
            double fv = default;    // результуюча сума по закінченню періоду
            int n = default;        // кількість разів складання відсотку за рік

            switch (per)
            {
                case Percent.Simple:
                    fv = pv * (1 + r * t);
                    break;
                case Percent.ComplexMounth:   // https://uk.wikipedia.org/wiki/Складні_відсотки
                    n = 12;
                    goto default;
                case Percent.ComplexQuartal:
                    n = 4;
                    goto default;
                default:
                    fv = pv * Math.Pow(1 + r / n, n * t);
                    break;
            }

            // вивід результату
            return fv;
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
