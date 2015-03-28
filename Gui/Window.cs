using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Gui
{
    class Window
    {
        private Texture2D _upperLeftCornerTexture;
        private Texture2D _upperRightCornerTexture;
        private Texture2D _lowerLeftCornerTexture;
        private Texture2D _lowerRightCornerTexture;
        private Texture2D _topTexture;
        private Texture2D _leftTexture;
        private Texture2D _fillerTexture;

        public Vector2 Position { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Window(Vector2 position, int height, int width)
        {
            Position = position;
            Height = height;
            Width = width; 
        }
        public void LoadContent(ContentManager content)
        {
            _upperLeftCornerTexture = content.Load<Texture2D>("gui/window_upper_left_corner.png");
            _upperRightCornerTexture = content.Load<Texture2D>("gui/window_upper_right_corner.png");
            _lowerLeftCornerTexture = content.Load<Texture2D>("gui/window_lower_left_corner.png");
            _lowerRightCornerTexture = content.Load<Texture2D>("gui/window_lower_right_corner.png");
            _topTexture = content.Load<Texture2D>("gui/window_up.png");
            _leftTexture = content.Load<Texture2D>("gui/window_left.png");
            _fillerTexture = content.Load<Texture2D>("gui/window_filler.png");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_upperLeftCornerTexture, Position, Color.White);
            spriteBatch.Draw(_upperRightCornerTexture, new Vector2(Position.X + Width - 15, Position.Y), Color.White);
            spriteBatch.Draw(_lowerLeftCornerTexture, new Vector2(Position.X, Position.Y + Height - 12), Color.White);
            spriteBatch.Draw(_lowerRightCornerTexture, new Vector2(Position.X + Width - 15, Position.Y + Height - 12), Color.White);
            for (int n = 0; n < ((Width - 30)/6) + 1; n++)
            {
                spriteBatch.Draw(_topTexture, new Vector2(Position.X + 15 + n * 6, Position.Y), Color.White);
                spriteBatch.Draw(_topTexture, new RectangleF(Position.X + 15 + n * 6, Position.Y + Height - 12, 6, 12), new Rectangle(0, 0, 6, 12), Color.White, 0, new Vector2(0,0), SpriteEffects.FlipVertically, 0);
            }
            for (int n = 0; n < ((Height - 26) / 6) + 1; n++)
            {
                spriteBatch.Draw(_leftTexture, new Vector2(Position.X, Position.Y + 12 + 6 * n), Color.White);
                spriteBatch.Draw(_leftTexture, new RectangleF(Position.X + Width - 12, Position.Y + 12 + 6 * n, 12, 6), new Rectangle(0, 0, 12, 6), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }
            spriteBatch.Draw(_fillerTexture, new RectangleF(Position.X + 12, Position.Y + 12, Width - 24, Height - 24), Color.White);
        }

    }
}
