using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TypeConverterDemo
    {
        public void fun1()
        {
            Console.WriteLine(new DateTimeConverter().ConvertFromString("1981-08-24"));
        }

        public void fun2()
        {
            Console.WriteLine(new TimeSpanConverter().ConvertFromString("02:40"));
        }
    }
}
