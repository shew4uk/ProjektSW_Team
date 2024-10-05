using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;



namespace ProjektSW_Team
{
    internal class Fight_box : Element
    {

        public Player player { get; set; }
        public Enemy_Class enemy { get; set; }
        public bool Player_Move;

        public Fight_box()
        {
            player = player;
            enemy = enemy;
            Player_Move = true;
        }
        public override void Update()
        {
            Moveses();
        }

        protected override void OnRender()
        {

        }


        public int Player_Attack()
        {
            enemy.Enemy_Hp -= player.Damage;

            return enemy.Enemy_Hp;
        }
        public int Enemy_Attack()
        {
            player.Health -= enemy.Enemy_Damage;

            return player.Health;
        }
        public bool Moveses()
        {
            if (Player_Move == true)
            {
                Player_Attack();
                return Player_Move = false;
            }
            else if (Player_Move == false)
            {
                Enemy_Attack();
                return Player_Move = true;
            }
            return Player_Move;
            
        }
        
    }
}
