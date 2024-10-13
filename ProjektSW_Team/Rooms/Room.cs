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

        public Size WorldSize => Canvas.CanvasSize;
        public List<IObject> Objects = new List<IObject>();
        
        


        public Canvas Canvas { get; set; }
        public Room() 
        { 
            Canvas = new Canvas(new Size());
            Canvas.CellWidth = 1;
            DrawRoom(Canvas);
        }

        public bool IsPointInsideMap(Point point)
        {
            if (point.X < 1 || point.Y < 1)
                return false;

            if (point.X >= WorldSize.Width - 1 || point.Y >= WorldSize.Height - 1)
                return false;

            return true;
        }

        protected override void OnRender()
        {
            Canvas.Render();
            for (int i = 0; i < Objects.Count; i++)
            {
                IObject @object = Objects[i];
                @object.Render();
            } 
            
        }
        public override void Update()
        {
            Canvas?.Update();
            for (int i = 0; i < Objects.Count; i++)
            {
                IObject @object = Objects[i];
                @object.Update();
            }

        }



        public abstract void DrawRoom(Canvas Rooms);

    }
}
