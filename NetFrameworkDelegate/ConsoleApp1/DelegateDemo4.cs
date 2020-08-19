using System;

namespace ConsoleApp1.DelegateDemo4
{
    class DelegateDemo4
    {
		public DelegateDemo4()
		{
			Publishser pub = new Publishser();
			Subscriber sub = new Subscriber();
			pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
			pub.DoSomething(); //应该通过 DoSomething() 来触发事件
			//pub.NumberChanged(100); //但可以被这样直接调用，对委托变量的不恰当使用
		}
    }

	/// <summary>
	/// 定义委托
	/// </summary>
	/// <param name="count"></param>
	public delegate void NumberChangedEventHandler(int count);

	/// <summary>
	/// 定义事件发布者
	/// </summary>
	public class Publishser
	{
		private int count;
		//public NumberChangedEventHandler NumberChanged; //声明委托变量
		public event NumberChangedEventHandler NumberChanged; // 声明一个事件
		public void DoSomething()
		{
			//在这里完成一些工作 ...
			if (NumberChanged != null)
			{
				//触发事件
				count++;
				NumberChanged(count);
			}
		}
	}

	/// <summary>
	/// 定义事件订阅者
	/// </summary>
	public class Subscriber
	{
		public void OnNumberChanged(int count)
		{
			Console.WriteLine("Subscriber notified: count = {0}", count);
		}
	}
}
