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
    /// GameOver
    /// </summary>
    public class GameOver: GameObject
    {
        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            var gameOverText = Add(new TextRender("GAME OVER", "fonts\\Roboto-Bold", 60, new Vector2(0, (GameHost.Height / 2) - 50), Color.DarkRed));
            gameOverText.TextAlignment = TextAlignment.Center;
            gameOverText.Width = GameHost.Width;

            GameHost.GetContent<SoundEffect>("sfx\\gameover").Play();

            Input.ShowMouse();

        }

    }
}
