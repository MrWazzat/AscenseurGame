using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace AscenseurGame
{
    public class Assets
    {
        #region Variable
        public static Texture2D Ascenseur, Personnage, Couloir, Patron, Secretaire;
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
            Secretaire = Main.Content.Load<Texture2D>("Secretaire");
            //FONT
            Pixel = Main.Content.Load<SpriteFont>("pixel");
            //SOUND

        }
        #endregion
    }
}
