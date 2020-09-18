
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
            
            //misc varibles
            //---------------------------------------------------------------------------
            int flagsLeft = 99;
            bool lost = false;
            //---------------------------------------------------------------------------
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
            while (!WindowShouldClose())
            {
                //update step
                //-----------------------------------------------------------------------
                Vector2 mousePos = GetMousePosition();
                bool leftClick = (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON));
                bool rightClick = IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON);
                //-----------------------------------------------------------------------
                //play step
                //-----------------------------------------------------------------------
                for (int i = 0; i < board.size.GetLength(0); i++)
                {
                    for (int j = 0; j < board.size.GetLength(1); j++)
                    {
                        //drop flag
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i, j]) && rightClick && board.clickBoard[i,j] != "click") 
                        {
                            if (board.clickBoard[i, j] != "flag" && flagsLeft > 0)
                            {
                                board.clickBoard[i, j] = "flag";
                                flagsLeft--;
                            }
                            else if(board.clickBoard[i,j] == "flag")
                            { 
                                board.clickBoard[i, j] = "";
                                flagsLeft++;
                            }
                        }
                        
                        //clear tile
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i, j])&& leftClick && board.clickBoard[i,j] != "flag")
                        {
                            if (board.size[i, j] != "#")
                            {
                                board.clickBoard[i, j] = "click";
                                //make sure square isnt a bomb
                                

                            }
                            else
                            {
                                board.clickBoard[i, j] = "click";
                                lost = true;
                            }
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
                            if (board.clickBoard[i, j] == "" && board.clickBoard[i, j] != "flag")
                                DrawRectangleRec(board.rectangles[i, j], GREEN);
                            if (board.clickBoard[i, j] == "flag")
                                DrawRectangleRec(board.rectangles[i, j], RED);
                        }
                    }
                    if (lost)
                    {
                        for (int i = 0; i < board.size.GetLength(0); i++)
                        {
                            for (int j = 0; j < board.size.GetLength(1); j++)
                            {
                                if (board.size[i, j] == "#")
                                    DrawCircle(j * 45 + 32 + j, i * 45 + 63 + i, 22.5F, BLACK);


                            }
                        }
                    }

                    //display flags left
                    DrawText($"flags left:{flagsLeft}", 10, 10, 20, BLACK);
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

