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
    class GameTiles
    {
        public List<Raylib_cs.Rectangle> tiles = new List<Raylib_cs.Rectangle>();
        public void DrawBoard(int startX,int startY, int length, int width)
        {
            for (int i = 0;i < length; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    tiles.Add(new Raylib_cs.Rectangle(j * 45 + startY + j, i * 45 + startX + i,45,45));
                    DrawRectangle(j * 45 + startY + j, i * 45 + startX + i, 45, 45, GREEN);
                }
            }
        }
    }
}
