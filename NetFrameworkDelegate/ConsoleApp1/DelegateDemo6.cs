using System;

namespace ConsoleApp1.DelegateDemo6
{
    class DelegateDemo6
    {
		public DelegateDemo6()
		{
			Publishser publishser = new Publishser();
			Subscriber subscriber = new Subscriber();
			publishser.Register(subscriber.OnNumberChanged);
			publishser.DoSomething();
		}
	}

	// 定义委托
	public delegate string GeneralEventHandler();

	// 定义事件发布者
	public class Publishser
	{
		private event GeneralEventHandler NumberChanged; //声明一个私有事件
		
		// 注册事件
		public void Register(GeneralEventHandler method)
		{
			NumberChanged = method;
		}
		// 取消注册
		public void UnRegister(GeneralEventHandler method)
		{
			NumberChanged -= method;
		}

		public void DoSomething()
		{
			// 做某些其余的事情
			if (NumberChanged != null) // 触发事件
			{
				string rtn = NumberChanged();
				Console.WriteLine("Return: {0}", rtn); // 打印返回的字符串，输出为Subscriber3
			}
		}
	}

	// 定义事件订阅者
	public class Subscriber
	{
		public string OnNumberChanged()
		{
			return "Subscriber1";
		}
	}
}
