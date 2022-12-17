using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Block: GameObject
    {
        /// <summary>
        /// Size of blocks
        /// </summary>
        public static readonly Point BlockSize = new Point(50, 25);

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            this.Width = BlockSize.X;
            this.Height = BlockSize.Y;
            Add(new TextureRender("block", this.Rectangle));

            this.EnableCollider();
        }

    }
}
