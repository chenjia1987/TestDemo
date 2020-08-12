using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DateTimeDemo
    {
        /// <summary>
        /// 声明
        /// </summary>
        public void fun1()
        {
            //时间戳
            Console.WriteLine(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds());
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
}
