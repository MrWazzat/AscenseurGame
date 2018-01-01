using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscenseurGame
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position;

        public Tween Tween;

        public Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Tween = new Tween(0, Position, new Vector2(0, 0), 0);
        }

        public virtual void Update(float time)
        {
            if (Tween.time < Tween.duration)
            {
                Tween.time += time;
                Position.X = Ease.Easing(Tween.time, Tween.begin.X, Tween.change.X, Tween.duration, EaseFunction.EaseInOutQuint);
                Position.Y = Ease.Easing(Tween.time, Tween.begin.Y, Tween.change.Y, Tween.duration, EaseFunction.EaseInOutQuint);
            }

            //if (Input.Left(true))
            //{
            //    Move(Input.MousePos, 1000);
            //}
        }

        public void Move(Vector2 _new, float _duration)
        {
            Vector2 Change = new Vector2(_new.X - Position.X, _new.Y - Position.Y);
            //Vector2 Change = new Vector2(_new.X - Position.X, Position.Y);
            //Vector2 Change = new Vector2(_new.X - Position.X, _new.Y - Position.Y);

            Tween.begin = Position;
            Tween.change = Change;
            Tween.time = 0;
            Tween.duration = _duration;
        }

        public void Move(float y, float _duration)
        {
            //Vector2 Change = new Vector2(0, y - Position.Y);
            //Vector2 Change = new Vector2(_new.X - Position.X, Position.Y);
            //Vector2 Change = new Vector2(_new.X - Position.X, _new.Y - Position.Y);

            Tween.begin = Position;
            Tween.change.Y = y - Position.Y;
            Tween.time = 0;
            Tween.duration = _duration;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);

            ////DECOMMENTER SI BESOIN DE DESSINER LES HITBOX
            //Texture2D tex = Assets.CreateTexture(hitbox.Width, hitbox.Height, new Color(255, 0, 0, 50));
            //if (tex != null)
            //    batch.Draw(tex, hitbox, Color.White);
        }

    }
}
