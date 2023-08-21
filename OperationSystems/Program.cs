using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OperationSystems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m;
            int n;

            var parts = new List<(int A, int B)>();

            using (var reader = new StreamReader(new FileStream("input.txt", FileMode.Open)))
            {
                n = Convert.ToInt32(reader.ReadLine());
                m = Convert.ToInt32(reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    var line = reader.ReadLine();
                    if (line ==  null)
                        break;

                    var part = line.Split(' ').Select(str => Convert.ToInt32(str)).ToArray();
                    var lastPart = (A: part[0], B: part[1]);

                    var brokenPartsIndexes = new List<int>();

                    for (int j = 0; j < parts.Count; j++)
                    {
                        var other = parts[j];
                        if (lastPart.A <= other.B && lastPart.B >= other.A)
                        {
                            brokenPartsIndexes.Add(j);
                        }
                    }

                    for (int k = 0; k < brokenPartsIndexes.Count; k++)
                    {
                        parts.RemoveAt(brokenPartsIndexes[k] - k);
                    }

                    parts.Add(lastPart);
                }
            }

            Console.WriteLine(parts.Count);
        }
    }
}