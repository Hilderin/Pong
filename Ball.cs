using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    /// Ball object
    /// </summary>
    public class Ball : GameObject
    {
        private Vector2 _ballPosition;
        private Vector2 _ballDirection;
        private float _ballSpeedPixelsPerSeconds = 300f;
        private Vector2Int _ballSize = new Vector2Int(20);
        private SoundEffect _sfxBall;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            _ballPosition = Vector2Helper.Center(GameHost.Size, _ballSize);
            _ballPosition.Y = GameHost.Height * 0.1f;

            _ballDirection = Vector2.Normalize(new Vector2(1, 1));

            //La balle...
            this.Position = _ballPosition;
            this.Size = _ballSize;

            //La texture pour la balle
            Add(new TextureRender("ball", this.Rectangle));
            
            //Sfx pour le bounce
            _sfxBall = GameHost.GetContent<SoundEffect>("sfx\\ball");


        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            Vector2 delta = _ballDirection * (_ballSpeedPixelsPerSeconds * GameHost.ElapsedGameTimeSeconds);

            _ballPosition += delta;


            Collision collision = this.GetCollisions((int)_ballPosition.X, (int)_ballPosition.Y).FirstOrDefault();
            if (collision != null)
            {
                //On collide avec la raquette ou un mur...
                if (collision.Direction == CollisionDirection.MovingColliderOnTop || collision.Direction == CollisionDirection.MovingColliderOnBottom)
                {
                    //Inversion de l'angle sur les Y (la balle va remonter)
                    _ballDirection.Y *= -1;
                }
                else
                {
                    //Inversion de l'angle sur les X (la balle va se tasser à droite ou gauche)
                    _ballDirection.X *= -1;
                }

                _ballPosition = new Vector2(collision.StopBounds.X, collision.StopBounds.Y);

                _sfxBall.Play();
            }

            this.Translate(_ballPosition - this.Position);

                
        }



    }
}
