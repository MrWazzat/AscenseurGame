using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscenseurGame
{
    public class Personnage : Sprite
    {
        public SpriteEffects Effect;
        public Personnage(Vector2 _position) : base(Assets.Personnage, _position)
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch batch, float y)
        {
            //base.Draw(batch);
            batch.Draw(Texture, new Vector2(Position.X,y), null, Color.White, 0, Vector2.Zero, 1f, Effect, 1f);
        }
    }
}
