using System;
using System.Linq;
using System.Text;

namespace YandexContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder(10000);
            while (Console.ReadLine() is { } line)
            {
                builder.Append(line);
            }

            var text = builder.ToString();
            PrintBarChart(text);
        }

        private static void PrintBarChart(string str)
        {
            var result = str.Where(c => c != ' ' && c != '\n' && c != '\r')
                .OrderBy(c => (int)c)
                .GroupBy(c => c)
                .Select(g => (g.Key, g.Count()))
                .ToArray();

            var maxItem = result.MaxBy(tuple => tuple.Item2);
            int maxHeight = maxItem.Item2;

            for (int i = 0; i < maxItem.Item2; i++)
            {
                foreach ((_, int count) in result)
                {
                    Console.Write(count >= maxHeight - i ? "#" : " ");
                }
                Console.WriteLine();
            }

            foreach ((char key, _)  in result) 
                Console.Write(key);
            Console.WriteLine();
        }
    }
}