using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        /// Épaisseur des murs virtuels
        /// </summary>
        private const int WALL_THICKNESS = 100;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //Background...
            Add(new TextureRender("backgrounds\\plain", new Rectangle(0, 0, GameHost.Width, GameHost.Height)));


            //La balle...
            Add(new Ball());
            Add(new Racket());

            //Ajout des colliders sur les bords...
            AddCollider(new Collider(-WALL_THICKNESS, 0, WALL_THICKNESS, GameHost.Height));    //Left
            AddCollider(new Collider(GameHost.Width, 0, WALL_THICKNESS, GameHost.Height));     //Right
            AddCollider(new Collider(0, -WALL_THICKNESS, GameHost.Width, WALL_THICKNESS));     //Top
            AddCollider(new Collider(0, GameHost.Height, GameHost.Width, WALL_THICKNESS));     //Bottom

            Song music = GameHost.GetContent<Song>("music\\Armin-van-Buuren-Ping-Pong");

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.4f;
            MediaPlayer.Play(music);

        }


    }
}
