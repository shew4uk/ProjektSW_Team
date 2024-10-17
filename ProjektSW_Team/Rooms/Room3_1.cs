using FastConsole.Engine.Elements;
using ProjektSW_Team.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class Room3_1 : Room
    {
        public Room3_1() : base()
        {
            Objects.Add(new Door() { Position = new Point(0, 4), Size = new Size(2, 3), Room = typeof(Room2), PlayerX = 38, PlayerY = 14 });
            Objects.Add(new Door() { Position = new Point(0, 13), Size = new Size(2, 3), Room = typeof(Room3_2), PlayerX = 18, PlayerY = 5 });
            Objects.Add(new Enemy_Class { Position = new Point(38, 18), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(38, 15), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(38, 12), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(38, 9), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(38, 6), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(38, 3), Size = new Size(1, 1) });
            Objects.Add(new Trap() { Position = new Point(2, 1), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(38, 18), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(38, 1), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(2, 18), Size = new Size(2, 1) });

        }

        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(42, 20);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(2, 1, 38, 18, Color.DarkKhaki);
        }
    }
}
