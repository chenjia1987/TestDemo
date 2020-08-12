using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDemo stringDemo = new StringDemo();
            //stringDemo.fun1();
            //stringDemo.fun2();
            //stringDemo.fun3();
            //stringDemo.fun4();

            DateTimeDemo dateTimeDemo = new DateTimeDemo();
            dateTimeDemo.fun1();
            //dateTimeDemo.fun2();

            ConvertDemo convertDemo = new ConvertDemo();
            //convertDemo.fun1();
            //convertDemo.fun2();
            //convertDemo.fun3();

            TypeConverterDemo typeConverterDemo = new TypeConverterDemo();
            //typeConverterDemo.fun1();
            //typeConverterDemo.fun2();
        }
    }

    

    

    

    

}
