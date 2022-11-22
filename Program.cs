using System.Reflection;

namespace Reflection
    {
    internal class Program
        {

        static void Main(string[] args)
            {


           /* Загружаем сборку ClassLibraryForReflection*/
            Assembly assem = null;
            try
                {
                assem = Assembly.LoadFrom(".\\ClassLibraryForReflection.dll");
                }
            catch (FileNotFoundException ex)
                {

                Console.WriteLine("no ok");
                }


            Type ?type = assem.GetType("ClassLibraryForReflection.Class2");
            Type ?atr = assem.GetType("ClassLibraryForReflection.MyAttribute");


            Programs.Go(type);


            object? v = Activator.CreateInstance(type);

           /* получаем методі Class2*/
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.DeclaredOnly |
            BindingFlags.Public |
            BindingFlags.Instance);




            Console.WriteLine(Environment.NewLine+ "вызываем методы динамическим связыванием по признаку своего атрибута MyAttribute" + Environment.NewLine);
            foreach (var item in methodInfos)
                {
              
                var tt = item.GetCustomAttributes(atr,false);

                /*параметрі*/
                ParameterInfo[] parameterInfos = item.GetParameters();
                /* ищем методі с кастомнім аттрибутом и 2 инт параметрами*/
                if (
tt.Count()!=0
               &&
                parameterInfos.Count() == 2 &&
                parameterInfos.All(q => q.ParameterType.FullName == "System.Int32")
                ) {

               /* візіваем методі динамическим связіванием*/
                    object[] temp = new object[] { 100, 50 };
                    Console.WriteLine(item.Invoke(v, temp));



                    }
                }












   



            }
        }


    }