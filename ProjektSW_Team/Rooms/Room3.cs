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
    internal class Room3 : Room
    {
        public Room3() : base()
        {
            Objects.Add(new Obstacle(new Size(10, 1), Color.DarkGray) { Position = new Point(18, 0) });
            Objects.Add(new Obstacle(new Size(10, 1), Color.DarkGray) { Position = new Point(32, 0) });
            Objects.Add(new Obstacle(new Size(29, 1), Color.DarkGray) { Position = new Point(12, 19) });
            Objects.Add(new Obstacle(new Size(2, 4), Color.DarkGray) { Position = new Point(40, 0) });
            Objects.Add(new Obstacle(new Size(2, 13), Color.DarkGray) { Position = new Point(40, 7) });
            Objects.Add(new Obstacle(new Size(2, 10), Color.DarkGray) { Position = new Point(0, 9) });
            Objects.Add(new Obstacle(new Size(19, 1), Color.DarkGray) { Position = new Point(0, 9) });
            Objects.Add(new Obstacle(new Size(2, 10), Color.DarkGray) { Position = new Point(18, 0) });

            Objects.Add(new Obstacle(new Size(8, 1), Color.DarkGray){ Position = new Point(0, 19) });
            Objects.Add(new Door() { Position = new Point(28, 0), Size = new Size(4, 1), Room = typeof(Room2), PlayerX = 9, PlayerY = 18 });
            Objects.Add(new Door() { Position = new Point(8, 19), Size = new Size(4, 1), Room = typeof(Room4), PlayerX = 9, PlayerY = 1 });
            Objects.Add(new Door() { Position = new Point(40, 4), Size = new Size(2, 3), Room = typeof(Room3_2), PlayerX = 2, PlayerY = 5 });

           
            Objects.Add(new Trap() { Position = new Point(38, 1), Size = new Size(2, 1) });

            

            
            Objects.Add(new Trap() { Position = new Point(20, 1), Size = new Size(2, 1) });




            Objects.Add(new Trap() { Position = new Point(2, 10), Size = new Size(2, 1) });

            Objects.Add(new Trap() { Position = new Point(2, 18), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(38, 10), Size = new Size(2, 1) });
            Objects.Add(new Trap() { Position = new Point(38, 18), Size = new Size(2, 1) });

            Objects.Add(new Enemy_Class { Position = new Point(10, 18), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(7, 18), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(35, 5), Size = new Size(1, 1) });
            Objects.Add(new Enemy_Class { Position = new Point(35, 7), Size = new Size(1, 1) });
        }

        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(42, 40);
            Rooms.Fill(Color.Red);

            Rooms.FillRect(0, 0, 18, 9, Color.Black);
            Rooms.FillRect(0, 20, 42, 9, Color.Black);
            Rooms.FillRect(20, 1, 20, 18, Color.DarkOliveGreen);
            Rooms.FillRect(1, 10, 39, 9, Color.DarkOliveGreen);
        }
    }
}
