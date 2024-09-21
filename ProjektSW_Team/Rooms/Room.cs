using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjektSW_Team.Rooms
{
    abstract class Room : Element
    {
        public List<Door> doors = new List<Door>();
        


        public Canvas Canvas { get; set; }
        public Room() 
        { 
            Canvas = new Canvas(new Size());
            Canvas.CellWidth = 1;
            DrawRoom(Canvas);
        }
        protected override void OnRender()
        {
            Canvas.Render();
            foreach (Door door in doors)
            {
                door.Render();
            } 
            
        }
        public override void Update()
        {
            Canvas?.Update();
            foreach (Door door in doors)
            {
                door.Update();
            }

        }



        public abstract void DrawRoom(Canvas Rooms);

    }
}
