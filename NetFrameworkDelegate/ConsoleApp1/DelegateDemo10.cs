using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1.DelegateDemo10
{
    class DelegateDemo10
    {
        public DelegateDemo10()
        {
			Publisher pub = new Publisher();
			Subscriber1 sub1 = new Subscriber1();
			Subscriber2 sub2 = new Subscriber2();
			Subscriber3 sub3 = new Subscriber3();

			pub.MyEvent += new EventHandler(sub1.OnEvent);
			pub.MyEvent += new EventHandler(sub2.OnEvent);
			pub.MyEvent += new EventHandler(sub3.OnEvent);

			pub.DoSomething();      // 触发事件

			Console.WriteLine("\nControl back to client!"); // 返回控制权

		}

		// 触发某个事件，以列表形式返回所有方法的返回值
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
						object obj = method.DynamicInvoke(args);
						if (obj != null) objList.Add(obj);
					}
					catch 
					{
						
					}
				}
			}
			return objList.ToArray();
		}

	}

	public class Publisher
	{
		public event EventHandler MyEvent;
		public void DoSomething()
		{
			//做某些其他的事情
			Console.WriteLine("DoSomething invoked!");
			DelegateDemo10.FireEvent(MyEvent, this, EventArgs.Empty); //触发事件
		}
	}

	public class Subscriber1
	{
		public void OnEvent(object sender, EventArgs e)
		{
			Thread.Sleep(TimeSpan.FromSeconds(3));
			Console.WriteLine("Waited for 3 seconds, subscriber1 invoked!");
		}
	}
	public class Subscriber2
	{
		public void OnEvent(object sender, EventArgs e)
		{
			Console.WriteLine("Subscriber2 immediately Invoked!");
		}
	}
	public class Subscriber3
	{
		public void OnEvent(object sender, EventArgs e)
		{
			Thread.Sleep(TimeSpan.FromSeconds(2));
			Console.WriteLine("Waited for 2 seconds, subscriber2 invoked!");
		}
	}

}