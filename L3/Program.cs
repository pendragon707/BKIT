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
                            Console.WriteLine("\nМатрица");
                            Matrix3d<GeomFig> cube = new Matrix3d<GeomFig>(3, 3, 3, null);
                            cube[0, 0, 0] = rectangle;
                            cube[1, 1, 1] = square;
                            cube[2, 2, 2] = circle;
                            Console.WriteLine(cube.ToString());
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nСтек");
                            SimpleStack<GeomFig> stack = new SimpleStack<GeomFig>();
                            stack.Push(rectangle);
                            stack.Push(square);
                            stack.Push(circle);

                            while (stack.Count > 0)
                            {
                                GeomFig f = stack.Pop();
                                Console.WriteLine(f);
                            }
                            Console.WriteLine();
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
