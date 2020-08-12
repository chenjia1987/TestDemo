using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFrameworkOO.InterfaceDemo
{
    #region 接口的定义属性方法事件以及继承类的申明
	public delegate void Delegate1(string name);
	public interface Interface1
	{
		string Accessor1 { get; set; }
		void Method2();
		event Delegate1 Event1;
	}

    public class Class1 : Interface1
    {
		string a;
		public Class1(string b)
		{
			a = b;
		}
		public string Accessor1
		{
			get { return a; }
			set { a = value; this.Event1(value); }
		}
		public event Delegate1 Event1;
        public void Method2()
        {
            throw new NotImplementedException();
        }
	}
	#endregion

	#region 继承父接口就要继承父接口的所有属性和方法
	interface Interface2 
	{ 
		int Accessor1 { get; set; }
	}
	interface Interface3
	{
		int Count(int i, int j);
	}
	interface Interface4 : Interface2, Interface3 
	{
	
	}
	public class Class2 : Interface4
	{
		int a;
		public int Accessor1
		{
			get { return a; }
			set { a = value; }
		}
		//定义类I_D中的方法Count
		public int Count(int i, int j)
		{
			return i + j + a;
		}
	}
	#endregion

	#region 外部类中对多重继承中的成员访问问题
	public interface Interface5
	{
		string Method1(string A);
	}
	public interface Interface6 : Interface5
	{
		new string Method1(string A);
	}
	public interface Interface7 : Interface5
	{
		string Method2();
	}
	public interface Interface8 : Interface6, Interface7
	{
	};
	public class Class3
	{
		public string Test(Interface8 id)
		{
			id.Method2();
			id.Method1("Interface6 接口的方法");
			((Interface5)id).Method1("Interface5 接口的方法");
			((Interface7)id).Method1("Interface5 接口的方法");
			((Interface8)id).Method1("Interface6 接口的方法");
			return String.Empty;
		}
	}
	#endregion

	#region 显式实现接口成员不能从类实例访问，但可以在类内部访问。当类使用者不需要使用该接口成员时以及多个接口之间有同名成员时，这个就特别有用。
	public interface Interface9
	{
		string Accessor1 { get; set; }
		string Method1();
	}

	public class Class4 : Interface9
	{
		private string name;
		public Class4()
		{
			name = "天神";
		}
		
		string Interface9.Accessor1
		{
			get { return name; }
			set { name = value; }
		}
		string Interface9.Method1()
		{
			string more = name + ",你好!";
			return more;
		}
	}
	#endregion

	#region 类继承类中的接口方法提供为虚的，表示接受任何扩充类的复写，复写可用override关键字。
	public interface Interface10
	{
		string Method1();
		string Method2();
	}

	public class Class5 : Interface10
	{
		public virtual string Method1() { return "Class5.Method1"; }
		public virtual string Method2() { return "Class5.Method2"; }
	}

	public class Class6 : Class5, Interface10
	{		
		string Interface10.Method1() { return "Interface10.Method1"; }
		string Interface10.Method2() { return "Interface10.Method2"; }
	}

	public class Class7 : Class5
	{
		public override string Method1() { return "Class7.Method1"; }
		public override string Method2() { return "Class7.Method2"; }
	}

	public class Class8 : Class5
	{
		public new string Method1() { return "Class8.Method1"; }
		public new string Method2() { return "Class8.Method2"; }
	}
	#endregion

	#region 不同接口同名成员的访问
	public interface Interface11
	{
		string Method1();
	}
	public interface Interface12
	{
		string Method1();
	}
	public class Class9 : Interface11, Interface12
	{
		public string Method1()
		{
			return "隐式实现";
		}

		string Interface12.Method1()
		{
			return "显式实现";
		}
	}
	#endregion

	#region 多个接口同名成员属性和方法的访问（一个属性一个方法）
	public interface Interface13
	{
		string Accessor1 { get; set; }
	}
	public interface Interface14 : Interface13 
	{ 
		new string Accessor1(); 
	}
    public class Class10 : Interface14
    {
		string Interface14.Accessor1()
		{
			throw new Exception("The method or operation is not implemented.");
		}
		string Interface13.Accessor1
		{
			get { throw new Exception("The method or operation is not implemented."); }
			set { throw new Exception("The method or operation is not implemented."); }
		}
	}
	#endregion

	#region 显式实现的方法无法使用修饰符，同样可以使用虚方法Virtaul；在这个显式实现中调用另一个方法，然后这个被调用的方法再是虚方法。
	public interface Interface15
	{
		int Age { get; set; }
		string GetName();
		string GetPwd();
	}

	public class Class11 : Interface15
	{
		protected int age;
		protected string name;
		protected string pwd;
		public Class11(int a, string n, string p)
		{
			age = a;
			name = n;
			pwd = p;
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public virtual string GetName() { return name; }
		public virtual string GetPwd() { return pwd; }
	}

	public class Class12 : Class11
	{
		public Class12(int a, string n, string p) : base(a, n, p)
		{
			age = a;
			name = n;
			pwd = p;
		}
		public override string GetName() { return "用户名：" + name; }
		public override string GetPwd() { return "密码：" + pwd; }
	}

	public class Class13 : Interface15
	{
		protected int age;
		protected string name;
		protected string pwd;
		public Class13(int a, string n, string p)
		{
			age = a;
			name = n;
			pwd = p;
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public string GetName() { return name; }
		public string GetPwd() { return pwd; }
	}

	public class Class14 : Class13, Interface15
	{
		public Class14(int a, string n, string p) : base(a, n, p)
		{
			age = a;
			name = n;
			pwd = p;
		}
		public new string GetName() { return "用户名：" + name; }
		public new string GetPwd() { return "密码：" + pwd; }
	}
	#endregion

	#region 用抽象类来继承接口
	interface Interface16
	{
		void Method1();
		void Method2();
	}
	abstract class Class15 : Interface16
	{
		public void Method1() 
		{ 

		}
		public abstract void Method2();
	}
	class Class16 : Class15
	{
		public override void Method2() 
		{
		
		}
	}
	#endregion
}
