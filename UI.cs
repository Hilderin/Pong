using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class UI: GameObject
    {
        /// <summary>
        /// Text où s'affiche le nombre de balls
        /// </summary>
        private TextRender _textNbBalls;

        /// <summary>
        /// Text for NbPts
        /// </summary>
        private TextRender _textNbPts;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //Border for nb balls
            var borderNbBalls = Add(new TextureRender("border", new Rectangle(60, 50, 150, 50)));
            //Border for nb pts
            Add(new TextureRender("border", new Rectangle(60, 150, 150, 50)));

            _textNbBalls = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, new Vector2(115, 60), Color.DarkRed));
            _textNbBalls.TextAlignment = TextAlignment.Center;
            _textNbBalls.X = borderNbBalls.X;
            _textNbBalls.Width = borderNbBalls.Width;

            _textNbPts = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, new Vector2(95, 160), Color.DarkRed));
            _textNbPts.TextAlignment = TextAlignment.Center;
            _textNbPts.X = borderNbBalls.X;
            _textNbPts.Width = borderNbBalls.Width;
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            _textNbBalls.Text = PongGame.Instance.NbBalls.ToString() + " UP";
            _textNbPts.Text = PongGame.Instance.NbPts.ToString("000000");
        }

    }
}
