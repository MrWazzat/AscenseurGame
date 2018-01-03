using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AscenseurGame
{
    public class Personnage : Sprite
    {
        public SpriteEffects Effect;
        public Couloir EtageActuel;

        public float TimerSaut;
        public bool AlreadyJumped;


        public Personnage(Vector2 _position, Couloir _couloir) : base(Assets.Personnage, _position)
        {
            int _texture = Main.Rand.Next(5);
            EtageActuel = _couloir;
            if (_texture == 0)
            {
                Texture = Assets.Patron;
            }
            else if(_texture == 1 || _texture == 2)
            {
                Texture = Assets.Personnage;
            }
            else if(_texture == 3 || _texture == 4)
            {
                Texture = Assets.Secretaire;
            }

            AlreadyJumped = false;
        }

        public override void Update(float time)
        {
            base.Update(time);
            if (InMove)
            {
                TimerSaut += time;
                if (TimerSaut >= 50)
                {
                    Position.Y -= 5;
                    if (TimerSaut >= 100)
                    {
                        Position.Y += 5;
                        TimerSaut = 0;
                    }
                }
            }
            else if (!InMove)
            {
                TimerSaut += time;
                if (TimerSaut >= 500)
                {
                    if (AlreadyJumped == false)
                    {
                        Position.Y -= 5;
                        AlreadyJumped = true;
                    }
                    if (TimerSaut >= 650)
                    {
                        Position.Y += 5;
                        TimerSaut = 0;
                        AlreadyJumped = false;
                    }
                }
            }



        }

        public void UpdatePosition()
        {
            int Index = EtageActuel.GetIndex(this);
            Position.Y = EtageActuel.Position.Y + (Assets.Couloir.Height - Texture.Height);
            if (Index == 0)
            {
                Move(Keys.Left, 200, 1500);
            }
            else
            {
                Move(Keys.Left, 30 + EtageActuel.Clients[Index - 1].TweenEnd.X, 1500);
            }
        }

        public void Draw(SpriteBatch batch, float y)
        {
            batch.Draw(Texture, new Vector2(Position.X, y), null, Color.White, 0, Vector2.Zero, 1f, Effect, 1f);
        }
    }
}
