using System;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Подопригорова Н. ИУ5-34Б";
            Menu menu = new Menu();
            Rectangle rectangle = new Rectangle(5, 20);
            Square square = new Square(6);
            Circle circle = new Circle(3);
            while (true)
            {
                switch (menu.menu())
                {
                    case 1:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Печать объекта Rectangle");
                            rectangle.Print();
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Печать объекта Square");
                            square.Print();
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Печать объекта Circle");
                            circle.Print();
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            return;
                        }
                }
            }
        }
    }

}