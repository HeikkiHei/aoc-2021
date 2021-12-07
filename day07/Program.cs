using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("data.txt").Split(",");
            int[] ints = input.Select(int.Parse).ToArray();
            Part1(ints);
            Part2(ints);

        }

        static double Median(int[] ints)
        {
            List<int> sorted = ints.OrderBy(x => x).ToList();
            double mid = (sorted.Count - 1) / 2.0;
            return (sorted[(int)(mid)] + sorted[(int)(mid + 0.5)]) / 2;
        }

        static void Part1(int[] ints)
        {
            double median = Median(ints);
            Console.WriteLine(median);
            int sum = 0;
            foreach (int squid in ints)
            {
                sum += Math.Abs(squid - (int)median);
            }
            Console.WriteLine(sum);
        }

        static void Part2(int[] ints)
        {
            int average = Convert.ToInt32(ints.Average());
            Console.WriteLine(average);
            int sum = 0;
            foreach (int squid in ints)
            {
                int n = (Math.Abs(squid - average + 1));
                int result = (int)(0.5 * n * (n + 1));
                sum += result;
            }
            Console.WriteLine(sum);
        }


    }
}
