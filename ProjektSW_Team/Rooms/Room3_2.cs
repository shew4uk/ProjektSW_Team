﻿using FastConsole.Engine.Elements;
using ProjektSW_Team.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class Room3_2 : Room
    {
        public Room3_2() : base()
        {
            Objects.Add(new Door() { Position = new Point(20, 4), Size = new Size(2, 3), Room = typeof(Room3_1), PlayerX = 2, PlayerY = 14 });
            Objects.Add(new Door() { Position = new Point(0, 4), Size = new Size(2, 3), Room = typeof(Room3), PlayerX = 38, PlayerY = 5 });
<<<<<<< HEAD
            Objects.Add(new Enemy_Class { Position = new Point(19, 15), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(2, 15), Size = new Size(1, 1) });
            Objects.Add(new Trap() { Position = new Point(9, 4), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(11, 4), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(9, 5), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(9, 6), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(11, 5), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(11, 6), Size = new Size(2, 1) });
=======
            Objects.Add(new Enemy_Class { Position = new Point(12, 14), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(6, 14), Size = new Size(1, 1) });
            Objects.Add(new Trap() { Position = new Point(2, 1), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(18, 14), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(18, 1), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(2, 14), Size = new Size(2, 1) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(9, 6) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(9, 7) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(11, 6) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(11, 7) });
>>>>>>> 0bc29b8d729eacc7af754a9f262ca64d1bb839b2
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(22, 16);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(2, 1, 18, 14, Color.DimGray);
        }
    }
}
