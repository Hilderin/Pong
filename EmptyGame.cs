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
    public class EmptyGame : GameObject, IUpdate
    {
        /// <summary>
        /// Instance courante
        /// </summary>
        public static EmptyGame Instance;

        private bool _escapeMenuVisible = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        public EmptyGame()
        {
            Instance = this;
        }


        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Continue()
        {
            Remove(typeof(EscapeMenu));

            //Level.PausedSelf = false;

            _escapeMenuVisible = false;

            //Mouse.HideMouse();
        }


        /// <summary>
        /// Update of PongGame
        /// </summary>
        public void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                if (!_escapeMenuVisible)
                {
                    _escapeMenuVisible = true;
                    Add(new EscapeMenu());
                }
                else
                {
                    Continue();
                }
            }
            
        }

        protected override void Load()
        {
            Mouse.ShowMouse();
        }
    }
}
