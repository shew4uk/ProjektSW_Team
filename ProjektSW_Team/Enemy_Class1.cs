using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class Enemy_Class1 : Element
    {
        public int EnemyX { get; set; }
        public Player Player { get; set; }
        public int EnemyY { get; set; }
        private Canvas _canvas;
        public Enemy_Class1 enemyClass1 { get; set; }
        public int Enemy_Hp;
        private double Moving;
        public int Enemy_Damage;

        public Enemy_Class1()
        {
            Enemy_Hp = 60;
            Enemy_Damage = 10;

            _canvas = new Canvas(new Size(1, 1));
            _canvas.Fill(Color.Green);
        }

        public void Move(Point delta)
        {
            Point newPosition = new Point(Position.X + delta.X, Position.Y + delta.Y);
            if (Time.NowSeconds - Moving > 0.8)
            {
                Moving = Time.NowSeconds;
                if (EnemyX > Player.Position.X + 4 ) 
                {
                    EnemyX += 1;
                }
                else if (EnemyX < Player.Position.X - 4)
                {
                    EnemyX -= 1;
                }
                else if (EnemyY > Player.Position.Y + 4)
                {
                    EnemyY -= 1;
                }
                else if (EnemyY < Player.Position.Y - 4)
                {
                    EnemyX += 1;
                }
            }
        }

        

        protected override void OnRender()
        {
            throw new NotImplementedException();
        }
    }
}
