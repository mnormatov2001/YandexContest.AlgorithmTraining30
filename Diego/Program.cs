using System;
using System.Linq;

namespace Diego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var stickers = Console.ReadLine()!.Split(' ')
                .Select(str => Convert.ToInt32(str)).OrderBy(i => i).Distinct().ToArray();

            int k = Convert.ToInt32(Console.ReadLine());
            var pItems = Console.ReadLine()!.Split(' ').Select(str => Convert.ToInt32(str));

            foreach (int p in pItems)
            {
                if (stickers[0] >= p)
                {
                    Console.WriteLine(0);
                    continue;
                }

                int left = 0;
                int right = stickers.Length - 1;
                while (left < right)
                {
                    int medium = (left + right + 1) / 2;
                    if (stickers[medium] < p)
                        left = medium;
                    else
                        right = medium - 1;
                }

                Console.WriteLine(left + 1);
            }
        }
    }
}