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
        public static Texture2D Ascenseur, Personnage, Couloir, Patron;
        public static SpriteFont Pixel;
        public static SoundEffect OpenAsc, MoveAsc;
        #endregion

        #region Methode
        public static void LoadAll()
        {
            //SPRITE
            Ascenseur = Main.Content.Load<Texture2D>("ascenceur");
            Personnage = Main.Content.Load<Texture2D>("personnage");
            Couloir = Main.Content.Load<Texture2D>("Couloir");
            Patron = Main.Content.Load<Texture2D>("patron");
            //FONT
            Pixel = Main.Content.Load<SpriteFont>("pixel");
            //SOUND

        }
        #endregion
    }
}
