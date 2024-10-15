using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System.Drawing;

namespace ProjektSW_Team
{
    internal class Player : Element
    {
        public List<IObject> Objects = new List<IObject>();
        public bool IsAlive;
        private Canvas _canvas;
        private bool isAlive;
        public int _health;
        public int MaxHealth;
        public int Damage;
        public int Sheild_Hp;
        



        public Player()
        {
            Health = 100;
            MaxHealth = 100;
            Damage = 15;
            
            IsAlive = true;
            Position = new Point(5, 5);

            
            

            _canvas = new Canvas(new Size(1,1));
            _canvas.Fill(Color.White);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            
        }

        public void Move(Point delta)
        {
            Point newPosition = new Point(Position.X + delta.X, Position.Y + delta.Y);

            if (TheWorld.Instance.IsIntersectingObject(newPosition,false,out IObject _)== false)
            {
                Position = newPosition;
            }
        }



        public int Health
        {
            get => _health; 
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    isAlive = false;
                    _health = 0;
                }
            }
        }

        public double CoolDown { get; private set; }

        public void DisplayInfo()
        {
            Renderer.SetCursorPosition(40, 1);
            Renderer.Write($"Health: {Health}/{MaxHealth}, Damage: {Damage}, Alive: {isAlive}");
        }
        public override void Update()
        {
            _canvas.Position = Position;
            _canvas.Update();
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {

                    case ConsoleKey.O:
                        Program.IsDoorOpen = !Program.IsDoorOpen;
                        break;
                    case ConsoleKey.UpArrow:
                        Move(new Point(0, -1));
                        break;
                    case ConsoleKey.DownArrow:
                        Move(new Point(0, 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(new Point(-1, 0));
                        break;
                    case ConsoleKey.RightArrow:
                        Move(new Point(1, 0));
                        break;

                    case ConsoleKey.W:
                        Ilumination(new Point(0, -1));
                        break;
                    case ConsoleKey.A:
                        Ilumination(new Point(-1, 0));
                        break;
                    case ConsoleKey.D:
                        Ilumination(new Point(1, 0));
                        break;
                    case ConsoleKey.S:
                        Ilumination(new Point(0, 1));
                        break;
                }
            }
        }

        public void Ilumination(Point Direction)
        {
            if (Time.NowSeconds - CoolDown > 0.5)
            {
                CoolDown = Time.NowSeconds;
                TheWorld.Instance.CurrentRoom.Objects.Add(new BulletObject { Direction = Direction, Position = Position });
            }
            
        }

        protected override void OnRender()
        {
            DisplayInfo();
            _canvas.Render();
        }

    }
}
