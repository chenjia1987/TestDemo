using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConvertDemo
    {

        /// <summary>
        /// 装箱拆箱
        /// </summary>
        public void fun1()
        {
            //DateTimeConverter
        }

        /// <summary>
        /// 隐式转换和显式转换
        /// </summary>
        public void fun2()
        {
            int i = (int)1.2f;
            Console.WriteLine(i);
        }

        /// <summary>
        /// 时间类型转换
        /// </summary>
        public void fun3()
        {
            //将日期和时间的指定字符串表示形式转换为等效的日期和时间值。
            Console.WriteLine(Convert.ToDateTime("2020-08-11"));

            Console.WriteLine(Convert.ToDateTime("2020 08 11", new DateTimeFormatInfo() { ShortDatePattern = "yyyyMMdd" }));
        }
    }
}
