using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AscenseurGame
{
    public class Couloir
    {
        public Texture2D Texture;
        public Vector2 Position;
        public int NumeroEtage;

        public List<Personnage> Clients;

        public Couloir(Vector2 _position, int _numEtage)
        {
            Texture = Assets.Couloir;
            Position = _position;
            NumeroEtage = _numEtage;

            Clients = new List<Personnage>();
        }

        public void Update(float time)
        {
            if (Input.KeyPressed(Keys.D, true))
                AddClients(new Personnage(new Vector2(Position.X + (Texture.Width - Assets.Personnage.Width))));
            //AddClients(new Personnage(new Vector2(300,300)));

            foreach (Personnage cl in Clients)
                cl.Update(time);
        }

        public void AddClients(Personnage _perso)
        {
            _perso.Position.X = Position.X + (Texture.Width - Assets.Personnage.Width);
            float diffPerso = Texture.Height - _perso.Texture.Height; 
            switch(NumeroEtage)
            {
                case 1:
                    _perso.Position.Y = Utils.ETAGE_1 + diffPerso;
                    break;
                case 2:
                    _perso.Position.Y = Utils.ETAGE_2 + diffPerso;
                    break;
                case 3:
                    _perso.Position.Y = Utils.ETAGE_3 + diffPerso;
                    break;
                case 4:
                    _perso.Position.Y = Utils.ETAGE_4 + diffPerso;
                    break;
            }

            if (Clients.Count == 0)
                _perso.Move(Keys.Left, 200, 2500);
            else
                _perso.Move(Keys.Left, 60 + Clients[Clients.Count - 1].TweenEnd.X, 2500);
            Clients.Add(_perso);
            
        }

        public void Draw(SpriteBatch batch)
        {
            
            batch.Draw(Texture, Position, Color.White);
            foreach (Personnage cl in Clients)
                cl.Draw(batch);
        }
    }
}
