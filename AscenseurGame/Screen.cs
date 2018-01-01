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


        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            Employees = new List<Personnage>();
            Asc = new Ascenseur(new Vector2(30, Utils.ETAGE_1));
            Couloirs = new List<Couloir>()
            {
                new Couloir(new Vector2(Asc.Texture.Width + 30, Utils.ETAGE_1), 1),
                new Couloir(new Vector2(Asc.Texture.Width + 30, Utils.ETAGE_2), 2),
                new Couloir(new Vector2(Asc.Texture.Width + 30, Utils.ETAGE_3), 3),
                new Couloir(new Vector2(Asc.Texture.Width + 30, Utils.ETAGE_4), 4)
            };


            HUD = new List<Button>
            {
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_1), "Etage 1"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_2), "Etage 2"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_3), "Etage 3"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_4), "Etage 4")
            };

            HUD[0].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 1"); Asc.Move(Keys.Down, Utils.ETAGE_1, Asc.Vitesse); } };
            HUD[1].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 2"); Asc.Move(Keys.Down, Utils.ETAGE_2, Asc.Vitesse); } };
            HUD[2].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 3"); Asc.Move(Keys.Down, Utils.ETAGE_3, Asc.Vitesse); } };
            HUD[3].ZeEvent += () => { if (!Asc.InMove) { Console.WriteLine("Etage 4"); Asc.Move(Keys.Down, Utils.ETAGE_4, Asc.Vitesse); } };

        }

        public override void Update(float time)
        {
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
