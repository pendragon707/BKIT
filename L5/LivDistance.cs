using System;

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

    public class LevenshteinDistance
    {

        static int Minimum(int a, int b) => a < b ? a : b;

        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

        static int Min(params int[] input)
        {
            int ret = input[0];
            foreach (int a in input) if (a < ret) ret = a;
            return ret;
        }

        public static ShearchItemClass StrContains(string firstText, string secondText)
        {
            ShearchItemClass ShearchItem = new ShearchItemClass(firstText, 0);
            if (firstText.Contains(secondText)) ShearchItem.Distance = 0;
            else ShearchItem.Distance = 100;
            return ShearchItem;
        }


        public static ShearchItemClass WagnweFisher(string firstText, string secondText)
        {
            ShearchItemClass ShearchItem = new ShearchItemClass(firstText, 0);

            var d = new int[100, 100];

            int i, j;
            int tracker;

            int str1_len = firstText.Length;
            int str2_len = secondText.Length;
            for (i = 0; i <= str2_len; i++)
                d[0, i] = i;
            for (j = 0; j <= str1_len; j++)
                d[j, 0] = j;
            for (j = 1; j <= str1_len; j++)
            {
                for (i = 1; i <= str2_len; i++)
                {
                    if (secondText[i - 1] == firstText[j - 1])
                    {
                        tracker = 0;
                    }
                    else
                    {
                        tracker = 1;
                    }
                    int temp = Minimum((d[j - 1, i] + 1), (d[j, i - 1] + 1));
                    d[j, i] = Minimum(temp, (d[j - 1, i - 1] + tracker));
                }
            }

            ShearchItem.Distance = d[str1_len, str2_len];

            return ShearchItem;
        }


        public static ShearchItemClass DamerauLevenshteinDistance(string firstText, string secondText)
        {
            /*
            // случай-где они равны
            if (firstText.Equals(secondText))
                return 0;

            // случай-где один пуст
            if (String.IsNullOrEmpty(firstText) || String.IsNullOrEmpty(secondText))
                return (firstText ?? "").Length + (secondText ?? "").Length;

            // firstText длинней secondText
            if (firstText.Length > secondText.Length)
            {
                var tmp = firstText;
                firstText = secondText;
                secondText = tmp;
            }

            if (secondText.Contains(firstText))
                return secondText.Length - firstText.Length;  */


            var n = firstText.Length + 1;
            var m = secondText.Length + 1;
            int k = 0;
            var arrayD = new int[n, m];
            var arrayP = new char[n, m];
            ShearchItemClass ShearchItem = new ShearchItemClass(firstText, n * m);

            for (var ii = 0; ii < n; ii++)
            {
                arrayD[ii, 0] = ii;
                arrayP[ii, 0] = 'D';
            }

            for (var jj = 0; jj < m; jj++)
            {
                arrayD[0, jj] = jj;
                arrayP[0, jj] = 'I';
            }

            for (var ii = 1; ii < n; ii++)
            {
                for (var jj = 1; jj < m; jj++)
                {
                    char iiD1 = firstText[ii - 1];
                    char jjD1 = secondText[jj - 1];


                    var cost = iiD1 == jjD1 ? 0 : 1;// firstText[ii - 1] == secondText[jj - 1] ? 0 : 1;
                                                    /*if (ii > 1 && jj > 1
                                                        && firstText[ii - 1] == secondText[jj - 2]
                                                        && firstText[ii - 2] == secondText[jj - 1])
                                                    {
                                                         // перестановка
                                                        arrayD[ii, jj] = Minimum(arrayD[ii, jj],
                                                                                 arrayD[ii - 2, jj - 2] + cost); 
                                                        arrayP[ii, jj] = 'S';
                                                    }
                                                    else*/
                    if (arrayD[ii, jj - 1] < arrayD[ii - 1, jj] && arrayD[ii, jj - 1] < arrayD[ii - 1, jj - 1] + cost)
                    {
                        //Вставка
                        arrayD[ii, jj] = arrayD[ii, jj - 1] + 1;
                        arrayP[ii, jj] = 'I';
                    }
                    else if (arrayD[ii - 1, jj] < arrayD[ii - 1, jj - 1] + cost)
                    {
                        //Удаление
                        arrayD[ii, jj] = arrayD[ii - 1, jj] + 1;
                        arrayP[ii, jj] = 'D';
                    }
                    else
                    {
                        //Замена или отсутствие операции
                        arrayD[ii, jj] = arrayD[ii - 1, jj - 1] + cost;
                        arrayP[ii, jj] = (cost == 1) ? 'R' : 'M';
                    }
                    ShearchItem.ArrayGrid[k] = arrayD[ii, jj];
                    ShearchItem.ArrayPrescript[k] = arrayP[ii, jj];
                    k++;
                }


            }
            ShearchItem.Distance = arrayD[n - 1, m - 1];

            //Восстановление предписания
            ShearchItem.Prescript = "";
            int i = n - 1, j = m - 1, d = ShearchItem.Distance + 1;
            do
            {
                char c = arrayP[i, j];
                ShearchItem.Prescript = c + ShearchItem.Prescript;

                if (c != 'M') d--;

                if (c == 'R' || c == 'M' || c == 'S')
                {
                    i--;
                    j--;
                }
                else if (c == 'D')
                {
                    i--;
                }
                else if (c == 'I')
                {
                    j--;
                }

            } while ((d != 0) && ((i != 0) || (j != 0)));

            return ShearchItem;
        }



    }


}
