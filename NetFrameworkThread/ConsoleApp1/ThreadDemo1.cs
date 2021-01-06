using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ThreadDemo1
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Fun1()
        {
            Thread ts = new Thread(new ThreadStart(ThreadDemo1.ThreadProc)); //创建一个线程，并调用静态方法
            ts.Start(); //启动线程
        }

        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}