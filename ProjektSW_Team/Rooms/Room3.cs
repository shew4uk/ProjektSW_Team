using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class Room3 : Room
    {
        public Room3() : base()
        {
            doors.Add(new Door() { Position = new Point(28, 0), Size = new Size(4, 1), Room = typeof(Room2), PlayerX = 9, PlayerY = 18 });
            doors.Add(new Door() { Position = new Point(8, 19), Size = new Size(4, 1), Room = typeof(Room4), PlayerX = 9, PlayerY = 1 });
            doors.Add(new Door() { Position = new Point(40, 4), Size = new Size(2, 3), Room = typeof(Room3_2), PlayerX = 2, PlayerY = 5 });

        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(42, 40);
            Rooms.Fill(Color.DarkGray);

            Rooms.FillRect(0, 0, 18, 9, Color.Black);
            Rooms.FillRect(0, 20, 42, 9, Color.Black);
            Rooms.FillRect(20, 1, 20, 18, Color.GreenYellow);
            Rooms.FillRect(1, 10, 39, 9, Color.GreenYellow);
        }
    }
}
