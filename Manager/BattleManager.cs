using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgBattleSimulator.Entity;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Manager
{
    class BattleManager
    {
        private List<BattleEntity> _player;
        private List<BattleEntity> _enemies;

        private enum Phase
        {
            Intro,
            SelectAttack
        };

        private Phase _currentPhase;
        private double _counter; 


        public BattleManager()
        {
            _player = new List<BattleEntity>
                      {
                          new BattleEntity(new Sprite(new Vector2(850, 200), Color.White, SpriteEffects.None))
                      };
            _enemies = new List<BattleEntity>
                       {
                           new BattleEntity(new Sprite(new Vector2(-50, 200), Color.White, SpriteEffects.FlipHorizontally))
                       };
            _currentPhase = Phase.Intro;
            _counter = 0; 
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var battleEntity in _enemies)
            {
                battleEntity.LoadContent(content);
            }
            foreach (var battleEntity in _player)
            {
                battleEntity.LoadContent(content);
            }
        }

        public void Update(double gameTime)
        {
            switch (_currentPhase)
            {
                case Phase.Intro:
                    PhaseIntro(gameTime);
                    break;
                case Phase.SelectAttack:
                    PhaseSelectAttack();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void PhaseIntro(double gameTime)
        {
            _counter += gameTime; 
            foreach (var battleEntity in _enemies)
            {
                battleEntity.Sprite.Move(3, 0);
            }
            foreach (var battleEntity in _player)
            {
                battleEntity.Sprite.Move(-3, 0);
            }

            if (_counter > 1000)
            {
                _counter = 0; 
                _currentPhase = Phase.SelectAttack;
            }
       
        }

        private void PhaseSelectAttack()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var battleEntity in _enemies)
            {
                battleEntity.Draw(spriteBatch);
            }
            foreach (var battleEntity in _player)
            {
                battleEntity.Draw(spriteBatch);
            }
        }

    }
}
