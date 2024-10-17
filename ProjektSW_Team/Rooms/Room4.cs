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
    internal class Room4 : Room
    {
        public Room4() : base()
        {
            Objects.Add(new Door() { Position = new Point(8, 0), Size = new Size(4, 1), Room = typeof(Room3), PlayerX = 9, PlayerY = 18 });
            Objects.Add(new Door() { Position = new Point(8, 19), Size = new Size(4, 1), Room = typeof(BossRoom), PlayerX = 9, PlayerY = 1 });
            Objects.Add(new Enemy_Class { Position = new Point(9, 18), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(6, 18), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(12, 18), Size = new Size(1, 1) });
            Objects.Add(new Trap() { Position = new Point(1, 1), Size = new Size(2, 1) });
<<<<<<< HEAD
=======
            Objects.Add(new Trap() { Position = new Point(18, 18), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(18, 1), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(1, 18), Size = new Size(2, 1) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(9, 8) });
            Objects.Add(new Obstacle(new Size(2, 1), Color.SaddleBrown) { Position = new Point(9, 10) });

>>>>>>> 0bc29b8d729eacc7af754a9f262ca64d1bb839b2
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(20, 20);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 18, 18, Color.DarkOliveGreen);
        }
    }
}
