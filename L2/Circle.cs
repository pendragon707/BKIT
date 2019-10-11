using System;

namespace L2
{
    class Circle : GeomFig, IPrint
    {
        double radius;
        public Circle() { radius = 0; }
        public Circle(double r) { radius = r; }
        public override double Area()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }
        public override string ToString()
        {
            return "Радиус: " + radius.ToString() + " Площадь: " + (this.Area()).ToString();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

}