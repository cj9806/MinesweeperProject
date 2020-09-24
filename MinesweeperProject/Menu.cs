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
    class Menu
    {
        //"meenswipper"
        public Raylib_cs.Rectangle easyButton = new Raylib_cs.Rectangle(550, 200, 300, 90);
        public Raylib_cs.Rectangle medButton = new Raylib_cs.Rectangle(550, 310, 300, 90);
        public Raylib_cs.Rectangle hardButton = new Raylib_cs.Rectangle(550, 420, 300, 90);
        public Raylib_cs.Rectangle scoresButton = new Raylib_cs.Rectangle(550, 530, 300, 90);

        public bool mosOvrEsy = false;
        public bool mosOvrMed = false;
        public bool mosOvrHrd = false;
        public bool mosOvrStg = false;
    }
}
