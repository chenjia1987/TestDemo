using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 定义委托
    /// </summary>
    /// <param name="message"></param>
    public delegate void Del(string message);

    public class DelegateDemo
    {
        public DelegateDemo()
        {
            //实例化委托
            Del handler = DelegateMethod;
            //调用委托
            handler("Hello World");
        }

        //Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }


        public static void ConsoleWriteLine(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}
