using FNAEngine2D;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Button : GameObject, IMouseEventHandler
    {
        private TextureBox _upRenderer;
        private TextureBox _overRenderer;
        private TextureBox _downRenderer;
        private Label _label;

        
        public Action OnClick;

        public string Text { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Button()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Button(string text, Rectangle bounds, Action onClick)
        {
            Text = text;
            this.Bounds = bounds;
            OnClick = onClick;
        }

        /// <summary>
        /// Load
        /// </summary>
        protected override void Load()
        {
            _upRenderer = Add(new TextureBox("button_up", this.Bounds));
            _overRenderer = Add(new TextureBox("button_over", this.Bounds));
            _overRenderer.Hide();
            _downRenderer = Add(new TextureBox("button_down", this.Bounds));
            _downRenderer.Hide();


            _label = Add(new Label(Text, "fonts\\Roboto-Bold", 22, this.Bounds, Color.White, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            _label.PixelPerfect = true;
            _label.Depth = this.Depth - 100;        //Par dessus le restant

        }


        /// <summary>
        /// Handle mouse event...
        /// </summary>
        public void HandleMouseEvent(MouseAction action)
        {
            if (action == MouseAction.Enter || action == MouseAction.LeftButtonUp)
            {
                _upRenderer.VisibleSelf = false;
                _downRenderer.VisibleSelf = false;
                _overRenderer.VisibleSelf = true;
            }
            else if (action == MouseAction.Leave)
            {   
                _downRenderer.VisibleSelf = false;
                _overRenderer.VisibleSelf = false;
                _upRenderer.VisibleSelf = true;
            }
            else if (action == MouseAction.LeftButtonDown)
            {
                _upRenderer.VisibleSelf = false;                
                _overRenderer.VisibleSelf = false;
                _downRenderer.VisibleSelf = true;
            }

            //When pressed down... the text needs to move down also...
            if (_downRenderer.Visible)
            {
                _label.Y = this.Bounds.Y + 3;
            }
            else
            {
                _label.Y = this.Bounds.Y;
            }


            if (action == MouseAction.LeftButtonClicked)
            {
                //Clicked!
                OnClick?.Invoke();
            }


        }



    }
}
