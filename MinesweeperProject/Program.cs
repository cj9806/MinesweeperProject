
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
            //initalize raylib
            //---------------------------------------------------------------------------
            const int screenWidth = 1400;
            const int screenHeight= 800;

            InitWindow(screenWidth, screenHeight, "meenswipper");

            SetTargetFPS(60);
            //---------------------------------------------------------------------------
            
            //class initilizers
            Random random = new Random();
            Board board = new Board();
            GameTiles tiles = new GameTiles();
            //structure initilizers
            Rectangle button = new Rectangle(100, 100, 200, 80 );
            //generate bombs on the game board
            //---------------------------------------------------------------------------
            //while (board.bombCount < board.maxBombs)
            //{
            //    for (int i = 0; i < board.size.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < board.size.GetLength(1); j++)
            //        {
            //            int place = board.size[i, j];
            //            board.size[i, j] = random.Next(0, 2);
            //            if (board.size[i, j] == 1 && board.bombCount < board.maxBombs)
            //                board.bombCount++;
            //        }
            //    }
            //}
            board.Populate(16,30,99);
            //---------------------------------------------------------------------------

            //printing it out inthe consolefor debugging
            
            for (int i = 0; i < board.size.GetLength(0); i++)
            {
                for (int j = 0; j < board.size.GetLength(1); j++)
                {
                    Console.Write(board.size[i, j]);
                }
                Console.WriteLine();
                }
            Console.WriteLine("bomb count = " + board.bombCount);
            //main game loop
           
            while (!WindowShouldClose())
            {
                //update step
                //-----------------------------------------------------------------------
                Vector2 mousePos = GetMousePosition();
                //-----------------------------------------------------------------------
                //movement step
                //-----------------------------------------------------------------------
                  
                //-----------------------------------------------------------------------
                //draw step
                //-----------------------------------------------------------------------
                BeginDrawing();
                ClearBackground(DARKGREEN);
                //largest play area background
                {
                //45 tile width * 30 tiles + 1px border per tile = 1380play area width
                //45 tile heigt * 16 tiles + 1px border per tile = 750 play area heigt
                }
                DrawText($"mouse pos = {mousePos.X},{mousePos.Y}",10,10,30,BLACK);
                DrawRectangle(10, 41, 1379, 735, BROWN);
                tiles.DrawBoard(41,10,board.size.GetLength(0),board.size.GetLength(1));
                for (int i = 0; i < board.size.GetLength(0); i++)
                {
                    for (int j = 0; j < board.size.GetLength(1); j++)
                    {
                        if (board.size[i, j] == "#")
                            DrawCircle(j * 45 + 32 + j, i * 45 + 63 + i, 22.5F, BLACK);


                    }
                }
                EndDrawing();
                
                
                //-----------------------------------------------------------------------
            }
            //deinitilization
            //---------------------------------------------------------------------------
            CloseWindow();
            //---------------------------------------------------------------------------
        }
    }
}

