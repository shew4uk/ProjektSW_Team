using FastConsole.Engine.Elements;
using ProjektSW_Team.Enemies;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class BossRoom : Room
    {
        public BossRoom() : base()
        {
            Objects.Add(new Door() { Position = new Point(8, 0), Size = new Size(4, 1), Room = typeof(Room4), PlayerX = 9, PlayerY = 18 });
            //Objects.Add(new Enemy_Class { Position = new Point(10, 20),Size = new Size(1,1) });
            Objects.Add(new Cocoon { Position = new Point(8, 15), Size = new Size(1, 1) });
            Objects.Add(new BlobBoss { Position = new Point(10, 20), Size = Size });
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(50, 30);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 48, 28, Color.DarkOliveGreen);
        }

    }
}