using System;
using System.Collections;

namespace ConsoleApp1
{
    public class ReflectionTest1
    {
        /// <summary>
        /// 获取所有方法
        /// </summary>
        /// <param name="t"></param>
        public static void ListMethods(Type t)
        {
            Console.WriteLine("\n该类型的所有方法：");
            foreach (var methodInfo in t.GetMethods())
            {
                Console.WriteLine($"\t方法名：{methodInfo}\t；方法返回值类型：{methodInfo.ReturnType.FullName}。");
                foreach (var parameterInfo in methodInfo.GetParameters())
                {
                    Console.WriteLine($"\t\t参数名；{parameterInfo.Name}；\t 参数类型{parameterInfo.ParameterType}");
                }
            }
        }

        /// <summary>
        /// 获取所有字段
        /// </summary>
        /// <param name="t"></param>
        public static void ListFields(Type t)
        {
            Console.WriteLine("\n该类型的所有字段：");
            foreach (var fieldInfo in t.GetFields())
            {
                Console.WriteLine($"\t字段名：{fieldInfo.Name}");
            }
        }

        /// <summary>
        /// 获取所有属性
        /// </summary>
        /// <param name="t"></param>
        public static void ListProperties(Type t)
        {
            Console.WriteLine("\n该类型的所有属性：");
            foreach (var propertyInfo in t.GetProperties())
            {
                Console.WriteLine($"\t属性名：{propertyInfo.Name}");
            }
        }

        /// <summary>
        /// 获取所有接口
        /// </summary>
        /// <param name="t"></param>
        public static void ListInterface(Type t)
        {
            Console.WriteLine("\n该类型的所有接口：");
            foreach (var interfaceInfo in t.GetInterfaces())
            {
                Console.WriteLine($"\t属性名：{interfaceInfo.Name}");
            }
        }

        /// <summary>
        /// 获取所有事件
        /// </summary>
        /// <param name="t"></param>
        public static void ListEvents(Type t)
        {
            Console.WriteLine("\n该类型的所有事件：");
            foreach (var eventInfo in t.GetEvents())
            {
                Console.WriteLine($"\t事件名：{eventInfo.Name}");
            }
        }

        /// <summary>
        /// 其他信息
        /// </summary>
        /// <param name="t"></param>
        public static void ListOtherInfo(Type t)
        {
            Console.WriteLine($"基类名称：{t.BaseType}");
            Console.WriteLine($"基类的基类的名称：{t.BaseType.BaseType}");
            Console.WriteLine($"是一个类吗？：{t.IsClass}");
            Console.WriteLine($"是一个抽象类吗？：{t.IsAbstract}");
        }
    }

    public class BasePerson
    {
        public void BasePulic() { }
        private void BasePrivate() { }
    }

    public class Person : BasePerson, IEnumerable
    {
        private string name = "name";
        public int age = 20;
        Array Children = null;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person() { }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void AddAge()
        {
            this.age++;
        }

        public delegate void PersonNameHandler(string x);
        public event PersonNameHandler OnChangeName;

        public void ChangeName(string name)
        {
            this.name = name;
        }

        public void ChangeNameAndAge(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public IEnumerator GetEnumerator()
        {
            return this.Children.GetEnumerator();
        }
    }
}
