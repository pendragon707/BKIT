using System;

namespace L2
{
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

}