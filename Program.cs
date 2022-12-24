﻿using FNAEngine2D;
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
            //GameHost.Run(new UI());
        }
    }
}
