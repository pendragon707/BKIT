using System;

namespace L2
{
    abstract class GeomFig
    {
        public abstract string ToString();
    }

    interface IPrint
    {
        void Print();
    }

    class Rectangle : GeomFig, IPrint
    {
        double widht;
        double hight;
        public Rectangle() { }
        public Rectangle(double w, double h) { widht = w; hight = h; }
        public override string ToString()
        {
            return "Ширина: " + widht.ToString() + " Длина: " + hight.ToString() + " Площадь: " + (widht * hight).ToString();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    class Square : GeomFig, IPrint
    {
        double side;
        public Square() { }
        public Square(double s) { side = s; }
        public override string ToString()
        {

            return "Длина стороны: " + side.ToString() + " Площадь: " + (side * side).ToString();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    class Circle : GeomFig, IPrint
    {
        double radius;
        public Circle() { }
        public Circle(double r) { radius = r; }
        public override string ToString()
        {
            return "Радиус: " + radius.ToString() + " Площадь: " + (Math.Pow(radius, 2) * Math.PI).ToString();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    class Menu
    {
        int indicator;
        bool success;
        public int menu()
        {
            Console.WriteLine("1 - печать объекта Rectangle");
            Console.WriteLine("2 - печать объекта Square");
            Console.WriteLine("3 - печать объекта Circle");
            Console.WriteLine("4 - выход");
            Console.WriteLine("Введите номер действия");
            success = Int32.TryParse(Console.ReadLine(), out indicator);
            if (!success)
            {
                Console.WriteLine();
                indicator = menu();
            }
            return indicator;
        }
    }

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