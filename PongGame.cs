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
        /// Ball
        /// </summary>
        private Ball _ball;

        /// <summary>
        /// Raquette
        /// </summary>
        private TextureRender _racket;

        ///// <summary>
        ///// Text à renderer
        ///// </summary>
        //private TextRender _text;


        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //La balle...
            _ball = Add(new Ball());

            _racket = Add(new TextureRender("pixel", new Rectangle(GameHost.Width / 2, GameHost.Height - 100, 100, 20), new Color(1, 0, 1, 1f)));
            _racket.EnableCollider();

            Song music = GameHost.GetContent<Song>("music\\Armin-van-Buuren-Ping-Pong");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.4f;
            MediaPlayer.Play(music);
            

            //_text = Add(new TextRender("allo", "fonts\\Roboto-Regular.ttf", 20, new Point(50, 200), Color.Red));
            //_text.RotationOrigin = new Vector2(10, 10);

            //Add(new FPSRender("fonts\\Roboto-Regular.ttf", 20, Color.Green));


            //_colliderContainer.Colliders.Add(new ColliderRectangle(_ball.Bounds, _ball));
            //_colliderContainer.Colliders.Add(new ColliderRectangle(_racket.Bounds, _racket));

        }

        /// <summary>
        /// Exécution à chaque frame
        /// </summary>
        public override void Update()
        {
            //_ball.Destination.X += 10;
            //_text.Rotation += 0.1f;



            //Déplacement de la balle...
            if (Input.IsKeyDown(Keys.Left))
                _racket.X -= 10;
            if (Input.IsKeyDown(Keys.Right))
                _racket.X += 10;
            //if (Input.IsKeyDown(Keys.Up))
            //    _ball.Y -= 10;
            //if (Input.IsKeyDown(Keys.Down))
            //    _ball.Y += 10;
        }
    }
}
