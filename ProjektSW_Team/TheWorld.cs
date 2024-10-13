using FastConsole.Engine.Elements;
using ProjektSW_Team.Rooms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team
{
    internal class TheWorld : Element
    {

        private Dictionary<Type, Room> Rooms = new Dictionary<Type, Room>();
        public Room CurrentRoom { get; set; }
        public Player Player { get; set; }
        public static TheWorld Instance { get; private set; }


        public void UseTP(Door door)
        {
            SwitchRoom(door.Room);
            Player.Position = new Point(door.PlayerX, door.PlayerY);

        }
        public TheWorld()  // Нову кімнату сюда
        {
            Rooms.Add(typeof(Room1), new Room1());
            Rooms.Add(typeof(Room2), new Room2());
            Rooms.Add(typeof(Room3), new Room3());
            Rooms.Add(typeof(Room3_1), new Room3_1());
            Rooms.Add(typeof(Room4), new Room4());
            Rooms.Add(typeof(Room3_2), new Room3_2());
            Rooms.Add(typeof(BossRoom), new BossRoom());
            Instance = this;

            Player = new Player();



        }
        public void SwitchRoom(Type roomType)
        {
            CurrentRoom = Rooms[roomType];
        }
        public override void Update()
        {

            CurrentRoom.Update();
            Player.Update();
            if (IsIntersectingObject(Player.Position, true, out IObject target))
            {
                target.Action();
            }

        }

        public bool IsIntersectingObject(Point Position, bool IsWalkable, out IObject Target)
        {
            foreach (IObject @object in CurrentRoom.Objects.Where(@object => @object.CanWalk == IsWalkable))
            {
                if (Position.X >= @object.Position.X && Position.Y >= @object.Position.Y && Position.X < @object.Position.X + @object.Size.Width && Position.Y < @object.Position.Y + @object.Size.Height)
                {
                    Target = @object;
                    return true;
                }
            }
            Target = null;
            return false;
        }

        protected override void OnRender()
        {
            CurrentRoom.Render();
            Player.Render();

        }
    }
}