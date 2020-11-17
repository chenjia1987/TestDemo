using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log4NetFactory;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new ExecutionEngineException("这是一个异常");
            }
            catch (ExecutionEngineException ex)
            {
                LogHelper.write(ex, LogHelper.LogMessageType.Error);
            }
        }
    }
}
