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
    internal class BlobBoss : Element, IObject, IBecomeDamadge
    {
        public int Enemy_Hp;
        public int Enemy_Damage;
        private Canvas _canvas;
        public BlobBoss()
        {
            Enemy_Hp = 600;
            Enemy_Damage = 10;
            _canvas = new Canvas(new Size(5, 5));
            _canvas.Fill(Color.SaddleBrown);
        }

        public bool CanWalk { get; set; } = true;
        public double LastHit { get; private set; }
        public double LastMove { get; private set; }
        public bool ShouldBeRemoved => Enemy_Hp < 0;
        public Cocoon Cocoon { get; set; } 

        public void Action()
        {

            if (Time.NowSeconds - LastHit > 0.8)
            {
                LastHit = Time.NowSeconds;
                TheWorld.Instance.Player.TakeDamage(5);
            }
        }

        public void BecomeDamadge(int Damadge)
        {
            Enemy_Hp -= Damadge;
        }

        public override void Update()
        {

            _canvas.Position = Position;

            _canvas.Update();

            if (Time.NowSeconds - LastMove > 5)
            {
                LastMove = Time.NowSeconds;
                Player player = TheWorld.Instance.Player;
                if (Cocoon == null || Cocoon.ShouldBeRemoved == true)
                {
                    TheWorld.Instance.CurrentRoom.Objects.Add(Cocoon = new Cocoon { Position = new Point(16, 15), Size = new Size(1, 1) });
                }
                

            }
        }
        protected override void OnRender()
        {
            _canvas.Render();
        }
    }
}
