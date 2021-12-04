namespace day04
{
    using System;
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