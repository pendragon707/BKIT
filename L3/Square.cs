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
            return base.ToString() + "Длина стороны: " + this.Hight.ToString();
        }
    }

}