using System;

namespace L1
{
    class Program
    {
        public class Functions
        {
            public static double disc(double a, double b, double c)
            {
                return (Math.Pow(b, 2) - (4 * a * c));
            }

            private static double rt(double a, double b, double disc)
            {
                return (-b + disc) / (2 * a);
            }

            public static (double, double) kvadrRoot(double b, double c)
            {
                    double root;
                if((-c/b) < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                    return (0, 0);
                }
                    root = Math.Sqrt(-c / b);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корни: {0}, {1}", Math.Sqrt(root), -Math.Sqrt(root));
                    return (root, -root);
            }

            public static void Root(double a, double b, double c)
            {
                if (a == 0 && b == 0)
                {
                    Console.WriteLine("Корней бесконечно много");
                    return;
                }
                if (a == 0)
                {
                    Console.WriteLine("Уравнение квадратное");
                    kvadrRoot(b, c);
                    return;
                }
                double disc = Functions.disc(a, b, c);
                if (disc < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                    return;
                }
                disc = Math.Sqrt(disc);
                bool indicator = false;
                double root;
                root = rt(a, b, disc);
                if (root > 0)
                {
                    Console.Write("Корни:  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}, {1}", Math.Sqrt(root), -Math.Sqrt(root));
                    indicator = true;
                }
                root = rt(a, b, -disc);
                if (root > 0)
                {
                    if(indicator == false) Console.Write("Корни:  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}, {1}", Math.Sqrt(root), -Math.Sqrt(root));
                    indicator = true;
                }
                if (!indicator)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                }
            }

            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите коэффициенты уравнения");
                    return;
                }
                Console.WriteLine("Введённые аргументы: ");
                Double[] a = new Double[3];
                Byte i = 0;
                foreach (string Argument in args)
                {
                    Console.Write("{0 }  ", Argument);
                    a[i] = Double.Parse(Argument);
                    i++;
                }
                Console.WriteLine();
//              Console.WriteLine(disc(a[0], a[1], a[2]));   //дискриминант
                Functions.Root(a[0], a[1], a[2]);
                Console.ReadKey();
            }
        }
    }
}

/* a*x^4 + b*x^2 + c = 0 (проверить, чтобы первый подставной корень был >0)
 * ввод коэффициентов через аргументы командной строки
 * выход: дискриминант, корни уравнения (A=0, B=0)
 * менять цвет шрифта
 */
    

    