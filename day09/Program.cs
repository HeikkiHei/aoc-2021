using System;
using System.IO;

namespace day09
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = File.ReadAllLines("sample.txt");
      int[,] map = new int[5, 10]; // SAMPLE
                                   // int[,] map = new int[100,100];
      for (int i = 0; i < lines.Length; i++)
      {
        for (int j = 0; j < lines[i].Length; j++)
        {
          map[i, j] = Convert.ToInt32(lines[i][j].ToString());
        }
      }
      PrintMap(map);
      CheckNeighbours(map);
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

    static void CheckNeighbours(int[,] map)
    {
      int sum = 0;
      int count = 0;
      for (int i = 0; i < map.GetLength(0); i++)
      {
        int up = 999;
        int down = 999;
        int left = 999;
        int right = 999;
        for (int j = 0; j < map.GetLength(1); j++)
        {
          int current = map[i, j];
          if (j > 0)
          {
            up = map[i, j - 1];
          }
          if (j < map.GetLength(1) - 1)
          {
            down = map[i, j + 1];
          }
          if (i > 0)
          {
            left = map[i - 1, j];
          }
          if (i < map.GetLength(0) - 1)
          {
            right = map[i + 1, j];
          }
          Console.Write(current + " " + i + "," + j + " ");
          // CHECK NEIGHBOURS
          if (current < up && current < left && current < right && current < down)
          {
            count++;
            sum += current;
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine(sum + count);
    }
  }
}
