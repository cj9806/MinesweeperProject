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
            Board Board = new Board();
            EasyBoard easyBoard = new EasyBoard();
            MedBoard medBoard = new MedBoard();
            HardBoard hardBoard = new HardBoard();
            Menu menu = new Menu();
            string difficulty = "";
            
            //misc varibles
            //---------------------------------------------------------------------------
            int flagsLeft = 0;
            bool lost = false;
            //---------------------------------------------------------------------------
            //generate bombs on the game board
            //---------------------------------------------------------------------------            
            //hardBoard.Populate();
            //hardBoard.GenBoard(41, 10, hardBoard.size.GetLength(0), hardBoard.size.GetLength(1));
            //---------------------------------------------------------------------------

            //printing it out inthe consolefor debugging

            for (int i = 0; i < hardBoard.size.GetLength(0); i++)
            {
                for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                {
                    Console.Write(hardBoard.size[i, j]);
                }
                Console.WriteLine();
                }
            Console.WriteLine("bomb count = " + hardBoard.bombCount);
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
                if (difficulty != "" && !lost)
                {
                    for (int i = 0; i < hardBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                        {
                            //drop flag
                            if (CheckCollisionPointRec(mousePos, hardBoard.rectangles[i, j]) && rightClick && hardBoard.clickBoard[i, j] != "click")
                            {
                                if (hardBoard.clickBoard[i, j] != "flag" && flagsLeft > 0)
                                {
                                    hardBoard.clickBoard[i, j] = "flag";
                                    flagsLeft--;
                                }
                                else if (hardBoard.clickBoard[i, j] == "flag")
                                {
                                    hardBoard.clickBoard[i, j] = "";
                                    flagsLeft++;
                                }
                            }

                            //clear tile
                            if (CheckCollisionPointRec(mousePos, hardBoard.rectangles[i, j]) && leftClick && hardBoard.clickBoard[i, j] != "flag")
                            {
                                if (hardBoard.size[i, j] != "#")
                                {
                                    hardBoard.clickBoard[i, j] = "click";
                                    //make sure square isnt a bomb                                
                                }
                                else
                                {
                                    hardBoard.clickBoard[i, j] = "click";
                                    lost = true;
                                }
                            }
                        }
                    }
                }
                //interactions in the menu screen
                if (difficulty == "")
                {
                    if (CheckCollisionPointRec(mousePos, menu.easyButton))
                    {
                        menu.mosOvrEsy = true;
                        if (leftClick) 
                        {
                            difficulty = "easy";
                            easyBoard.Populate();
                            easyBoard.GenBoard(41, 10);
                        }
                    }
                    else
                        menu.mosOvrEsy = false;
                    if (CheckCollisionPointRec(mousePos, menu.medButton))
                    {
                        menu.mosOvrMed = true;
                        if (leftClick)
                        {
                            difficulty = "medium";
                            medBoard.Populate();
                            medBoard.GenBoard(41, 10);
                        }
                    }
                    else
                        menu.mosOvrMed = false;
                    if (CheckCollisionPointRec(mousePos, menu.hardButton))
                    {
                        menu.mosOvrHrd = true;
                        if (leftClick)
                        {
                            difficulty = "hard";
                            hardBoard.Populate();
                            hardBoard.GenBoard(41, 10);
                            flagsLeft = hardBoard.bombCount;
                        }
                    }
                    else
                        menu.mosOvrHrd = false;
                    
                }
                
                //-----------------------------------------------------------------------
                //draw step
                //-----------------------------------------------------------------------
                BeginDrawing();
                ClearBackground(GRAY);
                //largest play area background
                {
                    //45 tile width * 30 tiles + 1px border per tile = 1380play area width
                    //45 tile heigt * 16 tiles + 1px border per tile = 750 play area heigt
                }
                //Draw the menu
                if (difficulty=="")
                {
                    if (menu.mosOvrEsy)
                        DrawRectangle(540, 190, 320, 110, WHITE);
                    DrawRectangleRec(menu.easyButton, GREEN);
                    DrawText("Easy", 600, 200, 80, BLACK);
                    if (menu.mosOvrMed)
                        DrawRectangle(540, 300, 320, 110, WHITE);
                    DrawRectangleRec(menu.medButton, YELLOW);
                    DrawText("Medium", 565, 320, 80, BLACK);
                    if (menu.mosOvrHrd)
                        DrawRectangle(540, 410, 320, 110, WHITE);
                    DrawRectangleRec(menu.hardButton, RED);
                    DrawText("Hard", 600, 430, 80, BLACK);
                    DrawRectangleRec(menu.scoresButton, BLUE);
                    DrawText("Scores", 555, 530, 80, BLACK);
                }
                //draw the hardest board
                if (difficulty == "hard")
                {
                    //draw play background
                    DrawRectangle(10, 41, 1379, 735, DARKGRAY);
                    //draw lines
                    for(int i = 0; i < hardBoard.size.GetLength(1)+1; i++)
                    {
                        DrawLine(10 + 46 * i, 41, 10 + 46 * i, 776, BLACK);
                    }
                    for(int j = 0; j < hardBoard.size.GetLength(0) + 1; j++)
                    {
                        DrawLine(9, 40+46*j, 1390, 40+46*j, BLACK);
                    }
                    
                    //draw the mines
                    for (int i = 0; i < hardBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                        {
                            if (hardBoard.size[i, j] == "#")
                                DrawCircle(j * 45 + 32 + j, i * 45 + 63 + i, 22.5F, BLACK);


                        }
                    }
                    //draw numbers
                    for (int i = 0; i < hardBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                        {
                            if (hardBoard.size[i, j] != "#")
                                DrawText(hardBoard.size[i, j],j*46+29,i*46+43,45,BLACK);
                        }
                    }
                    //draw the top tiles
                    for (int i = 0; i < hardBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                        {
                            if (hardBoard.clickBoard[i, j] == "" && hardBoard.clickBoard[i, j] != "flag")
                                DrawRectangleRec(hardBoard.rectangles[i, j], GRAY);
                            if (hardBoard.clickBoard[i, j] == "flag")
                                DrawRectangleRec(hardBoard.rectangles[i, j], RED);
                        }
                    }
                    if (lost)
                    {
                        for (int i = 0; i < hardBoard.size.GetLength(0); i++)
                        {
                            for (int j = 0; j < hardBoard.size.GetLength(1); j++)
                            {
                                if (hardBoard.size[i, j] == "#")
                                    DrawCircle(j * 45 + 32 + j, i * 45 + 63 + i, 22.5F, BLACK);


                            }
                        }
                    }

                    //display flags left
                    DrawText($"flags left:{flagsLeft}", 10, 10, 20, BLACK);
                }
                //DrawLine(700, 0, 700, 800, BLACK);
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

