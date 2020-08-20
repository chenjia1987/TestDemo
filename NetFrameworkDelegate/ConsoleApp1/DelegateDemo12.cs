using System;

namespace ConsoleApp1.DelegateDemo12
{
    public delegate void Delegate1(string message);


    public class DelegateDemo12
    {
        public void DelegateTest()
        {
            Delegate1 delegate1 = new Delegate1(DelegateMethod); //实例化委托
            delegate1("调用委托1！"); //调用委托

            Delegate1 delegate2 = DelegateMethod; //实例化委托
            delegate2("调用委托2！"); //调用委托

            Delegate1 delegate3 = DelegateMethod; //实例化委托
            delegate3 += DelegateMethod; //实例化委托
            delegate3("调用委托3！"); //调用委托

            Delegate1 delegate4 = delegate (string message) //匿名实例化委托
            {
                Console.WriteLine(message);
            };
            delegate4("调用委托4！");

            Delegate1 delegate5 = (x) => //Lambda 实例化委托
            {
                Console.WriteLine(x);
            };
            delegate5("调用委托5！");
        }
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public void EventTest()
        {
            Class1.Delegate2 delegate2 = new Class1.Delegate2(DelegateMethod);
            delegate2 += DelegateMethod;
            delegate2("delegate2 委托测试！");

            Class1 class1 = new Class1();
            class1.Event += DelegateMethod;
            class1.ConsoleWriteLine("事件调用！");
        }

    }

    public class Class1
    {
        public delegate void Delegate2(string message);

        public event Delegate2 Event;


        public void ConsoleWriteLine(string message)
        {
            Event(message);
        }
    }

}
