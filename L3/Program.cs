using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Circle circle = new Circle(6);
            Rectangle rectangle = new Rectangle(5, 7);
            Square square = new Square(6);          

            while (true)
            {
                switch (menu.menu())
                {
                    case 1:
                        {
                            ArrayList array = new ArrayList();
                            array.Add(circle);
                            array.Add(rectangle);
                            array.Add(square);

                            foreach (var x in array) Console.WriteLine(x);
                            Console.WriteLine();

                            Console.WriteLine("Сортировка");
                            array.Sort();
                            foreach (var x in array) Console.WriteLine(x);
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {                            
                            List<GeomFig> list = new List<GeomFig>();
                            list.Add(circle);
                            list.Add(rectangle);
                            list.Add(square);

                            foreach (var x in list) Console.WriteLine(x);
                            Console.WriteLine();

                            Console.WriteLine("Cортировка");
                            list.Sort();
                            foreach (var x in list) Console.WriteLine(x);
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }

                    case 5:
                        {
                            return;
                        }
                }
            }      
    }
    }
}
