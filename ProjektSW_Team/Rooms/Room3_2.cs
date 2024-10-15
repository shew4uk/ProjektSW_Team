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
            Objects.Add(new Enemy_Class { Position = new Point(12, 14), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(6, 14), Size = new Size(1, 1) });
            Objects.Add(new Trap() { Position = new Point(8, 6), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(8, 7), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(10, 6), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(10, 7), Size = new Size(2, 1) });
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(22, 16);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(2, 1, 18, 14, Color.DimGray);
        }
    }
}
