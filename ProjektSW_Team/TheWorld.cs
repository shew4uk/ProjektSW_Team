using FastConsole.Engine.Elements;
using ProjektSW_Team.Rooms;
using System;
using System.Collections.Generic;
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
        private PlayerDrawer PlayerDrawer { get; set; }

        public void UseTP(Door door)
        {
            SwitchRoom(door.Room);
            Player.PlayerX = door.PlayerX;
            Player.PlayerY = door.PlayerY;
        }
        public TheWorld ()  // Нову кімнату сюда
        { 
            Rooms.Add(typeof(Room1), new Room1());
            Rooms.Add(typeof(Room2), new Room2());
            Rooms.Add(typeof (Room3), new Room3());
            Rooms.Add(typeof(Room3_1), new Room3_1());
            Rooms.Add(typeof(Room4), new Room4());
            Rooms.Add(typeof(Room3_2), new Room3_2());

            Player = new Player(1, 3, 5, 10, 10);
            PlayerDrawer = new PlayerDrawer(Player);
        } 
        public void SwitchRoom(Type roomType)
        {
            CurrentRoom = Rooms[roomType];
        }
        public override void Update()
        {
            CurrentRoom.Update();
            PlayerDrawer.Update();
            foreach(Door door in CurrentRoom.doors)
            {
                if (Player.PlayerX >= door.Position.X && Player.PlayerY >= door.Position.Y && Player.PlayerX < door.Position.X + door.Size.Width && Player.PlayerY < door.Position.Y + door.Size.Height)
                {
                    UseTP(door);
                }
            }
        }

        protected override void OnRender()
        {
            CurrentRoom.Render();
            PlayerDrawer.Render();
            
        }
    }
}
