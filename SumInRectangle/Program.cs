using System;
using System.Collections.Generic;
using System.Linq;

namespace SumInRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine()!.Split(' ').Select(str => Convert.ToInt32(str)).ToArray();

            (int n, int m, int k) = (inputs[0], inputs[1], inputs[2]);
            var matrix = new int[n, m];
            var sumMatrix = new long[n, m];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine()!.Split(' ').Take(m)
                    .Select(str => Convert.ToInt32(str)).ToArray();

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = row[j];
                    if (i == 0 && j == 0)
                    {
                        sumMatrix[i, j] = matrix[i, j];
                    }
                    else if (j == 0)
                    {
                        sumMatrix[i, j] = sumMatrix[i - 1, j] + matrix[i, j];
                    }
                    else if (i == 0)
                    {
                        sumMatrix[i, j] = sumMatrix[i, j - 1] + matrix[i, j];
                    }
                    else
                    {
                        sumMatrix[i, j] = sumMatrix[i, j - 1] + sumMatrix[i - 1, j] 
                            - sumMatrix[i - 1, j - 1] + matrix[i, j];
                    }
                }
            }

            var requests = new List<(int X1, int Y1, int X2, int Y2)>();
            for (int i = 0; i < k; i++)
            {
                var row = Console.ReadLine()!.Split(' ')
                    .Select(str => Convert.ToInt32(str)).ToArray();

                var request = (X1: row[0], Y1: row[1], X2: row[2], Y2: row[3]);
                requests.Add(request);
            }

            foreach (var request in requests)
            {
                long sum = sumMatrix[request.X2 - 1, request.Y2 - 1];

                if (request.X1 > 1)
                {
                    sum -= sumMatrix[request.X1 - 2, request.Y2 - 1];
                }

                if (request.Y1 > 1)
                {
                    sum -= sumMatrix[request.X2 - 1, request.Y1 - 2];

                    if (request.X1 > 1)
                    {
                        sum += sumMatrix[request.X1 - 2, request.Y1 - 2];
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}