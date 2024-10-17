using FastConsole.Engine.Elements;
using ProjektSW_Team.Enemies;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Rooms
{
    internal class BossRoom_1 : Room
    {
        public BossRoom_1() : base()
        {
            Objects.Add(new Door() { Position = new Point(37, 8), Size = new Size(1, 4), Room = typeof(BossRoom), PlayerX = 14, PlayerY = 8 });
            //Objects.Add(new Enemy_Class { Position = new Point(10, 20),Size = new Size(1,1) });
            Objects.Add(new DashingBoss { Position = new Point(10, 20), Size = new Size(5, 5) });
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(50, 30);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 48, 28, Color.DarkOliveGreen);
        }

    }
}
