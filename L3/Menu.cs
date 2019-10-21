using System;

namespace L3
{
    class Menu
    {
        int indicator;
        bool success;
        public int menu()
        {
            Console.WriteLine("1 - коллекция ArrayList");
            Console.WriteLine("2 - коллекция List<Figure>");
            Console.WriteLine("3 - Матрица");
            Console.WriteLine("4 - Стек");
            Console.WriteLine("5 - выход");
            Console.WriteLine("Введите номер действия");
            success = Int32.TryParse(Console.ReadLine(), out indicator);
            if (!success)
            {
                Console.WriteLine();
                indicator = menu();
            }
            return indicator;
        }
    }

}