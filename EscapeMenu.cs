using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class EscapeMenu: GameObject, IUpdate
    {

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            //const int width = 400;
            //const int height = 600;

            ////Bounds at center of the screen...
            //this.Bounds = RectangleHelper.Center(GameHost.Bounds, width, height);

            //var borderLevel = Add(new TextureBox("escape_menu", this.Bounds));

            //Add(new Label("Pong", "fonts\\Roboto-Bold", 50, borderLevel.Bounds, Color.Black, TextHorizontalAlignment.Center, TextVerticalAlignment.Top))
            //    .TranslateY(30);

            //Add(new Button("Continue", new Rectangle(GameHost.CenterX - 125, 300, 250, 70), Continue));
            //Add(new Button("Quit", new Rectangle(GameHost.CenterX - 125, 420, 250, 70), Quit));

            GameContentManager.Apply(this, "gamecontent\\escape_menu");

            Find<Button>("ContinueButton").OnClick = Continue;
            Find<Button>("QuitButton").OnClick = Quit;

            Mouse.ShowMouse();

        }

        /// <summary>
        /// Update of PongGame
        /// </summary>
        public void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                Continue();
            }

        }


        /// <summary>
        /// Continue
        /// </summary>
        public void Continue()
        {
            if (PongGame.Instance != null)
                PongGame.Instance.Continue();
            if (EmptyGame.Instance != null)
                EmptyGame.Instance.Continue();

        }

        /// <summary>
        /// Quit
        /// </summary>
        public void Quit()
        {
            this.Game.Quit();
        }
    }
}
