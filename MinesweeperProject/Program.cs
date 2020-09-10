
using MinesweeperProject;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            HardBoard board = new HardBoard();
            int bombCount = 0;
            while (bombCount < board.maxBombs)
            {
                for(int i =  0; i < board.size.GetLength(0);i++)
                {
                    for(int j = 0; j < board.size.GetLength(1); j++)
                    {
                        int place = board.size[i, j];
                        board.size[i, j] = random.Next(0, 2);
                        if (board.size[i,j] == 1 && bombCount < board.maxBombs)
                            bombCount ++;
                    }
                }
            }
            
            for(int i = 0; i < board.size.GetLength(0); i++)
            {
                for(int j = 0; j < board.size.GetLength(1); j++)
                {
                    Console.Write(board.size[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            
        }
    }
}
