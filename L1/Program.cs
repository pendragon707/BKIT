using System;

namespace L1
{
    class Program
    {
        public class Functions
        {
            public static void InputCoef(string[] args, double[] coefficients, bool success)
            {
                if (args.Length != 3 || !success)
                {
                    if (args.Length != 3)
                    {
                        string[] args2 = new string[3];
                        args = args2;
                    }
                    Console.WriteLine("Введите 3 коэффициента уравнения (Нажимайте Enter)");
                        for (int k = 0; k < 3; k++)
                            args[k] = Console.ReadLine();       
                }
                Byte i = 0;
                foreach (string Argument in args)
                {
                    success = Double.TryParse(Argument, out coefficients[i]);
                    if(!success)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Некорректный коээфициент под номером {i}. Пожалуйста, попробуйте снова.");
                        Console.ResetColor();
                        InputCoef(args, coefficients, success);
                        return;
                    }
                    Console.Write("{0 }  ", Argument);
                    i++;
                }
                Console.Write("- введённые коэффициенты");
                Console.WriteLine();
            }

            public static double Disc(double a, double b, double c)
            {
                return (Math.Pow(b, 2) - (4 * a * c));
            }

            private static double CalcRoot(double a, double b, double disc)
            {
                return (-b + disc) / (2 * a);
            }

            public static void KvadrRoot(double b, double c)
            {
                    double root;
                if((-c/b) < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                    Console.ResetColor();
                }
                    root = Math.Sqrt(-c / b);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корни: {0}, {1}", root, -root);
                    Console.ResetColor();
            }

            public static void Solution(double a, double b, double c)
            {
                if (a == 0 && b == 0)
                {
                    Console.WriteLine("Корней бесконечно много");
                    return;
                }
                if (a == 0)
                {
                    Console.WriteLine("Уравнение квадратное");
                    KvadrRoot(b, c);
                    return;
                }
                double disc = Functions.Disc(a, b, c);
                if (disc < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                    Console.ResetColor();
                    return;
                }
                disc = Math.Sqrt(disc);
                bool indicator = false;
                double root;
                root = CalcRoot(a, b, disc);
                if (root >= 0)
                {
                    Console.Write("Корни:  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}, {1}", Math.Sqrt(root), -Math.Sqrt(root));
                    Console.ResetColor();
                    indicator = true;
                }
                root = CalcRoot(a, b, -disc);
                if (root >= 0)
                {
                    if (indicator == false) Console.Write("Корни:  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}, {1}", Math.Sqrt(root), -Math.Sqrt(root));
                    Console.ResetColor();
                    indicator = true;
                }
                if (!indicator)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Действительных корней нет");
                    Console.ResetColor();
                }
            }

            static void Main(string[] args)
            {
                Console.Title = "Подопригорова Н. ИУ5-34Б";
                bool success = true;
                Double[] coefficients = new double[3];
                InputCoef(args, coefficients, success);
                Console.Write("Дискриминант: ");
                Console.WriteLine(Disc(coefficients[0], coefficients[1], coefficients[2]));   
                Functions.Solution(coefficients[0], coefficients[1], coefficients[2]);
                Console.ReadKey();
            }
        }
    }
}
    

    