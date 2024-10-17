using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Enemies
{
    internal class DashingBoss : Element, IObject, IBecomeDamadge
    {
        public int Enemy_Hp;
        public int Enemy_Damage;
        private Canvas _canvas;
        public DashingBoss()
        {
            Enemy_Hp = 500;
            Enemy_Damage = 10;
            _canvas = new Canvas(new Size(1, 1));
        }

        public bool CanWalk { get; set; } = true;
        public double LastHit { get; private set; }
        public double LastMove { get; private set; }
        public bool ShouldBeRemoved => Enemy_Hp < 0;
        public void Action()
        {

            if (Time.NowSeconds - LastHit > 0.8)
            {
                LastHit = Time.NowSeconds;
                TheWorld.Instance.Player.TakeDamage(5);
            }
        }

        public void BecomeDamadge(int Damadge)
        {
            Enemy_Hp -= Damadge;
        }
        public override void Update()
        {

            _canvas.Position = Position;
            _canvas.CanvasSize = Size;
            _canvas.Fill(Color.DarkRed);

            _canvas.Update();

                if (Time.NowSeconds - LastMove > 2.0)
                {
                    LastMove = Time.NowSeconds;
                    for (int i = 0; i < 12; i++)
                    {
                        Player player = TheWorld.Instance.Player;
                        if (Position.X < player.Position.X)
                        {
                            Point position = Position;
                            position.X++;
                            Position = position;
                        }
                        else if (Position.X > player.Position.X)
                        {
                            Point position = Position;
                            position.X--;
                            Position = position;
                        }
                        if (Position.Y < player.Position.Y)
                        {
                            Point position = Position;
                            position.Y++;
                            Position = position;
                        }
                        else if (Position.Y > player.Position.Y)
                        {
                            Point position = Position;
                            position.Y--;
                            Position = position;
                        }
                    }
                }
            

        }
        protected override void OnRender()
        {
            _canvas.Render();
        }
    }
}