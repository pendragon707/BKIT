using System;

namespace L3
{
    class Circle : GeomFig, IPrint
    {
        double radius;
        public Circle() {
            this.radius = 0;
            this.Type = "Круг";
        }
        public Circle(double r) {
            radius = r;
            this.Type = "Круг";
        }

        public override double Area()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }
        public override string ToString() 
        {           
            return base.ToString() + " Радиус: " + radius.ToString();
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

}