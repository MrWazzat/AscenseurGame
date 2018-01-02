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
    public class Screen
    {
        public SpriteBatch Batch;

        public Screen()
        {
            Batch = new SpriteBatch(Main.Device);
        }

        public virtual void Create()
        {

        }

        public virtual void Update(float time)
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void Dispose()
        {
            Batch.Dispose();
        }
    }

    public class GameScreen : Screen
    {
        public Ascenseur Asc;
        public List<Button> HUD;
        public List<Personnage> Employees;
        public List<Couloir> Couloirs;

        public float TimerClients;


        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            Employees = new List<Personnage>();
            Asc = new Ascenseur(new Vector2(30, Utils.ETAGE_1));
            Couloir.X = Asc.Texture.Width + 30;
            Couloirs = new List<Couloir>()
            {
                new Couloir(new Vector2(Couloir.X, Utils.ETAGE_1), 1),
                new Couloir(new Vector2(Couloir.X, Utils.ETAGE_2), 2),
                new Couloir(new Vector2(Couloir.X, Utils.ETAGE_3), 3),
                new Couloir(new Vector2(Couloir.X, Utils.ETAGE_4), 4)
            };


            HUD = new List<Button>
            {
                new Button(new Vector2(Couloir.X, Utils.ETAGE_1), "1"),
                new Button(new Vector2(Couloir.X, Utils.ETAGE_2), "2"),
                new Button(new Vector2(Couloir.X, Utils.ETAGE_3), "3"),
                new Button(new Vector2(Couloir.X, Utils.ETAGE_4), "4")
            };

            HUD[0].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 1"); Asc.Move(Keys.Down, Utils.ETAGE_1, Asc.Vitesse); } };
            HUD[1].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 2"); Asc.Move(Keys.Down, Utils.ETAGE_2, Asc.Vitesse); } };
            HUD[2].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 3"); Asc.Move(Keys.Down, Utils.ETAGE_3, Asc.Vitesse); } };
            HUD[3].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 4"); Asc.Move(Keys.Down, Utils.ETAGE_4, Asc.Vitesse); } };

        }

        public override void Update(float time)
        {
            TimerClients += time;
            if(TimerClients > 200)
            {
                int numeroCouloir = Main.Rand.Next(4);

                if (Couloirs[numeroCouloir].Clients.Count <= 16)
                    Couloirs[numeroCouloir].AddClients(new Personnage(Vector2.Zero));

                TimerClients = 0;
            }
            Asc.Update(time);
            foreach (Couloir couloir in Couloirs)
            {
                couloir.Update(time);
            }
            foreach (Button button in HUD)
            {
                button.Update(time);
            }
            if (Employees.Count > 0)
            {
                foreach (Personnage per in Employees)
                {
                    per.Update(time);
                }
            }
        }

        public override void Draw()
        {
            Batch.Begin();
            Asc.Draw(Batch);
            foreach (Couloir couloir in Couloirs)
            {
                couloir.Draw(Batch);
            }
            
            foreach (Button button in HUD)
            {
                button.Draw(Batch);
            }
            if (Employees.Count > 0)
            {
                foreach (Personnage per in Employees)
                {
                    per.Draw(Batch);
                }
            }
            Batch.End();
        }
    }
}
