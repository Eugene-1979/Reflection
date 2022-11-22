using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
    {
   

        static class Programs
            {
            // Получаем разную информацию
            static void ListVariosStats(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Информация о Class1" + "\n");
            

                Console.WriteLine("Полное Имя:             {0}", t.FullName);
                Console.WriteLine("Базовый класс:          {0}", t.BaseType);
                Console.WriteLine("Абстрактный:            {0}", t.IsAbstract);
                Console.WriteLine("Запрещено наследование: {0}", t.IsSealed);
                Console.WriteLine("Это class:              {0}", t.IsClass);
                }

            // Получаем информацию об Именах всех методов
            static void ListMethods(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Методы класса Class1" + "\n");
              
                MethodInfo[] mi = t.GetMethods(BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

                foreach (MethodInfo m in mi)
                    Console.WriteLine("Method: {0}", m.Name);
                }

            // Получаем информацию об Именах полей 
            static void ListFields(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Поля класса Class1" + "\n");

               
                FieldInfo[] fi =
                    t.GetFields(BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic);

                foreach (FieldInfo f in fi)
                    Console.WriteLine("Field: {0}", f.Name);
                }

            //  Свойства
            static void ListProps(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Свойства класса Class1" + "\n");
               
                PropertyInfo[] pi = t.GetProperties();

                foreach (PropertyInfo p in pi)
                    Console.WriteLine("Свойство: {0}", p.Name);
                }

            //  Интерфейсі
            static void ListInterfaces(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Интерфейсы класса Class1" + "\n");
            

                Type[] it = t.GetInterfaces();

                foreach (Type i in it)
                    Console.WriteLine("Интерфейс: {0}", i.Name);
                }

            // конструкторі 
            static void ListConstructors(Type t)
                {
                Console.WriteLine(new string('_', 30) + " Конструкторы класса Class1" + "\n");

               
                ConstructorInfo[] ci = t.GetConstructors();

                foreach (ConstructorInfo m in ci)
                    Console.WriteLine("Constructor: {0}", m.Name);
                }

           public static void Go(Type instance)
                {
                Console.SetWindowSize(80, 45);

             

           

                ListVariosStats(instance);  // Получаем разную информацию 
                ListMethods(instance);      // Получаем информацию об Именах всех методов
                ListFields(instance);       // Получаем информацию об Именах всех полей
                ListProps(instance);        // Получаем список всех Свойств 
                ListInterfaces(instance);   // Получаем список всех Интерфейсов
                ListConstructors(instance); // Получаем информацию конструкторов


                }
            }
        }
    
