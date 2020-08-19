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
            Demo1 demo1 = new Demo1();

            new Class1().Fun1(demo1);
            new Class2().Fun1(demo1);
            Console.WriteLine(demo1.ID);

        }
    }

    public class Demo1
    {
        public int ID { get; set; } = 0;

        public string Name { get; set; }
    }

    public class Class1
    {
        public void Fun1(Demo1 demo1)
        {
            demo1.ID += 1;
        }
    }

    public class Class2
    {
        public void Fun1(Demo1 demo1)
        {
            demo1.ID += 1;
        }
    }
}
