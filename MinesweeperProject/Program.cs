
using MinesweeperProject;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;

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
            string difficulty = "hard";
            //HardBoard tiles = new HardBoard();
            //structure initilizers
            //generate bombs on the game board
            //---------------------------------------------------------------------------            
            board.Populate(16,30,99);
            board.GenBoard(41, 10, board.size.GetLength(0), board.size.GetLength(1));
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
            bool leftClick = IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);
            bool rightClick = IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON);

            while (!WindowShouldClose())
            {
                //update step
                //-----------------------------------------------------------------------
                Vector2 mousePos = GetMousePosition();
                //-----------------------------------------------------------------------
                //play step
                //-----------------------------------------------------------------------
                for (int i = 0; i < board.size.GetLength(0); i++)
                {
                    for (int j = 0; j < board.size.GetLength(1); j++)
                    {
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i, j])&& IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                        {
                            board.clickBoard[i, j] = true;
                        }
                    }
                }
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
                if(difficulty == "hard")
                {
                    //draw play background
                    DrawRectangle(10, 41, 1379, 735, BROWN);
                    //draw lines
                    for(int i = 0; i < board.size.GetLength(1)+1; i++)
                    {
                        DrawLine(10 + 46 * i, 41, 10 + 46 * i, 776, BLACK);
                    }
                    for(int j = 0; j < board.size.GetLength(0) + 1; j++)
                    {
                        DrawLine(9, 40+46*j, 1390, 40+46*j, BLACK);
                    }
                    
                    //draw the mines
                    for (int i = 0; i < board.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.size.GetLength(1); j++)
                        {
                            if (board.size[i, j] == "#")
                                DrawCircle(j * 45 + 32 + j, i * 45 + 63 + i, 22.5F, BLACK);


                        }
                    }
                    //draw numbers
                    for (int i = 0; i < board.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.size.GetLength(1); j++)
                        {
                            if (board.size[i, j] != "#")
                                DrawText(board.size[i, j],j*46+29,i*46+43,45,BLACK);
                        }
                    }
                    //draw the top tiles
                    for (int i = 0; i < board.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.size.GetLength(1); j++)
                        {
                            if (!board.clickBoard[i, j])
                                DrawRectangleRec(board.rectangles[i, j], GREEN);
                        }
                    }
                }
                //position tracker to be deleted later
                for (int i = 0; i < board.size.GetLength(0); i++)
                {
                    for (int j = 0; j < board.size.GetLength(1); j++)
                    {
                        
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i,j]))
                        {
                            DrawText($"mouse pos =  {i+1},{j + 1}", 10, 10, 30, BLACK);
                        }

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

