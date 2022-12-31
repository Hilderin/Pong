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
            Add(new TextRender("GAME OVER", "fonts\\Roboto-Bold", 60, this.Game.Rectangle, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            Add(new Button("RETRY", new Rectangle(this.Game.CenterX - 100, this.Game.CenterY + 200, 200, 60), Retry));

            GetContent<SoundEffect>("sfx\\gameover").Data.Play();

            MediaPlayer.Stop();

            Mouse.ShowMouse();

        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Retry()
        {
            if(PongGame.Instance != null)
                PongGame.Instance.Restart();
        }
    }
}
