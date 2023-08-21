using System;
using System.IO;

namespace TextBeauty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k;
            string text;
            using (var reader = new StreamReader(new FileStream("input.txt", FileMode.Open)))
            {
                k = Convert.ToInt32(reader.ReadLine());
                text = reader.ReadLine();
            }

            var maxBeauty = GetMaxBeauty(text, k);
            Console.WriteLine(maxBeauty);
        }

        private static int GetMaxBeauty(string str, int k)
        {
            if (k >= str.Length)
                return str.Length;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            int maxBeauty = 0;
            foreach (var ch in alphabet)
            {
                if (!str.Contains(ch))
                    continue;

                int left = 0;
                int n = k;
                int right = left;
                int beauty = 0;
                bool doing = true;
                while (doing && left < str.Length)
                {
                    while (right < str.Length)
                    {
                        if (str[right] == ch)
                        {
                            beauty++;
                        }
                        else
                        {
                            if (n == 0)
                                break;
                            
                            n--;
                            beauty++;
                        }

                        right++;
                        if (beauty > maxBeauty)
                            maxBeauty = beauty;

                        if (right == str.Length - 1)
                            doing = false;
                    }

                    while (doing && left < str.Length && str[left] == ch)
                    {
                        left++;
                        beauty--;
                    }

                    left++;
                    beauty--;
                    n++;
                }
            }

            return maxBeauty;
        }

        private static int GetMaxBeautySecond(string str, int k)
        {
            if (k >= str.Length)
                return str.Length;

            int maxBeauty = 0;
            int i = 0;
            bool doing = true;
            while (doing && i < str.Length)
            {
                int n = k;
                int beauty = 1;
                int nextIndex = 0;
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        beauty++;
                    }
                    else
                    {
                        if (n == 0)
                        {
                            if (beauty > maxBeauty)
                                maxBeauty = beauty;

                            if (j == str.Length - 1)
                                doing = false;

                            i = nextIndex;
                            break;
                        }

                        if (nextIndex == 0)
                            nextIndex = j;

                        n--;
                        beauty++;
                    }

                    if (beauty > maxBeauty)
                        maxBeauty = beauty;

                    if (j == str.Length - 1)
                        doing = false;
                }
            }
            return maxBeauty;
        }
    }
}