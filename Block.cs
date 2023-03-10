using FNAEngine2D;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Block : GameObject
    {
        /// <summary>
        /// Size of blocks
        /// </summary>
        public static readonly Point BlockSize = new Point(50, 25);

        /// <summary>
        /// Constructor
        /// </summary>
        public Block()
        {
            this.Width = BlockSize.X;
            this.Height = BlockSize.Y;
        }

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            
            Add(new TextureBox("block", this.Bounds));

            this.EnableCollider();
        }


        /// <summary>
        /// Hit d'un block
        /// </summary>
        public void Hit()
        {
            GameObject parent = this.Parent;

            this.Destroy();

            PongGame.Instance.NbPts += 100;

            if (parent.Count(typeof(Block)) == 0)
                PongGame.Instance.Win();
        }
    }
}
