﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] draw = File.ReadAllLines("data.txt")[0].Split(",");
            string[] bingoCards = File.ReadAllText("data.txt").Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<BingoCard> cards1 = new List<BingoCard>();
            List<BingoCard> cards2 = new List<BingoCard>();
            for (int i = 1; i < bingoCards.Length; i++)
            {
                cards1.Add(new BingoCard(bingoCards[i]));
                cards2.Add(new BingoCard(bingoCards[i]));
            }
            Part1(draw, cards1);
            Part2(draw, cards2);
        }


        static void Part1(string[] draw, List<BingoCard> cards)
        {
            foreach (string winner in draw)
            {
                foreach (BingoCard card in cards)
                {
                    int num = Convert.ToInt32(winner);
                    card.CheckNumber(num);
                    if (card.Winning(num))
                    {
                        Console.WriteLine($"Part 1 - {card.CalculateTotal(num)}");
                        
                        return;
                    }
                }
            }
        }

        static void Part2(string[] draw, List<BingoCard> cards)
        {
            List<int> winningSums = new List<int>();
            foreach (string winner in draw)
            {
                int num = Convert.ToInt32(winner);
                foreach (BingoCard card in cards)
                {

                    card.CheckNumber(num);
                }
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Winning(num))
                    {
                        winningSums.Add(cards[i].CalculateTotal(num));
                        cards.Remove(cards[i]);
                    }
                }
            }
            Console.WriteLine($"Part 2 - {winningSums[winningSums.Count -1]}");
        }
    }



    public class BingoCard
    {
        public int[,] card;
        public BingoCard(string input)
        {
            this.card = new int[5, 5];
            int i = 0, j = 0;
            foreach (string row in input.Trim().Split('\n'))
            {
                j = 0;
                foreach (string col in row.Trim().Replace("  ", " ").Split(" "))
                {
                    this.card[i, j] = Convert.ToInt32(col);
                    j++;
                }
                i++;
            }
        }

        public void CheckNumber(int number)
        {
            for (int i = 0; i < this.card.GetLength(0); i++)
            {
                for (int j = 0; j < this.card.GetLength(1); j++)
                {

                    if (this.card[i, j] == number)
                    {
                        this.card[i, j] = -1;
                    }
                }
            }
        }
        public bool Winning(int number)
        {
            for (int i = 0; i < this.card.GetLength(1); i++)
            {
                if (this.card[0, i] == -1 && this.card[1, i] == -1 && this.card[2, i] == -1 && this.card[3, i] == -1 && this.card[4, i] == -1)
                {
                    return true;
                }
            }
            for (int i = 0; i < this.card.GetLength(0); i++)
            {
                if (this.card[i, 0] == -1 && this.card[i, 1] == -1 && this.card[i, 2] == -1 && this.card[i, 3] == -1 && this.card[i, 4] == -1)
                {
                    return true;
                }
            }
            return false;
        }
        public int CalculateTotal(int num)
        {
            int sum = 0;
            for (int i = 0; i < this.card.GetLength(0); i++)
            {
                for (int j = 0; j < this.card.GetLength(1); j++)
                {

                    if (this.card[i, j] != -1)
                    {
                        sum += this.card[i, j];
                    }
                }
            }
            return sum * num;
        }
    }
}
