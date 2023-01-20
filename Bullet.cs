using FNAEngine2D;
using FNAEngine2D.Collisions;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Bullet: GameObject, IUpdate
    {
        public const int BULLET_WIDTH = 4;
        public const int BULLET_HEIGHT = 18;

        /// <summary>
        /// Speed of the bullet
        /// </summary>
        private float _speed = 600f;

        /// <summary>
        /// Type to manage the colliders
        /// </summary>
        private Type[] _colliderTypes = new Type[] { typeof(GameBorder), typeof(Block) };

        /// <summary>
        /// Constructor
        /// </summary>
        public Bullet(float x, float y)
        {
            this.Location = new Vector2(x, y);
            this.Width = BULLET_WIDTH;
            this.Height = BULLET_HEIGHT;
        }

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            Add(new TextureBox("bullet", this.Bounds));

        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            int deplacementY = -(int)(_speed * this.ElapsedGameTimeSeconds);

            Collision collision = this.GetCollision(this.X, this.Y + deplacementY, _colliderTypes);
            if (collision != null)
            {
                foreach (GameObject collideObj in collision.CollidesWith)
                {
                    if (collideObj is Block)
                    {
                        //Collapse avec un block, on va détruire le block...
                        ((Block)collideObj).Hit();
                        GetContent<SoundEffect>("sfx\\hit").Data.Play();
                    }
                }

                this.Destroy();
            }
            else
            {
                this.TranslateY(deplacementY);
            }
            



        }
        
    }
}
