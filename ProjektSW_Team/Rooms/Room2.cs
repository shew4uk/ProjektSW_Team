using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class Room2 : Room
    {
        public Room2() : base()
        {
            doors.Add(new Door() { Position = new Point(8, 0), Size = new Size(4, 1), Room = typeof(Room1), PlayerX = 9 , PlayerY = 18});
            doors.Add(new Door() { Position = new Point(8, 19), Size = new Size(4, 1), Room = typeof(Room3), PlayerX = 29, PlayerY = 1 });
            doors.Add(new Door() { Position = new Point(40, 13), Size = new Size(2, 3), Room = typeof(Room3_1), PlayerX = 2, PlayerY = 5 });
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(42, 40);
            Rooms.Fill(Color.DarkGray);

            Rooms.FillRect(20, 0, 40, 9, Color.Black);
            Rooms.FillRect(0, 20, 42, 9, Color.Black);
            Rooms.FillRect(1, 1, 18, 18, Color.DarkOliveGreen);
            Rooms.FillRect(1, 10, 39, 9, Color.DarkOliveGreen);
        }
    }
}
