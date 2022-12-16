using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    /// Game de Pong
    /// </summary>
    public class PongGame : GameObject
    {
        /// <summary>
        /// Ball
        /// </summary>
        private TextureRender _ball;

        /// <summary>
        /// Text à renderer
        /// </summary>
        private TextRender _text;


        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //La balle...
            _ball = Add(new TextureRender("ball", new Microsoft.Xna.Framework.Rectangle(50, 50, 50, 50)));

            _text = Add(new TextRender("allo", "fonts\\Roboto-Regular.ttf", 20, new Vector2(50, 200), Color.Red));
            _text.RotationOrigin = new Vector2(10, 10);
            Add(new FPSRender("fonts\\Roboto-Regular.ttf", 20, Color.Green));

        }

        /// <summary>
        /// Exécution à chaque frame
        /// </summary>
        public override void Update()
        {
            _ball.Destination.X += 10;
            _text.Rotation += 0.1f;

        }
    }
}
