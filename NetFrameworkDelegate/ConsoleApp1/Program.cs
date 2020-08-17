using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DelegateDemo delegateDemo = new DelegateDemo();

            MethodWithCallback(1, 2, DelegateDemo.ConsoleWriteLine);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
    }
}
