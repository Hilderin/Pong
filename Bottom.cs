using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Bottom: GameObject
    {
        /// <summary>
        /// Load of the object
        /// </summary>
        protected override void Load()
        {
            this.Y = this.Game.Height;
            this.Width = this.Game.Width;
            this.Height = 100;

            this.EnableCollider();
        }
    }
}
