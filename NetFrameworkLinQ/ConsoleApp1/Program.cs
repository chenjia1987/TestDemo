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
            Dictionary<int, Dictionary<int, string>> dic = new Dictionary<int, Dictionary<int, string>>()
            {
                { 372, new Dictionary<int, string>(){
                    { 1, "689" },
                    { 101, "691"}
                } },
                { 419, new Dictionary<int, string>(){
                    { 1, "690" },
                    { 101, "692"}
                } }
            };


            //Dictionary<int, string> dic = new Dictionary<int, string>() { 
            //    { 1, "Test1"},
            //    { 2, "Test2"},
            //    { 3, "Test3"},
            //};

            Console.WriteLine(((dic.FirstOrDefault(x => x.Key == 1)).Value)?.FirstOrDefault(x => x.Key == 1).Value);
        }
    }
}
