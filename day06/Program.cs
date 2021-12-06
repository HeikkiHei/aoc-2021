using System;
using System.IO;
using System.Collections.Generic;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("data.txt").Split(",");
            Part1(input);
            Part2(input);
        }
        static void Part1(string[] input)
        {
            List<long> fishes = new List<long>();
            foreach (string fish in input)
            {
                fishes.Add(Convert.ToInt32(fish));
            }
            fishes.Sort();
            // single day
            for (long k = 0; k < 80; k++)
            {
                long iterator = fishes.Count;
                for (int i = 0; i < iterator; i++)
                {
                    fishes[i]--;
                    if (fishes[i] < 0)
                    {
                        fishes[i] = 6;
                        fishes.Add(8);
                    }
                }
            }

            Console.WriteLine("Part 1: " + fishes.Count);
        }

        static void Part2(string[] input)
        {
            long[] fishesInArray = new long[9];
            for (int i = 0; i < input.Length; i++)
            {
                int newFish = Convert.ToInt32(input[i]);
                fishesInArray[newFish] += 1;
            }
            for (int k = 0; k < 256; k++)
            {
                long oldEight = fishesInArray[8];
                fishesInArray[8] = fishesInArray[0];
                fishesInArray[0] = fishesInArray[1];
                fishesInArray[1] = fishesInArray[2];
                fishesInArray[2] = fishesInArray[3];
                fishesInArray[3] = fishesInArray[4];
                fishesInArray[4] = fishesInArray[5];
                fishesInArray[5] = fishesInArray[6];
                // seven and old value of 0, now in 8
                fishesInArray[6] = fishesInArray[7] + fishesInArray[8];
                fishesInArray[7] = oldEight;

            }
            Console.WriteLine("Part 2: " + CountFishes(fishesInArray));
        }


        static void PrintFishes(long[] fishesInArray)
        {
            foreach (long fish in fishesInArray)
            {
                Console.WriteLine(fish);
            }
            Console.WriteLine();
        }

        static long CountFishes(long[] fishesInArray)
        {
            long sum = 0;
            foreach (long fish in fishesInArray)
            {
                sum += fish;
            }
            return sum;
        }
    }
}
