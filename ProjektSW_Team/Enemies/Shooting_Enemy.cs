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
    internal class Shooting_Enemy : Element, IObject, IBecomeDamadge
    {
        public int Enemy_Hp;
        public int Enemy_Damage;
        private Canvas _canvas;
        public Shooting_Enemy()
        {
            Enemy_Hp = 60;
            Enemy_Damage = 10;
            _canvas = new Canvas(new Size(1, 1));
        }

        public bool CanWalk { get; set; } = true;
        public double LastHit { get; private set; }
        public double LastMove { get; private set; }
        public bool ShouldBeRemoved => Enemy_Hp < 0;
        public double CoolDown { get; private set; }
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

            if (Time.NowSeconds - LastMove > 0.4)
            {
                LastMove = Time.NowSeconds;
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


                void Ilumination(Point Direction)
                {
                    if (Time.NowSeconds - CoolDown > 0.5)
                    {
                        CoolDown = Time.NowSeconds;
                        TheWorld.Instance.CurrentRoom.Objects.Add(new BulletObject { Direction = Direction, Position = Position });
                    }

                }

                if (Position.X == player.Position.X && Position.Y > player.Position.Y)
                {

                    Ilumination(new Point(0, 1));

                }
                else if (Position.X == player.Position.X && Position.Y < player.Position.Y)
                {
                    Ilumination(new Point(0, -1));
                }
                if (Position.Y ==player.Position.Y && Position.X > player.Position.X)
                {
                    Ilumination(new Point(-1, 0));
                }
                else if (Position.Y==player.Position.Y && Position.X < player.Position.X)
                {
                    Ilumination(new Point(1,0));
                }

            }

        }
        protected override void OnRender()
        {
            _canvas.Render();
        }
    }
}
