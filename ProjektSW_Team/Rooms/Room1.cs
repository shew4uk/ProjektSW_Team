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

    internal class Room1 : Room
    {
        public Room1() : base()
        {
            Objects.Add(new Door() { Position = new Point(8,19), Size = new Size(4,1), Room = typeof(Room2), PlayerX = 9, PlayerY = 1});
            Objects.Add(new Trap() { Position = new Point(7, 5), Size = new Size(2, 1) });
            Objects.Add(new Obstacle(new Size(2,1), Color.SaddleBrown) {Position = new Point (9, 5)});
            Objects.Add(new Obstacle(new Size(20, 1), Color.DarkGray) { Position = new Point(0, 0) });

            Objects.Add(new Enemy_Class { Position = new Point(10, 20), Size = new Size(1, 1) });

            Objects.Add(new Enemy_Class { Position = new Point(9, 12), Size = new Size(1, 1) });



        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(20, 20);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 18, 18, Color.Gray);
        }
    }
}
