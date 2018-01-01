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

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            Asc = new Ascenseur(new Vector2(30, Utils.ETAGE_1));

            HUD = new List<Button>
            {
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_1), "Etage 1"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_2), "Etage 2"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_3), "Etage 3"),
                new Button(new Vector2(Utils.POSITION_X_BUTTON, Utils.ETAGE_4), "Etage 4")
            };

            HUD[0].ZeEvent += () => { Console.WriteLine("Etage 1"); Asc.Move(Utils.ETAGE_1, 1000); };
            HUD[1].ZeEvent += () => { Console.WriteLine("Etage 2"); Asc.Move(Utils.ETAGE_2, 1000); };
            HUD[2].ZeEvent += () => { Console.WriteLine("Etage 3"); Asc.Move(Utils.ETAGE_3, 1000); };
            HUD[3].ZeEvent += () => { Console.WriteLine("Etage 4"); Asc.Move(Utils.ETAGE_4, 1000); };
        }

        public override void Update(float time)
        {
            Asc.Update(time);
            foreach(Button button in HUD)
            {
                button.Update(time);
            }
        }

        public override void Draw()
        {
            Batch.Begin();
            Asc.Draw(Batch);
            foreach(Button button in HUD)
            {
                button.Draw(Batch);
            }
            Batch.End();
        }
    }
}
