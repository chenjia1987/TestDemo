using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionTest1.ListMethods(typeof(Person));
            ReflectionTest1.ListFields(typeof(Person));
            ReflectionTest1.ListProperties(typeof(Person));
            ReflectionTest1.ListInterface(typeof(Person));
            ReflectionTest1.ListEvents(typeof(Person));
            ReflectionTest1.ListOtherInfo(typeof(Person));
        }

        
    }
}
