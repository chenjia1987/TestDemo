using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDemo listDemo = new ListDemo();

            //listDemo.Fun1();
            //listDemo.Fun2();
            //listDemo.Fun3();
            //listDemo.Fun4();
            //listDemo.Fun5();
            //listDemo.Fun6();
            listDemo.Fun7();
        }
    }

    public class ListDemo
    {
        //构造函数
        //声明一个 List 对象，该实例为空并且具有默认初始容量。
        List<string> list1 = new List<string>();
        //声明一个 List 对象，该实例为空并且具有指定的初始容量。
        List<string> list2 = new List<string>(5);
        //声明一个 List 对象，该实例有两个默认元素。
        List<string> list3 = new List<string>
        {
            ".Net Framework",
            ".Net Core",
            ".Net Framework",
            "ADO.Net",
            "C#"
        };

        /// <summary>
        /// 列表属性
        /// </summary>
        public void Fun1()
        {
            //字段/属性
            //获取指定索引处的元素。
            Console.WriteLine(list3[1]);
            //设置指定索引处的元素。
            list3[1] = "C#";
            Console.WriteLine(list3[1]);
            //获取 List 中包含的元素数。
            Console.WriteLine(list3.Count);
            //获取或设置该内部数据结构在不调整大小的情况下能够容纳的元素总数。
            Console.WriteLine(list3.Capacity);
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        public void Fun2()
        {
            //将对象添加到 List 的结尾处。
            list3.Add("ADO.Net");
            Console.WriteLine(list3[2]);
            //将指定集合的元素添加到 List 的末尾。
            string[] array = { "ASP.Net", "ASP.Net Core" };
            list3.AddRange(array);

            //将元素插入 List 的指定索引处。
            list3.Insert(1, "ADO.NET");
            //将集合中的元素插入 List 的指定索引处。
            list3.InsertRange(4, new string[] { "1", "2", "3" });
        }

        /// <summary>
        /// 查找元素
        /// </summary>
        public void Fun3()
        {
            //使用默认的比较器在整个已排序的 List 中搜索元素，并返回该元素从零开始的索引。
            Console.WriteLine(list3.BinarySearch(".Net Core"));


            //确定某元素是否在 List 中。
            Console.WriteLine(list3.Contains(".Net Core"));

            //确定 List 是否包含与指定谓词定义的条件匹配的元素。
            Console.WriteLine(list3.Exists(x => x == ".Net"));

            //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 List 中的第一个匹配元素。
            Console.WriteLine(list3.Find(x => x == ".Net Core"));

            //检索与指定谓词定义的条件匹配的所有元素。
            var list4 = list3.FindAll(x => x.Contains(".Net"));

            bool ListFind(string str)
            {
                if (str.Length > 3)
                {
                    return true;
                }
                return false;
            }
            var list5 = list3.FindAll(ListFind);

            //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 List 中第一个匹配元素的从零开始的索引。
            Console.WriteLine(list3.FindIndex(x => x == "C#"));
            //搜索与指定谓词所定义的条件相匹配的元素，并返回 List 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引。
            Console.WriteLine(list3.FindIndex(1, x => x == ".Net Framework"));
            //搜索与指定谓词所定义的条件相匹配的一个元素，并返回 List 中从指定的索引开始、包含指定元素个数的元素范围内第一个匹配项的从零开始的索引。
            Console.WriteLine(list3.FindIndex(1, 1, x => x == ".Net Framework"));

            //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 1 中的最后一个匹配元素。
            Console.WriteLine(list3.FindLast(x => x == ".Net Framework"));

            //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 List 中最后一个匹配元素的从零开始的索引。
            Console.WriteLine(list3.FindLastIndex(x => x == ".Net Framework"));
            //搜索与由指定谓词定义的条件相匹配的元素，并返回 List 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引。
            Console.WriteLine(list3.FindLastIndex(3, x => x == ".Net Framework"));

            //搜索指定对象并返回 List 中从指定索引开始并包含指定元素数的这部分元素中第一个匹配项的从零开始索引。
            Console.WriteLine(list3.IndexOf(".Net Framework", 0, 3));
            //搜索指定对象并返回 List 中从指定索引到最后一个元素这部分元素中第一个匹配项的从零开始索引。
            Console.WriteLine(list3.IndexOf(".Net Framework", 2));
            //搜索指定的对象，并返回整个 List 中第一个匹配项的从零开始的索引。
            Console.WriteLine(list3.IndexOf("C#"));

            //搜索指定对象并返回整个 List 中最后一个匹配项的从零开始索引。
            Console.WriteLine(list3.LastIndexOf(".Net Framework"));
            //搜索指定对象并返回 List 中从第一个元素到指定索引这部分元素中最后一个匹配项的从零开始的索引。
            Console.WriteLine(list3.LastIndexOf(".Net Framework", 0));
            //搜索指定对象并返回 List 中到指定索引为止包含指定元素数的这部分元素中最后一个匹配项的从零开始索引。
            Console.WriteLine(list3.LastIndexOf(".Net Framework", 2, 3));

            //确定 List 中的每个元素是否都与指定谓词定义的条件匹配。
            bool flag = list3.TrueForAll(str =>
            {
                if (str.Length > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            Console.WriteLine(flag);
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        public void Fun4()
        {
            //从 List 中移除特定对象的第一个匹配项。
            list3.Remove("C#");
            //移除与指定的谓词所定义的条件相匹配的所有元素。
            list3.RemoveAll(x => x.Contains(".Net"));
            //移除 List 的指定索引处的元素。
            list3.RemoveAt(2);
            //从 List 中移除一定范围的元素。
            list3.RemoveRange(0, 1);

            //从 List 中移除所有元素。
            list3.Clear();
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Fun5()
        {
            Random r = new Random();

            List<People> list = new List<People>();
            for (int i = 0; i < 10; i++)
            {
                int j = r.Next(0, 10);
                list.Add(new People() { ID = j, Name = $"name{j}" });
            }
            Console.WriteLine("排序前：");
            foreach (var item in list) Console.WriteLine(item.ToString());
            //使用指定的 Comparison，对整个 List 中的元素进行排序。
            list.Sort((x, y) => { return x.ID.CompareTo(y.ID); });
            Console.WriteLine("排序后：");
            foreach (var item in list) Console.WriteLine(item.ToString());

            //使用 LinQ 扩展方法排序
            //list = list.OrderBy(o => o.ID).ToList(); //升序
            //list = list.OrderByDescending(o => o.ID).ToList(); //降序

            List<PeopleComparable> listComparable = new List<PeopleComparable>();
            for (int i = 0; i < 10; i++)
            {
                int j = r.Next(0, 10);
                listComparable.Add(new PeopleComparable() { ID = j, Name = $"name{j}" });
            }
            Console.WriteLine("排序前：");
            foreach (var item in listComparable) Console.WriteLine(item.ToString());
            //使用默认比较器对整个 List 中的元素进行排序。
            listComparable.Sort();
            Console.WriteLine("排序后：");
            foreach (var item in listComparable) Console.WriteLine(item.ToString());

            List<PeopleIComparer> listIComparer = new List<PeopleIComparer>();
            for (int i = 0; i < 10; i++)
            {
                int j = r.Next(0, 10);
                listIComparer.Add(new PeopleIComparer() { ID = j, Name = $"name{j}" });
            }
            Console.WriteLine("排序前：");
            foreach (var item in listIComparer) Console.WriteLine(item.ToString());

            //使用指定的比较器对 List 中某个范围内的元素进行排序。
            listIComparer.Sort(0, 5, new PeopleIComparer());
            Console.WriteLine("排序后：");
            foreach (var item in listIComparer) Console.WriteLine(item.ToString());

            //使用指定的比较器对整个 List 中的元素进行排序。
            listIComparer.Sort(new PeopleIComparer());
            Console.WriteLine("排序后：");
            foreach (var item in listIComparer) Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// 翻转列表
        /// </summary>
        public void Fun6()
        {
            //将指定范围中元素的顺序反转。
            list3.Reverse(0, 2);
            //将整个 List 中元素的顺序反转。
            list3.Reverse();
        }

        /// <summary>
        /// 列表比较
        /// </summary>
        public void Fun7()
        {           
            People people1 = new People { ID = 1, Name = "Turbo" };
            People people2 = new People { ID = 2, Name = "Peanut" };
            //List<People> peopleList1 = new List<People> { people1, people2 };
            //List<People> peopleList2 = new List<People> { people1, people2 };
            //Console.WriteLine(peopleList1.SequenceEqual(peopleList2));

            List<People> peopleList3 = new List<People> { people1, people2 };
            List<People> peopleList4 = new List<People> {
                new People { ID = 1, Name = "Turbo" },
                new People { ID = 2, Name = "Peanut" }
            };
            Console.WriteLine(peopleList3.SequenceEqual(peopleList4));
        }

        /// <summary>
        /// 其他
        /// </summary>
        public void Fun10()
        {
            //返回当前集合的只读包装器。
            var list4 = list3.AsReadOnly();
            //list4[0] = "C#"; //无法为属性或索引器“ReadOnlyCollection<string>.this[int]”赋值 - 它是只读的

            string[] array = { "1", "2", "3", "4", "5" };
            //从目标数组的指定索引处开始，将整个 List 复制到兼容的一维数组。
            list3.CopyTo(array, 2);
            //从目标数组的指定索引处开始，将元素的范围从 System.Collections.Generic.List`1 复制到兼容的一维数组。
            list3.CopyTo(1, array, 1, 2);
            //从目标数组的开头开始，将整个 List 复制到兼容的一维数组。
            list3.CopyTo(array);

            //将 List 的元素复制到新数组中。
            var list5 = list3.ToArray();

            Console.WriteLine(list3.Capacity);
            //将容量设置为 List 中元素的实际数目（如果该数目小于某个阈值）。
            list3.TrimExcess();
            Console.WriteLine(list3.Capacity);
        }
    }

    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "ID:" + ID + "   Name:" + Name;
        }
    }

    public class PeopleComparable : IComparable<PeopleComparable>
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CompareTo(PeopleComparable other)
        {
            if (null == other)
            {
                return 1;//空值比较大，返回1
            }
            return this.ID.CompareTo(other.ID);//升序
            //return other.ID.CompareTo(this.ID);//降序
        }

        public override string ToString()
        {
            return "ID:" + ID + "   Name:" + Name;
        }
    }

    public class PeopleIComparer : IComparer<PeopleIComparer>
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Compare(PeopleIComparer x, PeopleIComparer y)
        {
            return x.ID.CompareTo(y.ID);//升序
        }

        public override string ToString()
        {
            return "ID:" + ID + "   Name:" + Name;
        }
    }
}