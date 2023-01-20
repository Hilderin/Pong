using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    /// Game de Pong
    /// </summary>
    public class PongGame : GameObject, IUpdate
    {
        /// <summary>
        /// Instance courante
        /// </summary>
        public static PongGame Instance;

        /// <summary>
        /// Nombre de balls
        /// </summary>
        public int NbBalls = 3;

        /// <summary>
        /// Nombre de pts
        /// </summary>
        public int NbPts = 0;

        /// <summary>
        /// Curent level
        /// </summary>
        public LevelScene Level;


        /// <summary>
        /// Constructeur
        /// </summary>
        public PongGame()
        {
            Instance = this;
        }

        /// <summary>
        /// On a perdu une balle
        /// </summary>
        public void LostABall()
        {
            NbBalls--;

            if (NbBalls < 0)
                NbBalls = 0;

            if (NbBalls > 0)
            {
                Level.ResetBall();
            }
            else
            {
                //On pause..
                Level.PausedSelf = true;

                Add(new GameOver());
            }
        }

        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Restart()
        {
            NbBalls = 3;
            NbPts = 0;

            //Clearup de scene...
            RemoveAll();

            //Add the level...
            Level = Add(new LevelScene());

            //UI!
            Add(new UI());

            Mouse.HideMouse();
        }

        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Continue()
        {
            Remove(typeof(EscapeMenu));

            Level.PausedSelf = false;

            Mouse.HideMouse();
        }

        /// <summary>
        /// On a gagné!
        /// </summary>
        public void Win()
        {
            Level.PausedSelf = true;

            Add(new Win());
        }

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        protected override void Load()
        {

            Restart();

        }

        /// <summary>
        /// Update of PongGame
        /// </summary>
        public void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                Level.PausedSelf = true;

                Add(new EscapeMenu());
            }
            
        }




    }
}
