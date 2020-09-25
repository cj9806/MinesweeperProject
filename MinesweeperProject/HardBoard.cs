using MinesweeperProject;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MinesweeperProject
{
    class HardBoard : Board
    {
        Random random = new Random();
        int width = 16;
        int heigth = 30;
        int maxBomb = 99;
        new public string[,] Populate()
        {
            
            bombCount = 0;
            size = new string[width, heigth];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    size[i, j] = " ";
                }
            }
            //populate random pre-exsisting squares with bombs for better spread
            while (bombCount < maxBomb)
            {
                int randI = random.Next(0, width);
                int randJ = random.Next(0, heigth);
                if (size[randI, randJ] != "#")
                {
                    size[randI, randJ] = "#";
                    bombCount += 1;

                }
            }
            //see how many are around a sqaure
            return size;
        }
        new public Raylib_cs.Rectangle[,] rectangles = new Raylib_cs.Rectangle[16, 30];
        new public string[,] clickBoard = new string[16, 30];
        new public void GenBoard(int startX, int startY)
        {

            for (int i = 0; i < 16; i++)
            {

                for (int j = 0; j < 30; j++)
                {
                    rectangles[i, j] = new Raylib_cs.Rectangle(j * 45 + startY + j, i * 45 + startX + i, 45, 45);
                    clickBoard[i, j] = "";
                }

            }
        }
        new public void GenNumbs()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    int surrounded = 0;
                    //make sure square isnt a bomb
                    if (size[i, j] == " ")
                    {
                        //trap index errors
                        //northwest square
                        if (i == 0 && j == 0)
                        {
                            //east
                            if (size[i, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //south
                            if (size[i + 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //southeast
                            if (size[i + 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                        }
                        //southeast square
                        else if (i == width - 1 && j == heigth - 1)
                        {
                            //northweast
                            if (size[i - 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //north
                            if (size[i - 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //west
                            if (size[i, j - 1] == "#")
                            {
                                surrounded++;
                            }
                        }
                        //north edge
                        else if (i == 0)
                        {
                            //west
                            if (size[i, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //east
                            //more error trapping becuase im inefficent
                            if (j != 29)
                                if (size[i, j + 1] == "#")
                                {
                                    surrounded++;
                                }
                            //southwest
                            if (size[i + 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //south
                            if (size[i + 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //southeast
                            //i dont know if theres a simpler way to do this but i dont really care at this point
                            if (j != 29)
                                if (size[i + 1, j + 1] == "#")
                                {
                                    surrounded++;
                                }
                        }
                        //south edge
                        else if (i == width - 1)
                        {
                            //northweast
                            if (j != 0)
                                if (size[i - 1, j - 1] == "#")
                                {
                                    surrounded++;
                                }
                            //north
                            if (size[i - 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //northeast
                            if (size[i - 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //west
                            if (j != 0)
                                if (size[i, j - 1] == "#")
                                {
                                    surrounded++;
                                }
                            //east
                            if (size[i, j + 1] == "#")
                            {
                                surrounded++;
                            }
                        }
                        //west edge
                        else if (j == 0)
                        {
                            //north
                            if (size[i - 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //northeast
                            if (size[i - 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //east
                            if (size[i, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //south
                            if (size[i + 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //southeast
                            if (size[i + 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                        }
                        //east edge
                        else if (j == heigth - 1)
                        {
                            //northweast
                            if (size[i - 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //north
                            if (size[i - 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //west
                            if (size[i, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //southwest
                            if (size[i + 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //south
                            if (size[i + 1, j] == "#")
                            {
                                surrounded++;
                            }
                        }
                        //everything else is fair game
                        else
                        {
                            //northweast
                            if (size[i - 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //north
                            if (size[i - 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //northeast
                            if (size[i - 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //west
                            if (size[i, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //east
                            if (size[i, j + 1] == "#")
                            {
                                surrounded++;
                            }
                            //southwest
                            if (size[i + 1, j - 1] == "#")
                            {
                                surrounded++;
                            }
                            //south
                            if (size[i + 1, j] == "#")
                            {
                                surrounded++;
                            }
                            //southeast
                            if (size[i + 1, j + 1] == "#")
                            {
                                surrounded++;
                            }
                        }

                    }
                    if (surrounded > 0)
                        size[i, j] = surrounded.ToString();

                }
            }
        }
    }
}
