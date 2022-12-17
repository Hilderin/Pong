using FNAEngine2D;
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
        private TextureRender _upRenderer;
        private TextureRender _overRenderer;
        private TextureRender _downRenderer;
        private TextRender _textRender;

        private string _text;
        private Action _onClick;

        /// <summary>
        /// Constructor
        /// </summary>
        public Button(string text, Rectangle bounds, Action onClick)
        {
            _text = text;
            this.Bounds = bounds;
            _onClick = onClick;
        }

        /// <summary>
        /// Load
        /// </summary>
        public override void Load()
        {
            _upRenderer = Add(new TextureRender("button_up", this.Bounds));
            _overRenderer = Add(new TextureRender("button_over", this.Bounds));
            _overRenderer.Hide();
            _downRenderer = Add(new TextureRender("button_down", this.Bounds));
            _downRenderer.Hide();


            _textRender = Add(new TextRender(_text, "fonts\\Roboto-Bold", 22, this.Bounds, Color.White, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));


        }


        /// <summary>
        /// Handle mouse event...
        /// </summary>
        public void HandleMouseEvent(MouseAction action)
        {
            _upRenderer.Visible = true;
            _overRenderer.Visible = false;
            _downRenderer.Visible = false;
            
            if (action == MouseAction.Enter)
            {
                _upRenderer.Visible = false;
                _overRenderer.Visible = true;
            }
            else if (action == MouseAction.Leave)
            {
                
            }
            else if (action == MouseAction.LeftButtonDown)
            {
                _upRenderer.Visible = false;
                _downRenderer.Visible = true;
                _textRender.Y += 5;
            }

            //When pressed down... the text needs to move down also...
            if (_downRenderer.Visible)
            {
                _textRender.Y = this.Bounds.Y + 3;
            }
            else
            {
                _textRender.Y = this.Bounds.Y;
            }




            if (action == MouseAction.LeftButtonClicked)
            {
                //Clicked!
                _onClick?.Invoke();
            }


        }



    }
}
