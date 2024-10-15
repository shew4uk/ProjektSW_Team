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
    internal class Obstacle : Element, IObject
    {
        public Canvas Canvas { get; set; }
        
        public bool CanWalk { get; set; } = false;

        public bool ShouldBeRemoved => false;

        protected override void OnRender()
        {
            Canvas.Render();
        }
        public Obstacle(Size size, Color color)
        {
            
            Size = size;
            Canvas = new Canvas(size);
            Canvas.CellWidth = 1;
            Canvas.Fill(color);
        }
        public override void Update()
        {
            
            Canvas.Position = Position;
            
            Canvas.Update();


        }

        public void Action()
        {
            
        }
    }
}
