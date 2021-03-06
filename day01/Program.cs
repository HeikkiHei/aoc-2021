using System;
using System.IO;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            int[] ints = Array.ConvertAll(lines, int.Parse);
            Part1(ints);
            Part2(ints);


        }
        static void Part1(int[] ints)
        {
            int increase = 0;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                if (ints[i] < ints[i + 1])
                {
                    increase++;
                }
            }
            Console.WriteLine($"Part 1 {increase}");
        }

        static void Part2(int[] ints)
        {
            int increase = 0;
            for (int i = 0; i < ints.Length - 3; i++)
            {
                if (ints[i] < ints[i + 3])
                {
                    increase++;
                }
            }
            Console.WriteLine($"Part 2 {increase}");
        }
    }
}
