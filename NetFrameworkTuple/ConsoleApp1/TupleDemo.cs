using System;

namespace ConsoleApp1
{
    /// <summary>
    /// 元组
    /// </summary>
    public class TupleDemo
    {
        public TupleDemo()
        {
            Fun1();
            //Fun2();
        }

        /// <summary>
        /// 声明
        /// </summary>
        public void Fun1()
        {
            Tuple<int, double, int, double, int, double> tuple1 = new Tuple<int, double, int, double, int, double>(1, 2.0d, 3, 4.0d, 5, 6.0d);
            Console.WriteLine(tuple1.Item4);

            var tuple2 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int, int, int>(8, 9, 10));
            Console.WriteLine($"Item 1: {tuple2.Item1}, Item 10: {tuple2.Rest.Item3}");


        }

        /// <summary>
        /// 匿名方法
        /// </summary>
        public void Fun2()
        {
            var xs = new[] { 4, 7, 9 };
            var limits = FindMinMax(xs);
            Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
            // Output:
            // Limits of [4 7 9] are 4 and 9

            var ys = new[] { -9, 0, 67, 100 };
            var (minimum, maximum) = FindMinMax(ys);
            Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
            // Output:
            // Limits of [-9 0 67 100] are -9 and 100
            

            (int min, int max) FindMinMax(int[] input)
            {
                if (input is null || input.Length == 0)
                {
                    throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
                }

                var min = int.MaxValue;
                var max = int.MinValue;
                foreach (var i in input)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                    if (i > max)
                    {
                        max = i;
                    }
                }
                return (min, max);
            }
        }
    }
}