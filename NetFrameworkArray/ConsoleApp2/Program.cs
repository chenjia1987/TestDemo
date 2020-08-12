using DictionaryTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YieIDTest;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            //DictionaryTestDemo.DemoTest();
            HelloCollectionDemo.DemoTest();
        }
    }

}

namespace ArrayTest
{

    public class ArrayTestDemo
    {
        public static void DemoTest()
        {

        }
    }

    public class ArrayTest
    {
        public void OneDimensionalArrayTest()
        {

        }
    }
}

namespace DictionaryTest
{
    public class DictionaryTestDemo
    {
        public static void DemoTest()
        {
            DictionaryTest dictionaryTest = new DictionaryTest();
            dictionaryTest.StringDictionaryTest();
        }
    }
    public class DictionaryTest
    {
        public void StringDictionaryTest()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Key1", "Value5");
            dic.Add("Key2", "Value4");
            dic.Add("Key3", "Value3");
            dic.Add("Key4", "Value2");
            dic.Add("Key5", "Value1");

            foreach (var item in dic)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }
        }
    }
}

namespace YieIDTest
{
    public class HelloCollectionDemo
    {
        public static void DemoTest()
        {
            HelloCollection hello = new HelloCollection();

            foreach (var s in hello)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class HelloCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "Wrold";
        }
    }
}
