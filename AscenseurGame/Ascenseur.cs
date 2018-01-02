using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AscenseurGame
{
    public class Ascenseur : Sprite
    {
        public List<Personnage> Clients;
        public int ActualEtage;

        public float Vitesse;


        public Ascenseur(Vector2 _position) : base(Assets.Ascenseur, _position)
        {
            Clients = new List<Personnage>();
            Vitesse = 2500;
            Tween.function = EaseFunction.EaseInOutCirc;
            InMove = false;
        }

        public override void Update(float time)
        {
            base.Update(time);
            if (Input.Right(true))
            {
                AddClient(new Personnage(new Vector2(-20, -20)));
            }

            {
                if (Position.Y >= Utils.ETAGE_1 && Position.Y < Utils.ETAGE_2)
                    ActualEtage = 1;
                else if (Position.Y >= Utils.ETAGE_2 && Position.Y < Utils.ETAGE_3)
                    ActualEtage = 2;
                else if (Position.Y >= Utils.ETAGE_3 && Position.Y < Utils.ETAGE_4)
                    ActualEtage = 3;
                else if (Position.Y ==  Utils.ETAGE_4)
                    ActualEtage = 4;
            }
            //Console.WriteLine(ActualEtage);
        }

        public void AddClient(Personnage _perso)
        {
            _perso.Position = new Vector2(Position.X + Main.Rand.Next(0, Texture.Width - _perso.Texture.Width), Position.Y + (Texture.Height - _perso.Texture.Height));
            _perso.Effect = (Main.Rand.Next(2) == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Clients.Add(_perso);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            foreach (Personnage cl in Clients)
                cl.Draw(batch, Position.Y + (Texture.Height - cl.Texture.Height));
        }
    }
}
