using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    /// GameOver
    /// </summary>
    public class GameOver: GameObject
    {
        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            Add(new TextRender("GAME OVER", "fonts\\Roboto-Bold", 60, GameHost.Rectangle, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            
            GameHost.GetContent<SoundEffect>("sfx\\gameover").Play();

            MediaPlayer.Stop();

            Input.ShowMouse();

        }

    }
}
