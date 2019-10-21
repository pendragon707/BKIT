using System;

namespace L3
{
    class Square : Rectangle, IPrint
    {
        public Square() : base()
        {
            this.Type = "Квадрат";
        }

        public Square(double s) : base(s, s) {
            this.Type = "Квадрат";
        }
        
        public override string ToString()
        {
            return "Длина стороны: " + this.Hight.ToString() + " Площадь: " + (this.Area()).ToString();
        }
    }

}