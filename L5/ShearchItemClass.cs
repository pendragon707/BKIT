using System;
using System.Collections.Generic;
using System.Text;

namespace L5
{
    public class ShearchItemClass
    {
        public string ShearchString { get; set; }
        public int IndexItem { get; set; }
        public int[] ArrayGrid = new int[1];
        public Char[] ArrayPrescript = new Char[1];
        public int Distance { get; set; }
        public string Prescript { get; set; }
        //  public int width { get; set; }
        public ShearchItemClass(string shearchstring, int ArrCount)
        {
            this.ShearchString = shearchstring;    // строка для поиска
            this.Prescript = "";                   // редакционное предписание 
            this.Distance = 0;                     // количество операций
            this.IndexItem = -1;
            Array.Resize(ref this.ArrayGrid, ArrCount);
            Array.Clear(this.ArrayGrid, 0, ArrCount);

            Array.Resize(ref this.ArrayPrescript, ArrCount);
            Array.Clear(this.ArrayPrescript, 0, ArrCount);
        }

        public override string ToString()
        {
            return ShearchString + "  ,    " + Prescript + "   ,   " + IndexItem;
        }
    }
}
