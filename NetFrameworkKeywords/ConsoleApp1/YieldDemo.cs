using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class YieldDemo
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "Wrold";
        }

        public YieldDemo()
        {

        }

        public void Fun1()
        {
            YieldDemo yieldDemo = new YieldDemo();

            foreach (var s in yieldDemo)
            {
                Console.WriteLine(s);
            }
        }        
    }
}
