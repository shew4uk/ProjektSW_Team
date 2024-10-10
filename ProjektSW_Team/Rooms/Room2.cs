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
            Objects.Add(new Obstacle(new Size(8, 1), Color.DarkGray) { Position = new Point(0, 0) });
            Objects.Add(new Obstacle(new Size(2, 20), Color.DarkGray) { Position = new Point(0, 0) });
            Objects.Add(new Obstacle(new Size(8, 1), Color.DarkGray) { Position = new Point(12, 0) });
            Objects.Add(new Obstacle(new Size(2, 10), Color.DarkGray) { Position = new Point(19, 0) });
            Objects.Add(new Obstacle(new Size(20, 1), Color.DarkGray) { Position = new Point(20, 9) });
            Objects.Add(new Obstacle(new Size(2, 4), Color.DarkGray) { Position = new Point(40, 9) });
            Objects.Add(new Obstacle(new Size(2, 4), Color.DarkGray) { Position = new Point(40, 16) });
            Objects.Add(new Obstacle(new Size(25, 1), Color.DarkGray) { Position = new Point(12, 19) });
            Objects.Add(new Obstacle(new Size(8, 1), Color.DarkGray) { Position = new Point(0, 19) });
            Objects.Add(new Door() { Position = new Point(8, 0), Size = new Size(4, 1), Room = typeof(Room1), PlayerX = 9 , PlayerY = 18});
            Objects.Add(new Door() { Position = new Point(8, 19), Size = new Size(4, 1), Room = typeof(Room3), PlayerX = 29, PlayerY = 1 });
            Objects.Add(new Door() { Position = new Point(40, 13), Size = new Size(2, 3), Room = typeof(Room3_1), PlayerX = 2, PlayerY = 5 });
            
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
