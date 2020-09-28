using System;

namespace ConsoleApp1.DelegateDemo12
{
    #region 定义委托类型
    public delegate void Delegate1(string message); //委托
    public delegate int Delegate2(int x, int y); //带返回类型委托
    public delegate T Delegate3<T>(T x, T y); //泛型委托
    #endregion

    public class DelegateDemo12
    {
        /// <summary>
        /// 委托示例
        /// 实例化委托
        /// </summary>
        public void DelegateTest()
        {
            Class1 class1 = new Class1();

            //命名方法实例化委托
            Delegate1 delegate1 = new Delegate1(class1.Method1); //实例化委托，调用 Class1 实例化方法
            delegate1("调用委托1！"); //调用委托

            //推断方式实例化委托
            Delegate1 delegate2 = class1.Method1; //实例化委托，调用 Class1 实例化方法
            delegate2("调用委托2！"); //调用委托

            Delegate2 delegate3 = Class1.Method2; //实例化委托，调用 Class1 静态方法
            Console.WriteLine(delegate3(1, 2)); //调用委托

            Delegate3<float> delegate4 = class1.Method3; //实例化委托，调用 Class1 实例化方法
            Console.WriteLine(delegate4(1f, 10f)); //调用委托

            //匿名函数方式实例化委托
            Delegate1 delegate5 = delegate (string message) //实例化委托
            {
                Console.WriteLine(message);
            };
            delegate5("调用委托5！");

            //Lambda 表达式方式实例化委托
            Delegate1 delegate6 = x => //实例化委托
            {
                Console.WriteLine(x);
            };
            delegate6("调用委托6！");
            Delegate3<string> delegate7 = (x, y) => //实例化委托
            {
                return x + y;
            };
            Console.WriteLine(delegate7("调用", "委托7！"));

            //Func：封装一个方法，该方法具有一个参数，且返回由 TResult 参数指定的类型的值。
            Func<string, string> func1 = (x) =>
            {
                return x;
            };
            Console.WriteLine(func1("调用 Func<> 委托！"));

            Func<string, string, string> func2 = (x, y) =>
            {
                return x + y;
            };            
            Console.WriteLine(func2("调用 Func<> 委托，", "包含两个参数"));


            //Action：封装一个方法，该方法只有一个参数并且不返回值。
            Action<int> action1 = (x) =>
            {
                Console.WriteLine($"调用 Action<> 委托！参数为：{x}");
            };            
            action1(1);

            //Predicate：表示一种方法，该方法定义一组条件并确定指定对象是否符合这些条件。
            Predicate<double> predicate1 = x =>
            {
                return x.GetType() == typeof(int);
            };
            Console.WriteLine(predicate1(1));
        }

        /// <summary>
        /// 事件示例
        /// </summary>
        public void EventTest()
        {
            Class2 class2 = new Class2();
            class2.Event += new Class1().Method1;
            class2.CallEvent("事件调用！");


            Class2.Delegate2 delegate2 = new Class1().Method1;
            delegate2("delegate2 委托测试！");
        }

    }

    public class Class1
    {
        /// <summary>
        /// 实例化方法
        /// </summary>
        /// <param name="message"></param>
        public void Method1(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 静态方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Method2(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// 实例化方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public float Method3(float x, float y)
        {
            return x + y;
        }
    }

    public class Class2
    {
        public delegate void Delegate2(string message); //定义委托

        public event Delegate2 Event; //定义事件

        public void CallEvent(string message)
        {
            Event(message); //调用事件
        }
    }
}
