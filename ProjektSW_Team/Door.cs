﻿using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class Door : Element
    {
        public Canvas Canvas { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public Type Room {  get; set; }

        
        public override void Update()
        {
            Canvas.CanvasSize = Size;
            Canvas.Position = Position;
            Canvas.Fill(Color.SaddleBrown);
            Canvas.Update();
            
        }
        public Door() 
        { 
            Canvas = new Canvas(new Size());
            Canvas.CellWidth = 1;
        }
        protected override void OnRender()
        {
            Canvas.Render();
        }
    }
}
