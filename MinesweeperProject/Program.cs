
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
<<<<<<< Updated upstream
            Board board = new Board();
            string difficulty = "hard";
            
=======
            Board Board = new Board();
            EasyBoard easyBoard = new EasyBoard();
            MedBoard medBoard = new MedBoard();
            HardBoard hardBoard = new HardBoard();
            Menu menu = new Menu();           
>>>>>>> Stashed changes
            //misc varibles
            //---------------------------------------------------------------------------
            int flagsLeft = 99;
            bool lost = false;
            string difficulty = "menu";
            int score = 0;
            bool firstClick = false;
            //---------------------------------------------------------------------------
<<<<<<< Updated upstream
            //generate bombs on the game board
            //---------------------------------------------------------------------------            
            board.Populate(16,30,99);
            board.GenBoard(41, 10, board.size.GetLength(0), board.size.GetLength(1));
            //---------------------------------------------------------------------------

            //printing it out inthe consolefor debugging
=======

>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
                    for (int j = 0; j < board.size.GetLength(1); j++)
                    {
                        //drop flag
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i, j]) && rightClick && board.clickBoard[i,j] != "click") 
=======
                    //reset button
                    if (CheckCollisionPointCircle(mousePos, Board.resetButton, Board.resetCenter) && leftClick)
                    {
                        difficulty = "menu";
                        lost = false;
                        firstClick = false;
                    }

                    if (difficulty == "easy" && !lost)
                    {
                        for (int i = 0; i < easyBoard.size.GetLength(0); i++)
>>>>>>> Stashed changes
                        {
                            if (board.clickBoard[i, j] != "flag" && flagsLeft > 0)
                            {
<<<<<<< Updated upstream
                                board.clickBoard[i, j] = "flag";
                                flagsLeft--;
                            }
                            else if(board.clickBoard[i,j] == "flag")
                            { 
                                board.clickBoard[i, j] = "";
                                flagsLeft++;
=======
                                //drop flag
                                if (CheckCollisionPointRec(mousePos, easyBoard.rectangles[i, j]) && rightClick && easyBoard.clickBoard[i, j] != "click")
                                {
                                    //count down flags if zero can't drop flag
                                    if (easyBoard.clickBoard[i, j] != "flag" && flagsLeft > 0)
                                    {
                                        easyBoard.clickBoard[i, j] = "flag";
                                        flagsLeft--;
                                        //keep score
                                        if (easyBoard.size[i, j] == "#")
                                        {
                                            score += 10;
                                            easyBoard.size[i, j] = "+";
                                        }
                                    }
                                    //pick up flags
                                    else if (easyBoard.clickBoard[i, j] == "flag")
                                    {
                                        easyBoard.clickBoard[i, j] = "";
                                        flagsLeft++;
                                        //adjust score
                                        if (easyBoard.size[i, j] == "+")
                                        {
                                            score -= 10;
                                            easyBoard.size[i, j] = "#";
                                        }
                                    }
                                }

                                //clear tile
                                if (CheckCollisionPointRec(mousePos, easyBoard.rectangles[i, j]) && leftClick && easyBoard.clickBoard[i, j] != "flag")
                                {
                                    if (easyBoard.size[i, j] != "#")
                                    {
                                        easyBoard.clickBoard[i, j] = "click";
                                        if (!firstClick)
                                        {
                                            firstClick = true;
                                            easyBoard.GenNumbs();
                                        }
                                    }
                                    else
                                    {
                                        if (!firstClick)
                                        {
                                            easyBoard.size[i, j] = " ";
                                            for(int x = 0; x < easyBoard.size.GetLength(0); x++)
                                            {
                                                for (int y = 0; y < easyBoard.size.GetLength(1); y++)
                                                {
                                                    if(easyBoard.size[x,y] != "#")
                                                    {
                                                        easyBoard.size[x, y] = "#";
                                                        x = easyBoard.size.GetLength(0);
                                                        y = easyBoard.size.GetLength(1);
                                                    }
                                                }
                                            }
                                            firstClick = true;
                                            easyBoard.GenNumbs();
                                        }
                                        else
                                        {
                                            easyBoard.clickBoard[i, j] = "click";
                                            lost = true;
                                        }
                                        
                                    }
                                }
>>>>>>> Stashed changes
                            }
                        }
                        
                        //clear tile
                        if (CheckCollisionPointRec(mousePos, board.rectangles[i, j])&& leftClick && board.clickBoard[i,j] != "flag")
                        {
                            if (board.size[i, j] != "#")
                            {
<<<<<<< Updated upstream
                                board.clickBoard[i, j] = "click";
                                //make sure square isnt a bomb
                                

=======
                                //drop flag
                                if (CheckCollisionPointRec(mousePos, medBoard.rectangles[i, j]) && rightClick && medBoard.clickBoard[i, j] != "click")
                                {
                                    //count down flags if zero can't drop flag
                                    if (medBoard.clickBoard[i, j] != "flag" && flagsLeft > 0)
                                    {
                                        medBoard.clickBoard[i, j] = "flag";
                                        flagsLeft--;
                                        //keep score
                                        if (medBoard.size[i, j] == "#")
                                        {
                                            score += 10;
                                            medBoard.size[i, j] = "+";
                                        }
                                    }
                                    //pick up flags
                                    else if (medBoard.clickBoard[i, j] == "flag")
                                    {
                                        medBoard.clickBoard[i, j] = "";
                                        flagsLeft++;
                                        //adjust score
                                        if (medBoard.size[i, j] == "+")
                                        {
                                            score -= 10;
                                            medBoard.size[i, j] = "#";
                                        }
                                    }
                                }

                                //clear tile
                                if (CheckCollisionPointRec(mousePos, medBoard.rectangles[i, j]) && leftClick && medBoard.clickBoard[i, j] != "flag")
                                {
                                    if (medBoard.size[i, j] != "#")
                                    {
                                        medBoard.clickBoard[i, j] = "click";
                                        if (!firstClick)
                                        {
                                            firstClick = true;
                                            medBoard.GenNumbs();
                                        }
                                    }
                                    else
                                    {
                                        if (!firstClick)
                                        {
                                            medBoard.size[i, j] = " ";
                                            for (int x = 0; x < medBoard.size.GetLength(0); x++)
                                            {
                                                for (int y = 0; y < medBoard.size.GetLength(1); y++)
                                                {
                                                    if (medBoard.size[x, y] != "#")
                                                    {
                                                        medBoard.size[x, y] = "#";
                                                        x = medBoard.size.GetLength(0);
                                                        y = medBoard.size.GetLength(1);
                                                    }
                                                }
                                            }
                                            firstClick = true;
                                            medBoard.GenNumbs();
                                        }
                                        else
                                        {
                                            medBoard.clickBoard[i, j] = "click";
                                            lost = true;
                                        }

                                    }
                                }
>>>>>>> Stashed changes
                            }
                            else
                            {
<<<<<<< Updated upstream
                                board.clickBoard[i, j] = "click";
                                lost = true;
=======
                                //drop flag
                                if (CheckCollisionPointRec(mousePos, hardBoard.rectangles[i, j]) && rightClick && hardBoard.clickBoard[i, j] != "click")
                                {
                                    //count down flags if zero can't drop flag
                                    if (hardBoard.clickBoard[i, j] != "flag" && flagsLeft > 0)
                                    {
                                        hardBoard.clickBoard[i, j] = "flag";
                                        flagsLeft--;
                                        //keep score
                                        if (hardBoard.size[i, j] == "#")
                                        {
                                            score += 10;
                                            hardBoard.size[i, j] = "+";
                                        }
                                    }
                                    //pick up flags
                                    else if (hardBoard.clickBoard[i, j] == "flag")
                                    {
                                        hardBoard.clickBoard[i, j] = "";
                                        flagsLeft++;
                                        //adjust score
                                        if (hardBoard.size[i, j] == "+")
                                        {
                                            score -= 10;
                                            hardBoard.size[i, j] = "#";
                                        }
                                    }
                                }

                                //clear tile
                                if (CheckCollisionPointRec(mousePos, hardBoard.rectangles[i, j]) && leftClick && hardBoard.clickBoard[i, j] != "flag")
                                {
                                    if (hardBoard.size[i, j] != "#")
                                    {
                                        hardBoard.clickBoard[i, j] = "click";
                                        if (!firstClick)
                                        {
                                            firstClick = true;
                                            hardBoard.GenNumbs();
                                        }
                                    }
                                    else
                                    {
                                        if (!firstClick)
                                        {
                                            hardBoard.size[i, j] = " ";
                                            for (int x = 0; x < hardBoard.size.GetLength(0); x++)
                                            {
                                                for (int y = 0; y < hardBoard.size.GetLength(1); y++)
                                                {
                                                    if (hardBoard.size[x, y] != "#")
                                                    {
                                                        hardBoard.size[x, y] = "#";
                                                        x = hardBoard.size.GetLength(0);
                                                        y = hardBoard.size.GetLength(1);
                                                    }
                                                }
                                            }
                                            firstClick = true;
                                            hardBoard.GenNumbs();
                                        }
                                        else
                                        {
                                            hardBoard.clickBoard[i, j] = "click";
                                            lost = true;
                                        }

                                    }
                                }
>>>>>>> Stashed changes
                            }
                        }                        
                    }
<<<<<<< Updated upstream
                }
=======

                }
                //interactions in the menu screen
                if (difficulty == "menu")
                {
                    if (CheckCollisionPointRec(mousePos, menu.easyButton))
                    {
                        menu.mosOvrEsy = true;
                        if (leftClick)
                        {
                            difficulty = "easy";
                            easyBoard.GenBombs();
                            easyBoard.GenBoard(198, 498);
                            flagsLeft = easyBoard.bombCount;
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
                            medBoard.GenBombs();
                            medBoard.GenBoard(41, 340);
                            flagsLeft = medBoard.bombCount;
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
                            hardBoard.GenBombs();
                            hardBoard.GenBoard(41, 10);
                            flagsLeft = hardBoard.bombCount;
                        }
                    }
                    else
                        menu.mosOvrHrd = false;
                    if (CheckCollisionPointRec(mousePos, menu.scoresButton))
                    {
                        menu.mosOvrStg = true;
                        if (leftClick)
                        {
                            difficulty = "scores";
                        }
                    }

                }

>>>>>>> Stashed changes
                //-----------------------------------------------------------------------
                //draw step
                //-----------------------------------------------------------------------
                BeginDrawing();
<<<<<<< Updated upstream
                ClearBackground(DARKGREEN);
                //largest play area background
                {
                //45 tile width * 30 tiles + 1px border per tile = 1380play area width
                //45 tile heigt * 16 tiles + 1px border per tile = 750 play area heigt
                }
                if(difficulty == "hard")
=======
                ClearBackground(GRAY);
                //Draw the menu
                if (difficulty == "menu")
                {
                    DrawText("MEENSWIPPER!", 300, 50, 100, BLACK);
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
                    if (menu.mosOvrStg)
                        DrawRectangle(540, 520, 320, 110, WHITE);
                    DrawRectangleRec(menu.scoresButton, BLUE);
                    DrawText("Scores", 555, 530, 80, BLACK);
                }
                else
                {
                    DrawCircleV(Board.resetButton, Board.resetCenter, YELLOW);
                }
                //draw the easy board
                if (difficulty == "easy")
                {
                    DrawCircleV(Board.resetButton, Board.resetCenter, YELLOW);
                    DrawRectangle(498, 198, 368, 368, DARKGRAY);
                    //draw lines
                    for (int i = 0; i < easyBoard.size.GetLength(1) + 1; i++)
                    {
                        DrawLine(498 + 46 * i, 197, 498 + 46 * i, 565, BLACK);
                    }
                    for (int j = 0; j < easyBoard.size.GetLength(0) + 1; j++)
                    {
                        DrawLine(497, 197 + 46 * j, 866, 197 + 46 * j, BLACK);
                    }

                    //draw the mines
                    for (int i = 0; i < easyBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < easyBoard.size.GetLength(1); j++)
                        {
                            if (easyBoard.size[i, j] == "#")
                                DrawCircle(j * 45 + 520 + j, i * 45 + 220 + i, 22.5F, BLACK);


                        }
                    }
                    //draw numbers
                    for (int i = 0; i < easyBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < easyBoard.size.GetLength(1); j++)
                        {
                            if (easyBoard.size[i, j] != "#")
                                DrawText(easyBoard.size[i, j], j * 46 + 510, i * 46 + 200, 45, BLACK);
                        }
                    }
                    //draw the top tiles
                    for (int i = 0; i < easyBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < easyBoard.size.GetLength(1); j++)
                        {
                            if (easyBoard.clickBoard[i, j] == "" && easyBoard.clickBoard[i, j] != "flag")
                                DrawRectangleRec(easyBoard.rectangles[i, j], GRAY);
                            if (easyBoard.clickBoard[i, j] == "flag")
                                DrawRectangleRec(easyBoard.rectangles[i, j], RED);
                        }
                    }
                    if (lost)
                    {
                        for (int i = 0; i < easyBoard.size.GetLength(0); i++)
                        {
                            for (int j = 0; j < easyBoard.size.GetLength(1); j++)
                            {
                                if (easyBoard.size[i, j] == "#")
                                    DrawCircle(j * 45 + 520 + j, i * 45 + 220 + i, 22.5F, BLACK);


                            }
                        }
                    }

                    //display flags left
                    DrawText($"flags left:{flagsLeft}", 50, 10, 20, BLACK);
                    
                }
                //draw medium board
                if (difficulty == "medium")
                {
                    DrawCircleV(Board.resetButton, Board.resetCenter, YELLOW);
                    //draw play background
                    DrawRectangle(340, 41, 735, 735, DARKGRAY);
                    //draw lines
                    for (int i = 0; i < medBoard.size.GetLength(1) + 1; i++)
                    {
                        DrawLine(340 + 46 * i, 41, 340 + 46 * i, 776, BLACK);
                    }
                    for (int j = 0; j < medBoard.size.GetLength(0) + 1; j++)
                    {
                        DrawLine(339, 40 + 46 * j, 1076, 40 + 46 * j, BLACK);
                    }

                    //draw the mines
                    for (int i = 0; i < medBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < medBoard.size.GetLength(1); j++)
                        {
                            if (medBoard.size[i, j] == "#")
                                DrawCircle(j * 45 + 362 + j, i * 45 + 63 + i, 22.5F, BLACK);


                        }
                    }
                    //draw numbers
                    for (int i = 0; i < medBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < medBoard.size.GetLength(1); j++)
                        {
                            if (medBoard.size[i, j] != "#")
                                DrawText(medBoard.size[i, j], j * 46 + 355, i * 46 + 43, 45, BLACK);
                        }
                    }
                    //draw the top tiles
                    for (int i = 0; i < medBoard.size.GetLength(0); i++)
                    {
                        for (int j = 0; j < medBoard.size.GetLength(1); j++)
                        {
                            if (medBoard.clickBoard[i, j] == "" && medBoard.clickBoard[i, j] != "flag")
                                DrawRectangleRec(medBoard.rectangles[i, j], GRAY);
                            if (medBoard.clickBoard[i, j] == "flag")
                                DrawRectangleRec(medBoard.rectangles[i, j], RED);
                        }
                    }
                    if (lost)
                    {
                        for (int i = 0; i < medBoard.size.GetLength(0); i++)
                        {
                            for (int j = 0; j < medBoard.size.GetLength(1); j++)
                            {
                                if (medBoard.size[i, j] == "#")
                                    DrawCircle(j * 45 + 362 + j, i * 45 + 63 + i, 22.5F, BLACK);
                            }
                        }
                    }

                    //display flags left
                    DrawText($"flags left:{flagsLeft}", 50, 10, 20, BLACK);
                }
                //draw the hardest board
                if (difficulty == "hard")
>>>>>>> Stashed changes
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
                    DrawText($"flags left:{flagsLeft}", 50, 10, 20, BLACK);
                }
<<<<<<< Updated upstream
                EndDrawing();
                
                
=======
                //draw the scores menu
                if(difficulty == "scores")
                {
                    
                }
                //DrawLine(700, 0, 700, 800, BLACK);
                EndDrawing();                
>>>>>>> Stashed changes
                //-----------------------------------------------------------------------
            }
            //deinitilization
            //---------------------------------------------------------------------------
            CloseWindow();
            //---------------------------------------------------------------------------
        }
    }
}

