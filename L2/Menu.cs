using System;

namespace L2
{
    class Menu
    {
        int indicator;
        bool success;
        public int menu()
        {
            Console.WriteLine("1 - печать объекта Rectangle");
            Console.WriteLine("2 - печать объекта Square");
            Console.WriteLine("3 - печать объекта Circle");
            Console.WriteLine("4 - выход");
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