using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Entity
{
    class BattleEntity
    {
        public Sprite Sprite { get; set; }
        public Stats Stats { get; set; }

        public int CurrentHealth { get; set; }
        public int CurrentMana { get; set; }

        public BattleEntity(Sprite sprite, Stats stats)
        {
            Sprite = sprite;
            Stats = stats;
            CurrentHealth = Stats.Health;
            CurrentMana = stats.Mana;
        }

        public void LoadContent(ContentManager content)
        {
            Sprite.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
