using System;
using System.IO;
using System.Collections.Generic;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] lines = File.ReadAllLines("data.txt");
            Part1(lines);
            Part2(lines);

        }

        static void Part1(string[] lines)
        {
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < lines[1].Length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (string line in lines)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }
                if (zeroCount < oneCount)
                {
                    epsilon += "0";
                    gamma += "1";
                }
                else
                {
                    epsilon += "1";
                    gamma += "0";
                }
            }
            int multi = Convert.ToInt32(epsilon, 2) * Convert.ToInt32(gamma, 2);
            Console.WriteLine("Part1 " + multi);
        }


        static void Part2(string[] lines)
        {
            List<string> oxygenList = new List<string>(lines);
            List<string> co2List = new List<string>(lines);
            for (int i = 0; i < lines[1].Length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (string line in co2List)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }
                if (co2List.Count > 1)
                {
                    if (zeroCount < oneCount)
                    {
                        co2List.RemoveAll(x => x[i] == '1');
                    }
                    else if (zeroCount == oneCount)
                    {
                        co2List.RemoveAll(x => x[i] == '1');
                    }
                    else if (zeroCount > oneCount)
                    {
                        co2List.RemoveAll(x => x[i] == '0');
                    }
                }
            }
            for (int i = 0; i < lines[1].Length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach (string line in oxygenList)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }
                if (oxygenList.Count > 1)
                {
                    if (zeroCount < oneCount)
                    {
                        oxygenList.RemoveAll(x => x[i] == '0');
                    }
                    else if (zeroCount == oneCount)
                    {
                        oxygenList.RemoveAll(x => x[i] == '0');
                    }
                    else if (zeroCount > oneCount)
                    {
                        oxygenList.RemoveAll(x => x[i] == '1');
                    }
                }
            }
            int life = Convert.ToInt32(co2List[0], 2) * Convert.ToInt32(oxygenList[0], 2);
            Console.WriteLine("Part2 " + life);
        }
    }
}

