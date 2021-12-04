namespace day04
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            string[] draw = File.ReadAllLines("data.txt")[0].Split(",");
            string[] bingoCards = File.ReadAllText("data.txt").Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<BingoCard> cards = CardList(bingoCards);
            Solve(draw, cards);
        }

        static List<BingoCard> CardList(string[] bingoCards)
        {
            List<BingoCard> cards = new List<BingoCard>();
            for (int i = 1; i < bingoCards.Length; i++)
            {
                cards.Add(new BingoCard(bingoCards[i]));
            }
            return cards;
        }


        static void Solve(string[] draw, List<BingoCard> cards)
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
            Console.WriteLine($"Part 1 - {winningSums[0]}");
            Console.WriteLine($"Part 2 - {winningSums[winningSums.Count - 1]}");
        }
    }

}
