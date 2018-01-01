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
        public int EtageVoulu;
        public int EtageActuel;

        public Personnage(Vector2 _position) : base(Assets.Personnage, _position)
        {
            //EtageVoulu = _etage;
            Console.WriteLine("Un de plus !");
        }

        public override void Update(float time)
        {
            base.Update(time);
        }

        public void Draw(SpriteBatch batch, float y)
        {
            batch.Draw(Texture, new Vector2(Position.X,y), null, Color.White, 0, Vector2.Zero, 1f, Effect, 1f);
        }
    }
}
