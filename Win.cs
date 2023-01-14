using FNAEngine2D;
using FNAEngine2D.GameObjects;
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
    /// Win
    /// </summary>
    public class Win : GameObject
    {
        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            Add(new TextRender("WIN", "fonts\\Roboto-Bold", 60, this.Game.Rectangle, Color.Green, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            Add(new Button("RETRY", new Rectangle(this.Game.CenterX - 100, this.Game.CenterY + 200, 200, 60), Retry));

            GetContent<SoundEffect>("sfx\\win").Data.Play();

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
