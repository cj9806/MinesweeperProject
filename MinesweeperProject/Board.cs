using MinesweeperProject;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Raylib_cs;
using System;
using System.Collections.Generic;
namespace MinesweeperProject
{
    class Board
    {
        Random random = new Random();
        public string[,] size = { };
        public int bombCount = 0;
        public Vector2 resetButton = new Vector2(30, 20);
        public float resetCenter = 15;
        int width = 0;
        int heigth = 0;
        int maxBomb = 0;        
        public string[,] Populate()
        {
            bombCount = 0;
            //Random random = new Random();
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
        //initial array to track game board and a shadow array to help track clicks
        public Raylib_cs.Rectangle[,] rectangles = new Raylib_cs.Rectangle[0, 0];
        public string[,] clickBoard = new string[0, 0];
        // function to create an array of rectangles
        public void GenBoard(int startX, int startY)
        {

            for (int i = 0; i < 0; i++)
            {

                for (int j = 0; j < 0; j++)
                {
                    rectangles[i, j] = new Raylib_cs.Rectangle(j * 45 + startY + j, i * 45 + startX + i, 45, 45);
                    clickBoard[i, j] = "";
                }

            }
        }
        public void GenNumbs()
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
