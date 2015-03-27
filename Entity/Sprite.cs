using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Entity
{
    class Sprite
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Texture2D Texture { get; set; }


        public Sprite(Vector2 position, Color color, SpriteEffects spriteEffects)
        {
            Position = position;
            Color = color;
            SpriteEffects = spriteEffects;
        }

        public void LoadContent(ContentManager contentManager)
        {
            Texture = contentManager.Load<Texture2D>("main_sprite.png");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new RectangleF(Position.X, Position.Y, 40, 52), new Rectangle(0,0,20,26), Color, 0, new Vector2(0,0), SpriteEffects, 0);
        }

        public void Move(int x, int y)
        {
            Position = new Vector2(Position.X + x, Position.Y + y);
        }
    }
}
