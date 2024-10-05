using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class Bullet : Element, BulletObject
    {
        public int BulletX { get; set; }
        public int BulletY { get; set; }
        public Canvas Canvas { get; set; }

        List<Bullet> bullets = new List<Bullet>();
        public Bullet()
        {
            Canvas = new Canvas(new Size());
            Canvas.CellWidth = 1;
        }
        public void schoot()
        {
            Bullet newBullet = new Bullet();
            bullets.Add(newBullet);
            Canvas.Fill(Color.White);
        }

        protected override void OnRender()
        {
            

        }
        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Bullet newBullet = null; 

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        
                        break;
                    case ConsoleKey.A:
                        
                        break;
                    case ConsoleKey.D:
                        
                        break;
                    case ConsoleKey.S:
                        
                        break;
                }
            }
        }

        public void Action()
        {
            throw new NotImplementedException();
        }
    }
}
