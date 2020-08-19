using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DelegateDemo9
{
    class DelegateDemo9
    {
        public DelegateDemo9()
        {
			Publisher pub = new Publisher();
			Subscriber1 sub1 = new Subscriber1();
			Subscriber2 sub2 = new Subscriber2();
			Subscriber3 sub3 = new Subscriber3();

			pub.MyEvent += new DemoEventHandler(sub1.OnEvent);
			pub.MyEvent += new DemoEventHandler(sub2.OnEvent);
			pub.MyEvent += new DemoEventHandler(sub3.OnEvent);
			pub.DoSomething();
		}

		public static object[] FireEvent(Delegate del, params object[] args)
		{
			List<object> objList = new List<object>();
			if (del != null)
			{
				Delegate[] delArray = del.GetInvocationList();
				foreach (Delegate method in delArray)
				{
					try
					{
						// 使用DynamicInvoke方法触发事件
						object obj = method.DynamicInvoke();
						if (obj != null) objList.Add(obj);
					}
					catch { }
				}
			}
			return objList.ToArray();
		}
	}

	//定义委托
	public delegate void DemoEventHandler();

	public class Publisher
	{
		public event DemoEventHandler MyEvent;

		//做某些其他的事情
		public void DoSomething()
		{
			//if (MyEvent != null)
			//{
			//    try
			//    {
			//        MyEvent();
			//    }
			//    catch (Exception e)
			//    {
			//        Console.WriteLine("Exception: {0}", e.Message);
			//    }
			//}

			//if (MyEvent != null)
			//{
			//    Delegate[] delArray = MyEvent.GetInvocationList();
			//    foreach (Delegate del in delArray)
			//    {
			//        DemoEventHandler method = (DemoEventHandler)del; //强制转换为具体的委托类型
			//        try
			//        {
			//            method();
			//        }
			//        catch (Exception e)
			//        {
			//            Console.WriteLine("Exception: {0}", e.Message);
			//        }
			//    }
			//}

			//if (MyEvent != null)
			//{
			//    Delegate[] delArray = MyEvent.GetInvocationList();
			//    foreach (Delegate del in delArray)
			//    {
			//        DemoEventHandler method = (DemoEventHandler)del; //强制转换为具体的委托类型
			//        try
			//        {
			//            del.DynamicInvoke();
			//        }
			//        catch (Exception e)
			//        {
			//            Console.WriteLine("Exception: {0}", e.Message);
			//        }
			//    }
			//}

			DelegateDemo9.FireEvent(MyEvent, this, EventArgs.Empty);
		}

		
	}

	public class Subscriber1
	{
		public void OnEvent()
		{
			Console.WriteLine("Subscriber1 Invoked!");
		}
	}

	public class Subscriber2
	{
		public void OnEvent()
		{
			throw new Exception("Subscriber2 Failed");
		}
	}

	public class Subscriber3
	{
		public void OnEvent()
		{
			Console.WriteLine("Subscriber3 Invoked!");
		}
	}
}
