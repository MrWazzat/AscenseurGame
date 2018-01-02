using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscenseurGame
{
    class Utils
    {
        //ETAGE ASCENSEUR
        public const float ETAGE_1 = 48;
        public const float ETAGE_2 = 176;
        public const float ETAGE_3 = 320;
        public const float ETAGE_4 = 480;

        //public const float POSITION_X_BUTTON = 200;


        //DESSIN DE HITBOX
        public static Texture2D CreateTexture(int w, int h, Color col)
        {
            Texture2D texture = new Texture2D(Main.Device, w, h);
            Color[] cols = new Color[w * h];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = col;
            }
            texture.SetData(cols);
            return texture;
        }

        public static int GetDistance(Sprite s1, Sprite s2)
        {
            return (int)Math.Sqrt(Math.Pow((s2.Position.X - s1.Position.X), 2) + Math.Pow((s1.Position.Y - s2.Position.Y), 2));
        }
    }
}
