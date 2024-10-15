using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using ProjektSW_Team.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class BulletObject : Element, IObject
    {
        public int LifeTime = 12;
        public Point Direction;
        public Canvas Canvas;
        public double LastMoveTime;

        public bool CanWalk { get; set; } = false;
        public bool ShouldBeRemoved { get; set; }

        public BulletObject() 
        {
            Canvas = new Canvas(new Size(1,1));
            Canvas.Fill(Color.MediumPurple);

        }
        public void Action()
        {

        }

        public override void Update()
        {
            if (TheWorld.Instance.IsIntersectingObject(Position, true, out IObject Target))
            {
                if (Target is IBecomeDamadge ibecomedamadge)
                {
                    ibecomedamadge.BecomeDamadge(60);
                    ShouldBeRemoved = true;
                }
            }
            Canvas.Position = Position;
            Canvas.Update();

            if (Time.NowSeconds - LastMoveTime >= 0.2)
            {
                LastMoveTime = Time.NowSeconds;
                Position = new Point(Position.X + Direction.X, Position.Y + Direction.Y);
                LifeTime -= 1;
                if(LifeTime <= 0)
                {
                    ShouldBeRemoved = true;
                }

            }
        }

        protected override void OnRender()
        {
            Canvas.Render();   
        }
    }
}
