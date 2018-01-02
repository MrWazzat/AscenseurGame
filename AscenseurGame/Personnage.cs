using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AscenseurGame
{
    public class Personnage : Sprite
    {
        public SpriteEffects Effect;
        public int EtageVoulu;
        public int EtageActuel;

        public float TimerSaut;
        public bool AlreadyJumped;
        

        public Personnage(Vector2 _position) : base(Assets.Personnage, _position)
        {
            Texture = Main.Rand.Next(5) == 1 ? Assets.Patron : Assets.Personnage;
            Console.WriteLine("Un de plus !");
            AlreadyJumped = false;
        }

        public override void Update(float time)
        {
            //Console.WriteLine(InMove);
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

        public void Draw(SpriteBatch batch, float y)
        {
            batch.Draw(Texture, new Vector2(Position.X, y), null, Color.White, 0, Vector2.Zero, 1f, Effect, 1f);
        }
    }
}
