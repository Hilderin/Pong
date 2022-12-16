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
        private float _ballSpeedPixelsPerSeconds = 400f;
        private Vector2Int _ballSize = new Vector2Int(20);
        private SoundEffect _sfxBall;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            _ballPosition = VectorHelper.Center(GameHost.Size, _ballSize);
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

                
                if (collision.CollidesWith.GameObject is Racket
                    && (collision.Direction == CollisionDirection.MovingColliderOnTop || collision.Direction == CollisionDirection.MovingColliderOnBottom))
                {
                    //Collide avec la racket...
                    //On va calculer un angle en fonction de la position sur la raquette...
                    Racket racket = (Racket)collision.CollidesWith.GameObject;
                    float centerBallX = _ballPosition.X + (_ballSize.X / 2);
                    int centerRacket = racket.CenterX;

                    float ratioDiff = (centerRacket - centerBallX) / (racket.Width / 2);

                    //Si zéro, ça veut dire que la balle est en plein milieu...
                    //Si c'est 1, c'est que c'est à gauche complètement
                    float newAngle = 90 * ratioDiff;
                    if (newAngle > 75)
                        newAngle = 75;
                    else if (newAngle < -75)
                        newAngle = -75;

                    Vector2 newDirection = VectorHelper.Rotate(new Vector2(0, (_ballDirection.Y < 0 ? -1 : 1)), Vector2.Zero, GameMath.DegToRad(newAngle));    //Up

                    _ballDirection = newDirection;


                }
                

                _ballPosition = new Vector2(collision.StopBounds.X, collision.StopBounds.Y);

                _sfxBall.Play();
            }

            this.Translate(_ballPosition - this.Position);

                
        }



    }
}
