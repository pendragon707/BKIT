using System;

namespace L2
{
    class Square : Rectangle, IPrint
    {
        public Square(double s) : base(s, s) { }
        
        public override string ToString()
        {
            return "Длина стороны: " + this.Hight.ToString() + " Площадь: " + (this.Area()).ToString();
        }
    }

}