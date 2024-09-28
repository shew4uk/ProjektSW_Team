using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class Trap : Element, IObject
    {
        public Canvas Canvas { get; set; }
        
        public bool CanWalk { get; set; } = true;
        private double LastHit;

        protected override void OnRender()
        {
            Canvas.Render();
        }
        public Trap()
        {

            Canvas = new Canvas(new Size());
            Canvas.CellWidth = 1;
        }
        public override void Update()
        {
            Canvas.CanvasSize = Size;
            Canvas.Position = Position;
            Canvas.Fill(Color.Red);
            Canvas.Update();


        }

        public void Action()
        {
            
            if (Time.NowSeconds - LastHit > 0.8)
            {
                LastHit = Time.NowSeconds;
                TheWorld.Instance.Player.TakeDamage(5);
            }
        }
    }
}

