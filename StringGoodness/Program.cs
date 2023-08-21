using System;

namespace StringGoodness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] counts = new int[n];
            for (int i = 0; i < n; i++)
            {
                counts[i] = Convert.ToInt32(Console.ReadLine());
            }

            long goodness = 0;
            for (int i = 0; i < n - 1; i++)
            {
                goodness += Math.Min(counts[i], counts[i + 1]);
            }

            Console.WriteLine(goodness);
        }
    }
}