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
    public class PongGame : GameObject
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
        /// Ball game object
        /// </summary>
        private Ball _ball;

        /// <summary>
        /// Racket game object
        /// </summary>
        private Racket _racket;

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
                _ball.ResetPosition();
            }
            else
            {
                //On pause..
                _ball.Paused = true;
                _racket.Paused = true;

                Add(new GameOver());
            }
        }

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {

            Add(new Level1());


            //La balle...
            _ball = Add(new Ball());
            _racket = Add(new Racket());

            //UI!
            Add(new UI());

        }

        


    }
}
