﻿using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class Room4 : Room
    {
        public Room4() : base()
        {
            doors.Add(new Door() { Position = new Point(8, 0), Size = new Size(4, 1), Room = typeof(Room3), PlayerX = 9, PlayerY = 18 });

        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(20, 20);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 18, 18, Color.Gray);
        }
    }
}
