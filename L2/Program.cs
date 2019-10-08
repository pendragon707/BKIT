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

    class Rectangle : IPrint, GeomFig
    {
        double widht;
        double hight;
        Rectangle() { }
        Rectangle(double w, double h) { widht = w; hight = h; }
        public override string ToString();
        public void IPrint();
    }

    class Square : IPrint, GeomFig
    {
        double side;
        Square() { }
        Square(double s) { side = s; }
        public override string ToString();
        public void IPrint();
    }

    class Circle : IPrint, GeomFig
    {
        double radius;
        Circle() { }
        Circle(double r) { radius = r; }
        public override string ToString();
        public void IPrint();
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

