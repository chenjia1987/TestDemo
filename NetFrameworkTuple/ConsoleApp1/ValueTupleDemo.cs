using System;

namespace ConsoleApp1
{
    /// <summary>
    /// 值元组
    /// </summary>
    public class ValueTupleDemo
    {
        public ValueTupleDemo()
        {
            Fun1();
        }

        public void Fun1()
        {
            ValueTuple<int, double> tuple1 = new ValueTuple<int, double>(1, 2.0);
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine($"tuple1 类型为：{tuple1.GetType()}");
            Console.WriteLine();

            (int, double, double, double, int, int, double, double, double, int) tuple2 = (1, 2.0d, 3.0d, 4.0d, 5, 6, 7.0d, 8.0d, 9.0d, 10);
            Console.WriteLine(tuple2.Item10);
            Console.WriteLine($"tuple2 类型为：{tuple2.GetType()}");
            Console.WriteLine();

            (double, int) tuple3 = (4.5, 3);
            Console.WriteLine(tuple3.Item1);
            Console.WriteLine($"tuple3 类型为：{tuple3.GetType()}");
            Console.WriteLine();

            (double Sum, int Count) tuple4 = (4.5, 3);
            Console.WriteLine($"Sum of {tuple4.Count} elements is {tuple4.Sum}.");
            Console.WriteLine($"tuple4 类型为：{tuple4.GetType()}");
            Console.WriteLine();

            var tuple5 = (Sum: 4.5, Count: 3);
            Console.WriteLine($"Sum of {tuple5.Count} elements is {tuple5.Sum}.");
            Console.WriteLine($"tuple5 类型为：{tuple5.GetType()}");
            Console.WriteLine();
        }
    }
}
