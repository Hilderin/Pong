using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public static class LevelHelper
    {

        /// <summary>
        /// Épaisseur des murs virtuels
        /// </summary>
        public const int SIDE_WIDTH = 24;

        public const int GAME_WIDTH = 600;


        /// <summary>
        /// Permet d'ajouter les sides par défaut
        /// </summary>
        public static void AddSidesDefault(GameObject gameObject)
        {
            int leftSide = (GameHost.Width / 2) - (GAME_WIDTH / 2);
            int rightSide = (GameHost.Width / 2) + (GAME_WIDTH / 2);

            
            var leftsideObj = gameObject.Add(new TextureRender("side", new Rectangle(leftSide - SIDE_WIDTH, 0, SIDE_WIDTH, GameHost.Height)));
            var rightsideObj = gameObject.Add(new TextureRender("side", new Rectangle(rightSide, 0, SIDE_WIDTH, GameHost.Height)));
            var topObj = gameObject.Add(new TextureRender("top", new Rectangle(leftSide - SIDE_WIDTH, 0, GAME_WIDTH + (SIDE_WIDTH * 2), SIDE_WIDTH)));
            var bottom = gameObject.Add(new Bottom());

            leftsideObj.EnableCollider();
            rightsideObj.EnableCollider();
            topObj.EnableCollider();
            bottom.EnableCollider();



        }

    }
}
