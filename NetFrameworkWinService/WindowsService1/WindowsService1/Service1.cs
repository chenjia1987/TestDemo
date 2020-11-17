using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using Log4NetFactory;
using System.Threading;

namespace WindowsService1
{

    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            System.Timers.Timer t = new System.Timers.Timer(1000); //实例化Timer类，设置间隔时间为10000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapse);//到达时间的时候执行事件；
            t.AutoReset = false; //设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件；
            t.Start();

            

            // Thread ts = new Thread(new ThreadStart(ThreadExample.ThreadProc));//创建一个线程
            // ts.Start();//启动线程
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {

        }

        protected void TimeElapse(object source, System.Timers.ElapsedEventArgs e)
        {
            //new Thread(p =>
            //{
            //    try
            //    {
            //        do
            //        {
            //            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch(); //开启计时器
            //            stopwatch.Start();

            //            for (int i = 0; i < 10; i++)
            //            {
            //                LogFactory.Write(i.ToString());
            //                Thread.Sleep(1000);
            //            }

            //            stopwatch.Stop();

            //            LogFactory.Write(stopwatch.ElapsedMilliseconds.ToString());

            //        } while (true);
            //        // RecommendTeacher();
            //    }
            //    catch (Exception error)
            //    {
            //    }
            //}).Start();


            //FileStream fs = new FileStream(@"d:\timetick.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter m_streamWriter = new StreamWriter(fs);
            //m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            //m_streamWriter.WriteLine("过了一秒 " + DateTime.Now.ToString() + "\n");
            //m_streamWriter.Flush();
            //m_streamWriter.Close();
            //fs.Close();
        }


        public class ThreadExample
        {
            public static void ThreadProc()
            {
                do
                {
                    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch(); //开启计时器
                    stopwatch.Start();

                    for (int i = 0; i < 10; i++)
                    {
                        LogFactory.Write(i.ToString());
                        Thread.Sleep(1000);
                    }

                    stopwatch.Stop();

                    LogFactory.Write(stopwatch.ElapsedMilliseconds.ToString());

                } while (true);
            }
        }
    }
}
