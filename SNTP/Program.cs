using System;

namespace SNTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strA = Console.ReadLine();
            var strB = Console.ReadLine();
            var strC = Console.ReadLine();
            var timeA = TimeOnly.Parse(strA);
            var timeB = TimeOnly.Parse(strB);
            var timeC = TimeOnly.Parse(strC);
            var delay = timeC - timeA;
            var seconds = delay.TotalSeconds;
            var kek = TimeSpan.FromSeconds(Math.Ceiling(seconds/2.0));
            var result = timeB.Add(kek);
            Console.WriteLine(result.ToString("HH:mm:ss"));
        }
    }
}