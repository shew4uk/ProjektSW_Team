using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal interface IObject
    {
        Point Position { get; set; }
        Size Size { get; set; }
        bool CanWalk { get; set; }

        void Action();
        void Update();
        void Render();
        
    }
}
