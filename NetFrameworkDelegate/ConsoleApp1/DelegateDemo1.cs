using System;

namespace ConsoleApp1.DelegateDemo1
{
    /// <summary>
    /// 定义委托
    /// </summary>
    /// <param name="name"></param>
    public delegate void GreetingDelegate(string name);

    public class DelegateDemo1
    {
        public DelegateDemo1()
        {
            Fun1();
            Fun2();
            Fun3();
            Fun4();
        }

        static GreetingDelegate greetingDelegate1, greetingDelegate2; //声明委托变量
        static GreetingManager greetingManager = new GreetingManager();

        /// <summary>
        /// 实例化委托
        /// </summary>
        public void Fun1()
        {
            greetingDelegate1 = greetingManager.EnglishGreeting; //实例化委托
            greetingDelegate2 = greetingManager.ChineseGreeting; //实例化委托
            greetingDelegate1("Jimmy Zhang"); //调用委托
            greetingDelegate2("张子阳"); //调用委托


            greetingManager.GreetPeople("Jimmy Zhang", greetingDelegate1);
            greetingManager.GreetPeople("张子阳", greetingDelegate2);

        }

        /// <summary>
        /// 实例化委托
        /// </summary>
        public void Fun2()
        {
            greetingDelegate1 = greetingManager.EnglishGreeting; //先给委托类型的变量赋值
            greetingDelegate1 += greetingManager.ChineseGreeting; //给此委托变量再绑定一个方法
            //将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            greetingDelegate1("Jimmy Zhang");
        }

        /// <summary>
        /// 实例化委托
        /// </summary>
        public void Fun3()
        {
            GreetingDelegate greetingDelegate1 = new GreetingDelegate(greetingManager.EnglishGreeting);
            greetingDelegate1 += greetingManager.ChineseGreeting; //给此委托变量再绑定一个方法
            greetingDelegate1("Jimmy Zhang");

            Console.WriteLine();

            greetingDelegate1 -= greetingManager.EnglishGreeting; //取消对 EnglishGreeting 方法的绑定
            greetingDelegate1("Jimmy Zhang");
        }




        /// <summary>
        /// 实例化委托
        /// </summary>
        public void Fun4()
        {
            //greetingManager.MakeGreet = greetingManager.EnglishGreeting; //编译错误1
            greetingManager.MakeGreet += greetingManager.ChineseGreeting;
            greetingManager.GreetPeople("Jimmy Zhang");
        }
    }

    public class GreetingManager
    {
        /// <summary>
        /// 声明事件
        /// </summary>
        public event GreetingDelegate MakeGreet;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void GreetPeople(string name)
        {
            MakeGreet(name); //调用事件
        }

        /// <summary>
        /// 使用委托作为参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="MakeGreeting"></param>
        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        public void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }
}
