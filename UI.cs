using FNAEngine2D;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class UI: GameObject, IUpdate
    {
        /// <summary>
        /// Text for current level
        /// </summary>
        private Label _textCurrentLevel;

        /// <summary>
        /// Text où s'affiche le nombre de balls
        /// </summary>
        private Label _textNbBalls;

        /// <summary>
        /// Text for NbPts
        /// </summary>
        private Label _textNbPts;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        protected override void Load()
        {
            const int borderX = 60;
            const int borderWidth = 150;

            //Level
            var borderLevel = Add(new TextureBox("border", new Rectangle(borderX, 50, borderWidth, 50)));
            _textCurrentLevel = Add(new Label(String.Empty, "fonts\\Roboto-Bold", 22, borderLevel.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle, true));
            //_textCurrentLevel.LayerDepth = 1f;

            //Border for nb balls
            var borderNbBalls = Add(new TextureBox("border", new Rectangle(borderX, 150, borderWidth, 50)));
            _textNbBalls = Add(new Label(String.Empty, "fonts\\Roboto-Bold", 22, borderNbBalls.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle, true));
           // _textNbBalls.LayerDepth = 1f;

            //Border for nb pts
            var boderNbPts = Add(new TextureBox("border", new Rectangle(borderX, 250, borderWidth, 50)));
            _textNbPts = Add(new Label(String.Empty, "fonts\\Roboto-Bold", 22, boderNbPts.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle, true));
            //_textNbBalls.LayerDepth = 1f;

            Add(new FPSRender("fonts\\Roboto-Bold", 12, Color.Yellow));

        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            if (PongGame.Instance == null)
            {
                _textCurrentLevel.Text = "LEVEL1";
                _textNbBalls.Text = "3 UP";
                _textNbPts.Text = "000000";
            }
            else
            {
                _textCurrentLevel.Text = "LEVEL" + PongGame.Instance.Level.CurrentLevelNumber.ToString();
                _textNbBalls.Text = PongGame.Instance.NbBalls.ToString() + " UP";
                _textNbPts.Text = PongGame.Instance.NbPts.ToString("000000");
            }
        }

    }
}
