using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{

    internal class Room1 : Room
    {
        public Room1() : base()
        {
            doors.Add(new Door() { Position = new Point(8,19), Size = new Size(4,1), Room = typeof(Room2), PlayerX = 9, PlayerY = 1});
            
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(20, 20);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 18, 18, Color.Gray);
        }
    }
}
