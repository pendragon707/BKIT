using System;

namespace L2
{
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

}