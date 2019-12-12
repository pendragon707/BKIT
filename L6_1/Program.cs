using L5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6_1
{
    class Program
    {
        public delegate ShearchItemClass ShearhFunction(string firstText, string secondText);
        static void Main()
        {
            ShearhFunction ShearhF = null;
            Func<string, string, ShearchItemClass> ShearhFunc = null;

            List<string> words = new List<string>();

            string WorkFile = OpenFiletoList(ref words);
            Console.WriteLine("Строка для поиска :");
            string FindString = Console.ReadLine();
            int FindType = FindTypeEnter();
            switch (FindType)
            {
                case 1:
                    ShearhF = new ShearhFunction(L5.LevenshteinDistance.StrContains);
                    ShearhFunc = new Func<string, string, ShearchItemClass>((firstText, secondText) =>
                    {
                        ShearchItemClass ShearchIt = new ShearchItemClass(firstText, 0);
                        if (firstText.Contains(secondText)) ShearchIt.Distance = 0;
                        else ShearchIt.Distance = 100;
                        return ShearchIt;
                    });           //(L5.LevenshteinDistance.StrContains);)
                    break;
                case 2:
                    ShearhF = new ShearhFunction(L5.LevenshteinDistance.WagnweFisher);
                    ShearhFunc = new Func<string, string, ShearchItemClass>(L5.LevenshteinDistance.WagnweFisher);
                    break;
                case 3:
                    ShearhF = new ShearhFunction(L5.LevenshteinDistance.DamerauLevenshteinDistance);
                    ShearhFunc = new Func<string, string, ShearchItemClass>(L5.LevenshteinDistance.DamerauLevenshteinDistance);
                    break;
                default:
                    break;
            }
            int i = 0;
            ShearchItemClass ShearchItem = null;
            foreach (string s in words)
            {
                ShearchItem = ShearhFunc(s, FindString);
                Console.WriteLine("Func     {0} : Строка - {1}, Дистанция - {2}", i, s, ShearchItem.Distance);
                ShearchItem = ShearhF(s, FindString);
                Console.WriteLine("delegate {0} : Строка - {1}, Дистанция - {2}", i, s, ShearchItem.Distance);
                Console.WriteLine();
                i++;


            }

            Console.ReadLine();
        }


        static string OpenFiletoList(ref List<string> words)
        {
            string aFilename = "";
            do
            {
                do
                {
                    if (!(aFilename == "")) Console.WriteLine("Не правильное имя файла");

                    Console.WriteLine("Имя файла для поиска :");
                    aFilename = Console.ReadLine();
                    if (aFilename == "") aFilename = "Новый текстовый документ (2).txt";
                    Console.WriteLine("Имя файла для поиска : " + aFilename);
                }
                while (!File.Exists(aFilename));
                try
                {
                    foreach (string s in File.ReadAllText(aFilename, Encoding.ASCII).Split(' ', '\t', '!', '?', ',', '-', '.', ':', '\r', '\n'))
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            string lowercase = s.ToLower();
                            if (!words.Contains(lowercase)) words.Add(lowercase);
                        }
                    }
                }
                catch
                {
                    aFilename = "";
                    Console.WriteLine("Ошибка чтения файла");
                }

            }
            while (aFilename == "");

            return aFilename;
        }

        static int FindTypeEnter()
        {
            int indicator = -1;
            do
            {
                Console.WriteLine("Введите алгоритм поиска 1-3");
                Console.WriteLine("1 - простой поиск");
                Console.WriteLine("2 - алгоритм Вагнера-Фишера");
                Console.WriteLine("3 - алгоритм Дамерау-Левенштейна");

                Console.WriteLine("Введите номер действия");
                bool success = Int32.TryParse(Console.ReadLine(), out indicator);
                if (!success)
                {
                    Console.WriteLine("Неверное значение !!!");
                    indicator = -1;
                }
            }
            while ((indicator < 0) || (indicator > 3));



            return indicator;
        }
    }
}
