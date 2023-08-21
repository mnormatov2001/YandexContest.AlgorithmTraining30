using System;

namespace ControlWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            int pRow = Convert.ToInt32(Console.ReadLine());
            int pPlace = Convert.ToInt32(Console.ReadLine());
            int pIndexNumber = pRow * 2 - 2 + pPlace;

            int vIndexNumber1 = pIndexNumber + k;
            int vIndexNumber2 = pIndexNumber - k;

            var vRow1 = vIndexNumber1 / 2 + vIndexNumber1 % 2;
            int vPlace1 = 1;
            if (vIndexNumber1 % 2 == 0)
                vPlace1 = 2;

            var vRow2 = vIndexNumber2 / 2 + vIndexNumber2 % 2;
            int vPlace2 = 1;
            if (vIndexNumber2 % 2 == 0)
                vPlace2 = 2;

            if (vIndexNumber1 <= n && vIndexNumber2 >= 1)
            {
                Console.WriteLine(pRow - vRow2 < vRow1 - pRow ? $"{vRow2} {vPlace2}" : $"{vRow1} {vPlace1}");
            }

            else if (vIndexNumber1 <= n)
            {
                Console.WriteLine($"{vRow1} {vPlace1}");
            }

            else if (vIndexNumber2 >= 1)
            {
                Console.WriteLine($"{vRow2} {vPlace2}");
            }

            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}