using System;
using System.IO;
using System.Linq;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("sample.txt");
            Part1(lines);
            Part2(lines);
        }

        static void Part1(string[] lines)
        {
            int count = 0;
            foreach (string line in lines)
            {
                string latter = line.Trim().Split("|")[1];
                foreach (string part in latter.Split(" "))
                {
                    if (part.Length == 2 || part.Length == 3 || part.Length == 4 || part.Length == 7)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("Part 1 " + count);
        }


        static void Part2(string[] lines)
        {
            int count = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Trim().Split("|");
                foreach (string part in parts)
                {
                    Console.WriteLine(part);
                }
            }
            Console.WriteLine("Part 2 " + count);
        }
    }
}
