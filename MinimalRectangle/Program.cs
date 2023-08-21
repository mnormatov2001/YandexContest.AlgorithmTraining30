using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = Convert.ToInt32(Console.ReadLine());
            var items = new List<(int X, int Y)>();
            for (int i = 0; i < k; i++)
            {
                var item = Console.ReadLine()!.Split(' ')
                    .Select(str => Convert.ToInt32(str)).ToArray();
                var point = (X: item[0], Y: item[1]);
                items.Add(point);
            }

            var minX = items.MinBy(item => item.X).X;
            var minY = items.MinBy(item => item.Y).Y;
            var maxX = items.MaxBy(item => item.X).X;
            var maxY = items.MaxBy(item => item.Y).Y;

            Console.WriteLine($"{minX} {minY} {maxX} {maxY}");
        }
    }
}