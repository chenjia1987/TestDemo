using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDemo stringDemo = new StringDemo();
            //stringDemo.fun1();
            //stringDemo.fun2();
            //stringDemo.fun3();
            //stringDemo.fun4();

            DateTimeDemo dateTimeDemo = new DateTimeDemo();
            //dateTimeDemo.fun1();
            //dateTimeDemo.fun2();

            ConvertDemo convertDemo = new ConvertDemo();
            //convertDemo.fun1();
            //convertDemo.fun2();
            //convertDemo.fun3();

            TypeConverterDemo typeConverterDemo = new TypeConverterDemo();
            //typeConverterDemo.fun1();
            //typeConverterDemo.fun2();
        }
    }

    class StringDemo
    {
        string s1 = "123";
        string s2 = "123";

        /// <summary>
        /// 声明
        /// </summary>
        public void fun1()
        {

        }

        /// <summary>
        /// 比较
        /// </summary>
        public void fun2()
        {
            //比较两个指定的 System.String 对象，并返回一个指示二者在排序顺序中的相对位置的整数。
            Console.WriteLine(String.Compare(s1, s2));

        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public void fun3()
        {
            Console.WriteLine(String.Concat("arg0", 1, "arg2", 1.0));
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public void fun4()
        {
            //将指定字符串中的一个或多个格式项替换为指定对象的字符串表示形式。
            //Console.WriteLine(String.Format("我是格式化的方法：{0}", "123"));
            //Console.WriteLine("{0:D}格式化：" + String.Format("{0:D}", DateTime.Now));
            //Console.WriteLine("{0:d}格式化：" + String.Format("{0:d}", DateTime.Now));

            //Console.WriteLine("{0:F}格式化：" + String.Format("{0:F}", DateTime.Now));
            //Console.WriteLine("{0:f}格式化：" + String.Format("{0:f}", DateTime.Now));

            //Console.WriteLine("{0:g}格式化：" + String.Format("{0:g}", DateTime.Now));
            //Console.WriteLine("{0:gg}格式化：" + String.Format("{0:gg}", DateTime.Now));
            //Console.WriteLine("{0:G}格式化：" + String.Format("{0:G}", DateTime.Now));

            //Console.WriteLine("{0:m}格式化：" + String.Format("{0:m}", DateTime.Now));


            //Console.WriteLine("{0:r}格式化：" + String.Format("{0:r}", DateTime.Now));
            //Console.WriteLine("{0:R}格式化：" + String.Format("{0:R}", DateTime.Now));

            //Console.WriteLine("{0:s}格式化：" + String.Format("{0:s}", DateTime.Now));

            //Console.WriteLine("{0:t}格式化：" + String.Format("{0:t}", DateTime.Now));
            //Console.WriteLine("{0:T}格式化：" + String.Format("{0:T}", DateTime.Now));
            //Console.WriteLine("{0:%t}格式化：" + String.Format("{0:%t}", DateTime.Now));
            //Console.WriteLine("{0:tt}格式化：" + String.Format("{0:tt}", DateTime.Now));

            //Console.WriteLine("{0:u}格式化：" + String.Format("{0:u}", DateTime.Now));
            //Console.WriteLine("{0:U}格式化：" + String.Format("{0:U}", DateTime.Now));

            Console.WriteLine("{0:y}格式化：" + String.Format("{0:y}", DateTime.Now));
            Console.WriteLine("{0:Y}格式化：" + String.Format("{0:Y}", DateTime.Now));






            ////返回一个新字符串，该字符串通过在此实例中的字符左侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符右对齐。
            //Console.WriteLine($"填充后的字符串为：\n{"Visual C# Express".PadLeft("Visual C# Express".Length + 4, '_')}");

            ////返回一个新字符串，该字符串通过在此字符串中的字符右侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符左对齐。
            //Console.WriteLine($"填充后的字符串为：\n{"Visual C# Express".PadRight("Visual C# Express".Length + 4, '_')}");

            ////返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
            //Console.WriteLine("我是一个字符串".Replace("一个", "改变之后的"));

            ////返回此字符串转换为小写形式的副本。
            //Console.WriteLine("ABC".ToLower());
            ////返回此字符串转换为大写形式的副本。
            //Console.WriteLine("abc".ToUpper());
        }

        /// <summary>
        /// 索引查找
        /// </summary>
        public void fun5()
        {
            //报告指定字符串在此实例中的第一个匹配项的从零开始的索引。
            Console.WriteLine("123@456,789@0".IndexOf("@"));
            //报告指定字符串在此实例中的最后一个匹配项的从零开始的索引的位置。
            Console.WriteLine("123@456,789@0".LastIndexOf("@"));

            //报告指定 Unicode 字符数组中的任意字符在此实例中第一个匹配项的从零开始的索引。
            Console.WriteLine("123@456,789@0".IndexOfAny(new Char[] { '#', ',', '@' }));

            //报告在 Unicode 数组中指定的一个或多个字符在此实例中的最后一个匹配项的从零开始的索引的位置。
            Console.WriteLine("123@456,789@0".LastIndexOfAny(new Char[] { '#', ',', '@' }));
        }

        /// <summary>
        /// 拆分
        /// </summary>
        public void fun6()
        {
            //基于数组中的字符将字符串拆分为多个子字符串。
            String[] arr = "123,456,789,0".Split(',');
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }

        }

        /// <summary>
        /// 截取
        /// </summary>
        public void fun7()
        {
            //从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
            Console.WriteLine("从第七个字符开始往后取2个字符：\n" + "Visual C# Express".Substring(7, 2));
        }
    }

    class DateTimeDemo
    {
        /// <summary>
        /// 声明
        /// </summary>
        public void fun1()
        {

        }

        /// <summary>
        /// 格式化
        /// </summary>
        public void fun2()
        {
            //使用指定的格式和区域性特定格式信息，将日期和时间的指定字符串表示形式转换为其等效的 System.DateTime。 字符串表示形式的格式必须与指定的格式完全匹配。
            //Console.WriteLine(DateTime.ParseExact("20110526", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture));
            //Console.WriteLine(DateTime.ParseExact("20110526", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));

            //将日期和时间的指定字符串表示形式转换为其 System.DateTime 等效项，并返回一个指示转换是否成功的值。
            DateTime.TryParse("2asdf6", out DateTime dateTime);
            Console.WriteLine(dateTime);

            DateTime dt = Convert.ToDateTime("20100101".Substring(0, 4) + "-" + "20100101".Substring(4, 2) + "-" + "20071107".Substring(6, 2));

        }
    }

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

    class TypeConverterDemo
    {
        public void fun1()
        {
            Console.WriteLine(new DateTimeConverter().ConvertFromString("1981-08-24"));
        }

        public void fun2()
        {
            Console.WriteLine(new TimeSpanConverter().ConvertFromString("02:40"));
        }
    }

}
