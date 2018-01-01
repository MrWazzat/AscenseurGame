using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscenseurGame
{
    public class Button
    {
        Texture2D Texture;
        Vector2 Position;
        public string Text;

        public Rectangle Hitbox;
        public event ButtonPressedEvent ZeEvent;

        public Button(Vector2 _position, string _text)
        {
            Texture = Utils.CreateTexture(150, 50, Color.AliceBlue);
            Position = _position;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            Text = _text;
        }

        public void Update(float time)
        {
            if(Hitbox.Contains(Input.MousePos))
            {
                if(Input.Left(true))
                {
                    ZeEvent.Invoke();
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);
            batch.DrawString(Assets.Pixel, Text, new Vector2(Position.X + 10, Position.Y + 10), Color.Black);
        }

        public delegate void ButtonPressedEvent();
    }
}
