using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("L6_2.ClassForInsp");
            Console.WriteLine("Получен тип  :  " + t.FullName);
            Console.WriteLine("Исходный класс :  " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен  :  " + t.Namespace);
            Console.WriteLine("Находится в сборке  :  " + t.AssemblyQualifiedName);
            Console.WriteLine();
            Console.WriteLine("Все Конструкторы : ");
            int k = 1;
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(k + " - " + x);
                k++;
            }
            Console.WriteLine();
            Console.WriteLine("Все Методы  :  ");
            k = 1;
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(k + " - " + x);
                k++;
            }
            Console.WriteLine();
            Console.WriteLine("Все Свойства  :  ");
            k = 1;
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(k + " - " + x);
                k++;
            }
            Console.WriteLine();
            Console.WriteLine("Все Поля данных  :  ");
            k = 1;
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(k + " - " + x);
                k++;
            }
            Console.WriteLine();
            Console.WriteLine("Методы, помеченные атрибутом  :  ");
            k = 1;
            foreach (var x in t.GetMethods())
            {
                var isAttribute = x.GetCustomAttributes(false);
                if (isAttribute.Length > 0)
                {
                    Console.Write(k + " - " + x.Name + " имеет {0} атрибутов ", isAttribute.Length);
                    foreach (var att in isAttribute)
                        if (att is NumAttribute) Console.Write(", в то числе NumAttribute. NumPole = " + (att as NumAttribute).NumPole);
                        else if (att is Attribute) Console.Write(", атрибут : " + (att as Attribute));
                    Console.WriteLine();
                }
                k++;
            }


            Console.WriteLine();

            Console.WriteLine("Вызов конструктора через рефлексию : ");

            ClassForInsp fi = (ClassForInsp)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            object Result = t.InvokeMember("SurfaceRectangle", BindingFlags.InvokeMethod, null, fi, new object[] { 3, 2 });

            Console.WriteLine("SurfaceRectangle(3,2)={0}", Result);

            Console.ReadLine();
        }
}
}
