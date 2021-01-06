using System;

namespace ConsoleApp1.DelegateDemo2
{
    class DelegateDemo2
    {
        public DelegateDemo2()
        {
            Heater heater = new Heater(); //热水器
            Alarm alarm = new Alarm(); //警报器
            heater.BoilEvent += alarm.MakeAlert; //注册方法
            heater.BoilEvent += (new Alarm()).MakeAlert; //给匿名对象注册方法
            heater.BoilEvent += new Heater.BoilHandler(alarm.MakeAlert); //也可以这么注册
            heater.BoilEvent += Display.ShowMsg; //注册静态方法
            heater.BoilWater(); //烧水，会自动调用注册过对象的方法
        }
    }

    /// <summary>
    /// 热水器
    /// </summary>
    public class Heater
    {
        private int temperature; //温度
        public delegate void BoilHandler(int param); //声明委托
        public event BoilHandler BoilEvent; //声明事件

        /// <summary>
        /// 烧水
        /// </summary>
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //如果有对象注册
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature); //调用所有注册对象的方法
                    }
                }
            }
        }
    }

    /// <summary>
    /// 警报器
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 发出警报
        /// </summary>
        /// <param name="param"></param>
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经{0}度了：", param);
        }
    }

    /// <summary>
    /// 显示器
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="param"></param>
        public static void ShowMsg(int param)
        {
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
        }
    }
}
