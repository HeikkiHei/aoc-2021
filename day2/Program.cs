using System;
using System.IO;

namespace day2
{
  class Program
  {
    static void Main()
    {
      string[] lines = File.ReadAllLines("data.txt");
      Part1(lines);
    }

    static void Part1(string[] lines)
    {
      int hor = 0;
      int dep = 0;
      foreach (string line in lines)
      {
        string[] parts = line.Split(" ");
        char com = parts[0][0];
        int value = Convert.ToInt32(parts[1]);
        switch (com)
        {
          case 's':
            dep += value;
            break;
          case 'u':
            dep -= value;
            break;
          case 'f':
            hor += value;
            break;
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
        string com = parts[0];
        int value = Convert.ToInt32(parts[1]);
        if (com == "down")
        {
          aim += value;
        }
        if (com == "up")
        {
          aim -= value;
        }
        if (com == "forward")
        {
          hor += value;
          dep += value * aim;
        }
      }
      Console.WriteLine(dep * hor);
    }
  }
}
