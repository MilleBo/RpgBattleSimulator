using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgBattleSimulator.Entity;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Gui
{
    class WindowStats : Window
    {
        private readonly List<BattleEntity> _battleEntities;
        private SpriteFont _font; 

        public WindowStats(Vector2 position, int height, int width, List<BattleEntity> battleEntities) : base(position, height, width)
        {
            _battleEntities = battleEntities;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _font = content.Load<SpriteFont>("gui/font");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "Name", new Vector2(Position.X + 20, Position.Y + 20), Color.Black);
            spriteBatch.DrawString(_font, "HP", new Vector2(Position.X + 120, Position.Y + 20), Color.Black);
            spriteBatch.DrawString(_font, "MP", new Vector2(Position.X + 220, Position.Y + 20), Color.Black);
            spriteBatch.DrawString(_font, "ATB", new Vector2(Position.X + 320, Position.Y + 20), Color.Black);
            for(int n = 0; n < _battleEntities.Count; n++)
            {
                var battleEntity = _battleEntities[n];
                spriteBatch.DrawString(_font, battleEntity.Stats.Name, new Vector2(Position.X + 20, Position.Y + 20 + 25*(n+1)), Color.Black);
                spriteBatch.DrawString(_font, string.Format("{0}/{1}", battleEntity.CurrentHealth, battleEntity.Stats.Health) , new Vector2(Position.X + 120, Position.Y + 20 + 25*(n+1)), Color.Black);
                spriteBatch.DrawString(_font, string.Format("{0}/{1}", battleEntity.CurrentMana, battleEntity.Stats.Mana), new Vector2(Position.X + 220, Position.Y + 20 + 25 * (n + 1)), Color.Black);
            }
        }
    }
}
