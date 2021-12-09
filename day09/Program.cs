using System;
using System.IO;

namespace day09
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = File.ReadAllLines("data.txt");
      // int[,] map = new int[5, 10]; // SAMPLE
      int[,] map = new int[100, 100];
      for (int i = 0; i < lines.Length; i++)
      {
        for (int j = 0; j < lines[i].Length; j++)
        {
          map[i, j] = Convert.ToInt32(lines[i][j].ToString());
        }
      }
      // PrintMap(map);
      Console.WriteLine("Part 1: " + CheckNeighbours(map));
    }

    static void PrintMap(int[,] map)
    {
      for (int i = 0; i < map.GetLength(0); i++)
      {
        for (int j = 0; j < map.GetLength(1); j++)
        {
          Console.Write(map[i, j] + " ");
        }
        Console.WriteLine();
      }
    }

    static int CheckNeighbours(int[,] map)
    {
      int sum = 0;
      int right = 999;
      int left = 999;
      int upper = 999;
      int down = 999;
      for (int i = 0; i < map.GetLength(0); i++)
      {

        for (int j = 0; j < map.GetLength(1); j++)
        {
          int current = map[i, j];
          if (j > 0)
          {
            right = map[i, j - 1];
          }
          if (j < map.GetLength(1) - 1)
          {
            left = map[i, j + 1];
          }
          if (i > 0)
          {
            upper = map[i - 1, j];
          }
          if (i < map.GetLength(0) - 1)
          {
            down = map[i + 1, j];
          }

          // CHECK NEIGHBOURS
          if (current < right && current < upper && current < down && current < left)
          {
            int riskLevel = 1 + current;
            sum += riskLevel;
          }
          right = 999;
          left = 999;
          upper = 999;
          down = 999;
        }

      }
      return sum;
    }
  }
}
