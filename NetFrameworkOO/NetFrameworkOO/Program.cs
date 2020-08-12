using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFrameworkOO
{
    class Program
    {
        static void Main(string[] args)
        {
            C c = new C() { ID = 1, Name = "A" };
            B b = c;


            Console.WriteLine(b.Name);
        }
    }

    public class A
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class B : A
    { 
    
    }

    public class C : B { }
}
