using FastConsole.Engine.Elements;
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
            doors.Add(new Door() { Position = new Point(20, 4), Size = new Size(2, 3), Room = typeof(Room3_1), PlayerX = 2, PlayerY = 14 });
            doors.Add(new Door() { Position = new Point(0, 4), Size = new Size(2, 3), Room = typeof(Room3), PlayerX = 38, PlayerY = 5 });

        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(22, 16);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(2, 1, 18, 14, Color.DimGray);
        }
    }
}
