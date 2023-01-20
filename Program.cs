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
        [STAThread]
        public static void Main()
        {
            GraphicSettings graphicSettings = new GraphicSettings();

#if DEBUG
            GameManager.DevelopmentMode = true;
            graphicSettings.IsFullscreen = false;
#else
            graphicSettings.IsFullscreen = true;
#endif

            //GameHost.Run(new Win());
            //GameHost.Run(new GameOver());
            //GameHost.Run(new Test());
            //GameManager.Run(new EscapeMenu(), graphicSettings);
            GameManager.Run(new PongGame(), graphicSettings);
            //GameManager.Run(new EmptyGame(), graphicSettings);
            //GameHost.Run(new UI());
        }
    }
}
