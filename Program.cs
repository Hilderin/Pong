using FNAEngine2D;
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
            //GameHost.SetResolution(1920, 1080, 1200, 800, true);

            //GameHost.Run(new EscapeMenu());
            //GameHost.Run(new GameOver());
            GameHost.Run(new PongGame());
        }
    }
}
