using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperProject
{
    class Board
    {
        //Random random = new Random();
        public int[,] size = { };
        public int bombCount = 0;
        public int maxBombs = 0;
        public int[,] Populate()
        {
            Random random = new Random();
            for (int i = 0; i < size.GetLength(0); i++)
            {
                for (int j = 0; j < size.GetLength(1); j++)
                {
                    int hasBomb = random.Next(0, 2);
                    if (bombCount < maxBombs)
                    {
                        size[i, j] = hasBomb;
                    }
                } 
            }
            return size;
        }        
    }
}
