using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace WebApplication1
{
    public class Global: System.Web.HttpApplication
    {
        private static ILog log = LogManager.GetLogger(typeof(Global));
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            log.Error("发生未捕获异常", HttpContext.Current.Error);
        }
    }

    public class class1
    {
        public void function1()
        {
            //GetLogger参数为代码所在类的类型
            //方式一
            LogManager.GetLogger(typeof(test)).Debug("额滴神呀");

            //方式二
            ILog log = LogManager.GetLogger(typeof(test));
            log.Debug("偶滴神呀");
            log.Warn("系统内存即将不足，小于5M");
            log.Error("系统崩溃了");
        }
    }

    internal class test
    {
    }
}