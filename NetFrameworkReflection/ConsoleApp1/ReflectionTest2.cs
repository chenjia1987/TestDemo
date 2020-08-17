using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestMain2
    {
        public void Fun1()
        {
            const int iterations = 100;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < iterations; i++) //对照方法
            {
                Console.WriteLine("Hello, world!");
            }

            TimeSpan elasped = DateTime.Now - startTime;
            Console.WriteLine("Looping Elapsed milliseconds:" + elasped.TotalMilliseconds + "for {0} iterations", iterations);

            //使用反射发送
            ReflectionTest2 t = new ReflectionTest2();
            //计算所用时间
            startTime = DateTime.Now;
            for (int i = 0; i < iterations; i++)
            {
                t.DoOperation();
            }
            elasped = DateTime.Now - startTime;
            Console.WriteLine("Looping Elapsed milliseconds:" + elasped.TotalMilliseconds + "for {0} iterations", iterations);
            Console.ReadLine();
        }
    }
    public class ReflectionTest2
    {
        Type theType = null; //保存动态生成并编译的类的 type 对象。
        object theClass = null; //保存动态生成类的实例。

        public void DoOperation()
        {
            if (theType == null) //未初始化测试
            {
                GenerateCode();
            }

            object[] arguments = new object[0];
            theType.InvokeMember(
                "SayHello", //要调用的方法名
                BindingFlags.Default | BindingFlags.InvokeMethod, // Binding 标志
                null, //使用默认 Binding 对象
                theClass, //在 theClass 实例上调用此方法
                arguments //调用方法时的参数数组
                );

        }

        private void GenerateCode()
        {
            string fileName = "Test"; //文件名
            //打开文件，如果不存在，则创建
            Stream s = File.Open(fileName + ".cs", FileMode.Create);
            //创建一个 StreamWriter 来写入数据
            StreamWriter wrtr = new StreamWriter(s);
            //写入动态创建类的源代码
            wrtr.WriteLine("// 动态创建 Test 类");
            string className = "TestClass"; //类名
            wrtr.WriteLine(" using System;");
            wrtr.WriteLine(" class {0}", className);
            wrtr.WriteLine("{");
            wrtr.WriteLine("\tpublic void SayHello()");
            wrtr.WriteLine("\t{");
            wrtr.WriteLine("\t\t Console.WriteLine(\"\tHello, world!\");");
            wrtr.WriteLine("\t}");
            wrtr.WriteLine("}");
            //关闭 StreamWriter 和文件
            wrtr.Close();
            s.Close();

            #region 启动进程编译文件
            //指定参数
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe"; //启动 cmd.exe
            //cmd.exe 的参数，/c - close，完成后关闭；后为参数，
            //指定 cmd.exe 使用 csc 来编译刚才生成的源文件
            string compileString = @"/c C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /optimize+ /target:library {0}.cs";
            psi.Arguments = String.Format(compileString, fileName);
            //运行时的风格 - 最小化
            psi.WindowStyle = ProcessWindowStyle.Minimized;
            //启动进程
            Process proc = Process.Start(psi);
            //指定当前在此进程退出前等待
            proc.WaitForExit();
            #endregion

            //从编译好的 dll 文件 load 一个 Assembly
            Assembly a = Assembly.LoadFrom(@"E:\@TestProgram\TestDemo\NetFrameworkReflection\ConsoleApp1\bin\Debug\" + fileName + ".dll");
            theClass = a.CreateInstance(className); //创建类的实例
            theType = a.GetType(className); //取得此类实例的类型
            //删除源文件
            //File.Delete(fileName + ".cs");
        }
    }
}