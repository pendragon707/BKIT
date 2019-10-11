using System;

namespace L2
{
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

}