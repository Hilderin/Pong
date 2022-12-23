using FNAEngine2D;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Program
    {
        public static void Main()
        {
            //Weird problem with the text in FrontToBack mode, probablement because of the resolution and the font??
            GameHost.MainCamera.SpriteSortMode = SpriteSortMode.Immediate;

#if DEBUG
            GameHost.SetResolution(1200, 800, 1200, 800, false);
#else
            GameHost.SetResolution(1200, 800, 1200, 800, true);
#endif

            //GameHost.Run(new Win());
            //GameHost.Run(new GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            GameHost.Run(new PongGame());
        }
    }
}
