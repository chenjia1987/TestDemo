using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread ts = new Thread(new ThreadStart(ThreadDemo.ThreadProc));//创建一个线程
            ts.Start();//启动线程
        }
    }
}
