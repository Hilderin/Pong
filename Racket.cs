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
    /// <summary>
    /// Objet représentant la raquette
    /// </summary>
    public class Racket: GameObject
    {
        /// <summary>
        /// Position à partir du bas de l'écran pour la raquette
        /// </summary>
        private const int BOTTOM_POSITION = -100;

        /// <summary>
        /// Vitesse de déplacement
        /// </summary>
        private float _speedPixelsPerSeconds = 300f;

        /// <summary>
        /// Raquette
        /// </summary>
        private TextureRender _racket;

        /// <summary>
        /// Taille de la raquette
        /// </summary>
        private Vector2Int _size = new Vector2Int(100, 20);

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {

            this.Rectangle = new Rectangle((GameHost.Width / 2) - (_size.X / 2), GameHost.Height + BOTTOM_POSITION, _size.X, _size.Y);

            _racket = Add(new TextureRender("racket", this.Rectangle));

            this.EnableCollider();

        }

        /// <summary>
        /// Exécution à chaque frame
        /// </summary>
        public override void Update()
        {
            //Déplacement de la balle...
            if (Input.IsKeyDown(Keys.Left) || Input.IsKeyDown(Keys.A))
                this.TranslateX(-_speedPixelsPerSeconds * GameHost.ElapsedGameTimeSeconds);
            if (Input.IsKeyDown(Keys.Right) || Input.IsKeyDown(Keys.D))
                this.TranslateX(_speedPixelsPerSeconds * GameHost.ElapsedGameTimeSeconds);

        }

    }
}
