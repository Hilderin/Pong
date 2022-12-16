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
        private float _ballSpeed = 0.5f;
        private int _ballSize = 20;
        private float _ballAngle = 2f;
        private Random _random = new Random();
        private SoundEffect _sfxBall;

        /// <summary>
        /// Ball
        /// </summary>
        private TextureRender _ballRenderer;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //La balle...
            _ballRenderer = Add(new TextureRender("ball", new Rectangle(GameHost.Width / 2, GameHost.Height / 2, _ballSize, _ballSize)));
            this.Bounds = _ballRenderer.Bounds;

            _sfxBall = GameHost.GetContent<SoundEffect>("sfx\\ball");

            //this.EnableCollider();

        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            var deltaX = (float)(Math.Sin(_ballAngle) * _ballSpeed * GameHost.GameTime.ElapsedGameTime.Milliseconds);
            var deltaY = (float)(-Math.Cos(_ballAngle) * _ballSpeed * GameHost.GameTime.ElapsedGameTime.Milliseconds);

            _ballPosition.X += deltaX;
            _ballPosition.Y += deltaY;

            bool collided = false;   
            Collision collision = this.GetCollisions((int)_ballPosition.X, (int)_ballPosition.Y).FirstOrDefault();
            if (collision != null)
            {
                //On collide avec la raquette...
                collided = true;

                if (collision.Direction == CollisionDirection.MovingColliderOnTop || collision.Direction == CollisionDirection.MovingColliderOnBottom)
                {
                    //Inversion de l'angle sur les Y (la balle va remonter)
                    double deg = GameMath.ConvertRadToDeg(_ballAngle);
                    _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(360 - (deg - 180)));
                }
                else
                {
                    //Inversion de l'angle sur les X (la balle va se tasser à droite ou gauche)
                    double deg = GameMath.ConvertRadToDeg(_ballAngle);
                    _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(90 - (deg - 270)));
                }


                switch (collision.Direction)
                {
                    case CollisionDirection.MovingColliderOnLeft:
                        //La balle est à gauche
                        _ballPosition.X = collision.CollidesWith.Bounds.Left - _ballRenderer.Width;
                        break;
                    case CollisionDirection.MovingColliderOnRight:
                        //La balle est à droite
                        _ballPosition.X = collision.CollidesWith.Bounds.Right;
                        break;
                    case CollisionDirection.MovingColliderOnTop:
                        //La balle est en haut
                        _ballPosition.Y = collision.CollidesWith.Bounds.Top - _ballRenderer.Height;
                        break;
                    case CollisionDirection.MovingColliderOnBottom:
                        //La balle est en bas
                        _ballPosition.Y = collision.CollidesWith.Bounds.Bottom;
                        break;
                }


            }


           

            if (_ballPosition.X + _ballRenderer.Width > GameHost.Width)
            {
                _ballPosition.X = GameHost.Width - _ballRenderer.Width;
                double deg = GameMath.ConvertRadToDeg(_ballAngle);
                _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(deg + 360 - (2 * deg)));
                collided = true;
            }
            else if (_ballPosition.X < 0)
            {
                _ballPosition.X = 0;
                double deg = GameMath.ConvertRadToDeg(_ballAngle);
                _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(90 - (deg - 270)));
                collided = true;
            }

            if (_ballPosition.Y + _ballRenderer.Height > GameHost.Height)
            {
                _ballPosition.Y = GameHost.Height - _ballSize;
                double deg = GameMath.ConvertRadToDeg(_ballAngle);
                _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(360 - (deg - 180)));
                collided = true;
            }
            else if (_ballPosition.Y < 0)
            {
                _ballPosition.Y = 0;
                double deg = GameMath.ConvertRadToDeg(_ballAngle);
                _ballAngle = (float)AjusteAngle(GameMath.ConvertDegToRad(90 + (90 - deg)));
                collided = true;
            }

            _ballRenderer.X = (int)_ballPosition.X;
            _ballRenderer.Y = (int)_ballPosition.Y;

            if (collided)
                _sfxBall.Play();
        }

        /// <summary>
        /// Ajuste un peu l'angle pour que ça soit pas parfait
        /// </summary>
        private double AjusteAngle(double angle)
        {
            return angle;// + (_random.NextDouble() * 0.2) - 0.1;
        }


    }
}
