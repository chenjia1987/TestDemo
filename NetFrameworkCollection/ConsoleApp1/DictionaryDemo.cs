using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DictionaryDemo
    {

        Dictionary<string, string> dic1 = new Dictionary<string, string>()
        {
            {"Key1", "Values5" },
            {"Key2", "Values4" },
            {"Key3", "Values3" },
            {"Key4", "Values2" },
            {"Key5", "Values1" },
        };
        Dictionary<int, string> dic2 = new Dictionary<int, string>(5);

        Dictionary<int, string> dic3 = new Dictionary<int, string>(new Dictionary<int, string>() { { 1, "Value1" }, { 2, "Value2"} });

        public DictionaryDemo()
        {            
            //Fun2();
            //Fun3();
            Fun1();
            //Fun4();
        }

        /// <summary>
        /// 访问字典
        /// </summary>
        public void Fun1()
        {
            foreach (var item in dic1)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }

            Console.WriteLine();

            foreach (string item in dic1.Keys)
            {
                Console.WriteLine("键是：{0} 值是：{1}", item, dic1[item]);
            }

            Console.WriteLine(dic1["Key1"]);

            Console.WriteLine(dic1.Count());
        }

        /// <summary>
        /// 增加元素
        /// </summary>
        public void Fun2()
        {
            dic1.Add("Key6", "Values0");
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        public void Fun3()
        {
            dic1.Remove("Key3"); //删除指定元素

            //dic1.Clear(); //清空字典
        }

        /// <summary>
        /// 查找
        /// </summary>
        public void Fun4()
        {
            //判断是否包含指定键
            if (dic1.ContainsKey("Key1"))
            {
                Console.WriteLine("包含此键");
            }
            else
            {
                Console.WriteLine("不包含此键");
            }

            //判断是否包含指定值
            if (dic1.ContainsValue("Values2"))
            {
                Console.WriteLine("包含此值");
            }
            else
            {
                Console.WriteLine("不包含此值");
            }
        }
    }
}
