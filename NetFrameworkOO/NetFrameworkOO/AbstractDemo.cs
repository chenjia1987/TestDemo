using System;
using System.Data.SqlClient;

namespace NetFrameworkOO.AbstractDemo
{
    public abstract class AbstractClass1
    {

        public abstract int Accessor1 { get; set; }

        public void NonAbstractMethod()
        {
            Console.WriteLine("Non-Abstract Method");
        }
        public abstract void AbstractMethod();
    }

    public class Class1 : AbstractClass1
    {
        public override int Accessor1 { get; set; }

        public override void AbstractMethod()
        {
            Console.WriteLine("Abstract method");
        }
    }

    public class Class7 : AbstractClass1
    {
        public override int Accessor1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 使用 New 覆盖抽象类中的实例化方法。
        /// </summary>
        public new void NonAbstractMethod()
        {
            Console.WriteLine("Class7.NonAbstractMethod");
        }

        public override void AbstractMethod()
        {
            throw new NotImplementedException();
        }
    }

    #region 抽象类继承抽象类
    public abstract class AbstractParent
    {
        public abstract void AbstractMethod1();
        public abstract void AbstractMethod2();
    }

    /// <summary>
    /// 子抽象类部分实现
    /// </summary>
    public abstract class AbstractChildren : AbstractParent
    {
        public override void AbstractMethod1()
        {
            Console.WriteLine("Abstract method #1");
        }
    }

    public class Class2 : AbstractChildren
    {
        public override void AbstractMethod2()
        {
            Console.WriteLine("Abstract method #2");
        }
    }
    #endregion

    #region 抽象类继承非抽象类
    public class Class3
    {
        public void Method1()
        {
            Console.WriteLine("Method of a non-abstract class");
        }
    }
    public abstract class AbstractClass2 : Class3 //Inherits from an non-abstract class
    {
        public abstract void AbstractMethod1();
    }
    public class Class4 : AbstractClass2 //must implement base class abstract methods
    {
        public override void AbstractMethod1()
        {
            Console.WriteLine("Abstract method #1 of Class4");
        }
    }
    #endregion

    #region 抽象类继承接口
    public interface IInterface1
    {
        void Method1();
    }
    public abstract class AbstractClass3 : IInterface1
    {
        public abstract void Method1();
    }    
    public class Class5 : AbstractClass3
    {
        public override void Method1()
        {
            Console.WriteLine("Abstract method #1 of Class5");
        }
    }
    public abstract class AbstractClass4 : IInterface1
    {
        public void Method1()
        {
            Console.WriteLine("Method of IInterface1");
        }
    }
    public class Class6 : AbstractClass4 { }
    #endregion
}