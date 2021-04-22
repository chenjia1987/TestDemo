using System;

namespace ConsoleApp1
{
    class StringDemo
    {
        readonly string s1 = "123";
        readonly string s2 = "123";

        /// <summary>
        /// 声明
        /// </summary>
        public void Fun1()
        {

        }

        /// <summary>
        /// 比较
        /// </summary>
        public void StringCompare()
        {
            //比较两个指定的 System.String 对象，并返回一个指示二者在排序顺序中的相对位置的整数。
            Console.WriteLine(String.Compare(s1, s2));

        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public void StringConcat()
        {
            Console.WriteLine(String.Concat("arg0", 1, "arg2", 1.0));
            Console.WriteLine(String.Join(" ", new[] { 1, 2, 3, 4 }));
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public void StringFormat()
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
            Console.WriteLine($"填充后的字符串为：\n{"Visual C# Express".PadLeft("Visual C# Express".Length + 4, '_')}");

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
        public void StringIndexOf()
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
        public void StringSplit()
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
        public void StringSubstring()
        {
            //从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
            Console.WriteLine("从第七个字符开始往后取2个字符：\n" + "Visual C# Express".Substring(7, 2));
        }

        /// <summary>
        /// 剪切
        /// </summary>
        public void StringTrim()
        {
            Console.WriteLine("  去除空格后的样式 ".Trim());
            Console.WriteLine("苏州市".TrimEnd('州', '市'));
        }
    }
}