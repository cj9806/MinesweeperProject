using System;
using System.Collections;

namespace FloodFillPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array =
            {
                {-1,-1,-1,-1,-1,-1,-1,-1},
                {-1, 1, 1, 1, 1, 1, 1,-1},
                {-1, 1, 1, 2, 2, 1, 1,-1},
                {-1, 1, 1, 2, 2, 1, 1,-1},
                {-1, 2, 2, 2, 2, 2, 2,-1},
                {-1,-1,-1,-1,-1,-1,-1,-1}
            };
            Console.WriteLine("array before sort");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (array[i,j] != -1)
                        Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
