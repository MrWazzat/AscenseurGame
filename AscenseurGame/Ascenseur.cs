﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AscenseurGame
{
    public class Ascenseur : Sprite
    {
        public List<Personnage> Clients;

        public Ascenseur(Vector2 _position) : base(Assets.Ascenseur, _position)
        {
            Clients = new List<Personnage>();
        }

        public override void Update(float time)
        {
            base.Update(time);
            if (Input.Right(true))
            {
                AddClient(new Personnage(new Vector2(-20, -20)));
            }
        }

        public void AddClient(Personnage _perso)
        {
            _perso.Position = new Vector2(Position.X + Main.Rand.Next(0, Texture.Width - 38), Position.Y + (Texture.Height - 71));
            _perso.Effect = (Main.Rand.Next(2) == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Clients.Add(_perso);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            foreach (Personnage cl in Clients)
                cl.Draw(batch, Position.Y + (Texture.Height - 71));
        }
    }
}
