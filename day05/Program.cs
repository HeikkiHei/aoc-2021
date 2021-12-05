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




}
