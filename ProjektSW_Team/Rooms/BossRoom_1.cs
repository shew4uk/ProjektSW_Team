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
            Objects.Add(new Door() { Position = new Point(49, 8), Size = new Size(1, 4), Room = typeof(BossRoom), PlayerX = 1, PlayerY = 10 });
            //Objects.Add(new Enemy_Class { Position = new Point(10, 20),Size = new Size(1,1) });
            Objects.Add(TheWorld.Instance.dashingBoss = new DashingBoss { Position = new Point(10, 20), Size = new Size(10, 5) });
        }
        public override void DrawRoom(Canvas Rooms)
        {
            Rooms.CanvasSize = new Size(50, 30);
            Rooms.Fill(Color.DarkGray);
            Rooms.FillRect(1, 1, 48, 28, Color.DarkOliveGreen);
        }
        public override void Update()
        {
            base.Update();
            if (TheWorld.Instance.dashingBoss.IsDead)
            {
                Objects.Add(new Door() { Position = new Point(49, 8), Size = new Size(1, 4), Room = typeof(BossRoom), PlayerX = 1, PlayerY = 10 });
            }
        }
    }
}
