namespace day05
{
    using System;
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