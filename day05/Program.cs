namespace day05
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Globalization;

    class Program
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("data.txt");
            string[] lines = file.Split("\n");
            Map map = new Map();
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { " -> ", "," }, 4, StringSplitOptions.RemoveEmptyEntries);
                map.Add(new Line(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3])));
            }
            // map.DrawMap();
            Console.WriteLine(map.CountDanger());
        }
    }

    public class Line
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;


        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override string ToString()
        {
            return $"{this.x1},{this.y1} : {this.x2},{this.y2}";
        }
    }
    public class Map
    {
        private int[,] map;
        public Map()
        {
            this.map = new int[1000, 1000];
        }

        public void Add(Line line)
        {

            if (line.y1 == line.y2)
            {
                int smaller = line.x1;
                int greater = line.x2;
                if (line.x2 < line.x1)
                {
                    smaller = line.x2;
                    greater = line.x1;
                }
                for (int i = smaller; i <= greater; i++)
                {
                    this.map[line.y1, i]++;
                }
            }
            else if (line.x1 == line.x2)
            {
                int smaller = line.y1;
                int greater = line.y2;
                if (line.y2 < line.y1)
                {
                    smaller = line.y2;
                    greater = line.y1;
                }
                for (int i = smaller; i <= greater; i++)
                {
                    this.map[i, line.x1]++;

                }
            }
            else
            {
                if (line.x1 < line.x2 && line.y1 > line.y2)
                {

                    for (int i = line.x1; i <= line.x2;)
                    {
                        for (int j = line.y1; j >= line.y2; j--)
                        {
                            this.map[j, i]++;
                            i++;
                        }
                    }
                }
                else if (line.x1 > line.x2 && line.y1 > line.y2)
                {
                    for (int i = line.x1; i >= line.x2;)
                    {
                        for (int j = line.y1; j >= line.y2; j--)
                        {
                            this.map[j, i]++;
                            i--;
                        }
                    }
                }
                else if (line.x1 > line.x2 && line.y1 < line.y2)
                {
                    for (int i = line.x1; i >= line.x2;)
                    {
                        for (int j = line.y1; j <= line.y2; j++)
                        {
                            this.map[j, i]++;
                            i--;
                        }
                    }
                }
                else
                {
                    for (int i = line.x1; i <= line.x2;)
                    {
                        for (int j = line.y1; j <= line.y2; j++)
                        {
                            this.map[j, i]++;
                            i++;
                        }
                    }
                }
            }
        }

        public int CountDanger()
        {
            int sum = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] > 1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        public void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
