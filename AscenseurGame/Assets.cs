using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscenseurGame
{
    public class Assets
    {
        #region Variable
        public static Texture2D Ascenseur, Personnage;
        public static SpriteFont Pixel;
        #endregion

        #region Methode
        public static void LoadAll()
        {
            Ascenseur = Main.Content.Load<Texture2D>("ascenceur");
            Personnage = Main.Content.Load<Texture2D>("personnage");
            Pixel = Main.Content.Load<SpriteFont>("pixel");
        }
        #endregion
    }
}
