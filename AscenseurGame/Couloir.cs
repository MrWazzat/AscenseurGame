using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AscenseurGame
{
    public class Couloir
    {
        public static float X;
        public Texture2D Texture;
        public Vector2 Position;
        public int NumeroEtage;
        public bool Vidage;
        public float TimerVidage;

        public List<Personnage> Clients;

        public Couloir(Vector2 _position, int _numEtage)
        {
            Texture = Assets.Couloir;
            Position = _position;
            NumeroEtage = _numEtage;

            Clients = new List<Personnage>();
            Vidage = false;
        }

        public void Update(float time)
        {
            if (Vidage)
            {
                if (Clients.Count > 0)
                {
                    TimerVidage += time;
                    if (TimerVidage >= 500)
                    {
                        if (!Clients[0].InMove)
                        {
                            GameScreen.Asc.AddClient(Clients[0]);
                            Clients.Remove(Clients[0]);
                            foreach (Personnage perso in Clients)
                            {
                                perso.UpdatePosition();
                            }
                        }
                        TimerVidage = 0;
                    }
                }
            }


            foreach (Personnage cl in Clients)
                cl.Update(time);
        }

        public void AddClients(Personnage _perso)
        {
            _perso.Position.X = Position.X + (Texture.Width - Assets.Personnage.Width);
            float diffPerso = Texture.Height - _perso.Texture.Height;
            switch (NumeroEtage)
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
                _perso.Move(Keys.Left, 30 + Clients[Clients.Count - 1].TweenEnd.X, 2500);
            Clients.Add(_perso);

        }

        public int GetIndex(Personnage _perso)
        {
            return Clients.IndexOf(_perso);
        }

        public void RemoveClient(Personnage _perso)
        {
            if (Clients.Contains(_perso))
            {
                Clients.Remove(_perso);
            }
        }

        public void Draw(SpriteBatch batch)
        {

            batch.Draw(Texture, Position, Color.White);
            foreach (Personnage cl in Clients)
                cl.Draw(batch);
        }
    }
}
