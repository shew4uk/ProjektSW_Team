﻿using FastConsole.Engine.Core;
using FastConsole.Engine.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSW_Team.Enemies
{
    internal class Cocoon : Element, IObject, IBecomeDamadge
    {
        public int Enemy_Hp;
        public int Enemy_Damage;
        private Canvas _canvas;
        public Cocoon()
        {
            Enemy_Hp = 100;
            Enemy_Damage = 10;
            _canvas = new Canvas(new Size(1, 1));
            _canvas.Fill(Color.LightSlateGray);
        }

        public bool CanWalk { get; set; } = true;
        public double LastHit { get; private set; }
        public double LastMove { get; private set; }
        public bool ShouldBeRemoved => Enemy_Hp < 0;

        public void BecomeDamadge(int Damadge)
        {
            Enemy_Hp -= Damadge;
        }
        public void Action()
        {

            if (Time.NowSeconds - LastHit > 0.8)
            {
                LastHit = Time.NowSeconds;
                TheWorld.Instance.Player.TakeDamage(5);
            }
        }

        public override void Update()
        {

            _canvas.Position = Position;

            _canvas.Update();

            if (Time.NowSeconds - LastMove > 5)
            {
                LastMove = Time.NowSeconds;
                Player player = TheWorld.Instance.Player;
                TheWorld.Instance.CurrentRoom.Objects.Add(new Enemy_Class { Position = Position, Size = new Size(1, 1) });

            }
        }
        protected override void OnRender()
        {
            _canvas.Render();
        }
    }
}