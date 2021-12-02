using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            Part2(lines);
        }

        static void Part1(string[] lines)
        {
            int hor = 0;
            int dep = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(" ");
                if (parts[0] == "down")
                {
                    dep += Convert.ToInt32(parts[1]);
                }
                if (parts[0] == "up")
                {
                    dep -= Convert.ToInt32(parts[1]);
                }
                if (parts[0] == "forward")
                {
                    hor += Convert.ToInt32(parts[1]);
                }
            }
            Console.WriteLine(dep * hor);
        }

        static void Part2(string[] lines)
        {
            int hor = 0;
            int dep = 0;
            int aim = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(" ");
                int value = Convert.ToInt32(parts[1]);
                if (parts[0] == "down")
                {
                    aim += value;
                }
                if (parts[0] == "up")
                {
                    aim -= value;
                }
                if (parts[0] == "forward")
                {
                    hor += value;
                    dep += value*aim;
                }
            }
            Console.WriteLine(dep * hor);
        }
    }
}
