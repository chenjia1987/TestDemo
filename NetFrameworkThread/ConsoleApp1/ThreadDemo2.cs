using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ThreadDemo2
    {
        /// <summary>
        /// 异步使用
        /// </summary>
        public static void Fun1()
        {
            Console.WriteLine("----------主程序开始，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);


            Action<string> action = t =>
            {
                for (int k = 0; k < 1000000000; k++)
                { }
                Console.WriteLine("当前参数是{1},当前线程是{0}", Thread.CurrentThread.ManagedThreadId, t);
            };

            action.BeginInvoke("异步参数", null, null);


            Console.WriteLine("----------主程序结束，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);
        }

        public static void Fun2()
        {
            Console.WriteLine("----------主程序开始，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);

            Action<string> action = t =>
            {
                for (int k = 0; k < 1000000000; k++)
                { }
                Console.WriteLine("当前参数是{1},当前线程是{0}", Thread.CurrentThread.ManagedThreadId, t);
            };

            AsyncCallback callback = t =>
            {
                Console.WriteLine("这里是回调函数 当前线程是{0}", Thread.CurrentThread.ManagedThreadId);
            };

            action.BeginInvoke("异步参数", callback, null);

            Console.WriteLine("----------主程序结束，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);
        }

        public static void Fun3()
        {            
            Console.WriteLine("----------主程序开始，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);

            Action<string> action = t =>
            {
                for (int k = 0; k < 1000000000; k++)
                { }
                Console.WriteLine("当前参数是{1},当前线程是{0}", Thread.CurrentThread.ManagedThreadId, t);
            };

            AsyncCallback callback = t =>
            {
                Console.WriteLine(t.AsyncState);
                Console.WriteLine("这里是回调函数 当前线程是{0}", Thread.CurrentThread.ManagedThreadId);
            };

            action.BeginInvoke("异步参数", callback, "无名小虾");

            Console.WriteLine("----------主程序结束，线程ID是{0}-----------------", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
