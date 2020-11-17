using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Log4NetFactory;

namespace WindowsService1
{
    static class Program
    {
        public static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            LogFactory.LogStart(BasePath);
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};
            ServiceBase.Run(ServicesToRun);
            
        }
    }
}