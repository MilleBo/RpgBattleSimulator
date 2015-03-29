using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgBattleSimulator.Entity;
using RpgBattleSimulator.Gui;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator.Manager
{
    class BattleManager
    {
        private List<BattleEntity> _player;
        private List<BattleEntity> _enemies;
        private WindowStats _statusWindow; 

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
                          new BattleEntity(
                              new Sprite(new Vector2(850, 200), Color.White, SpriteEffects.None),
                              new Stats
                              {
                                  Name = "Litz",
                                  Health = 20,
                                  Mana = 5,
                                  Strength = 5,
                                  Defense = 2,
                                  Magic = 2,
                                  Speed = 3
                              })
                      };
            _enemies = new List<BattleEntity>
                       {
                           new BattleEntity(
                               new Sprite(new Vector2(-50, 200), Color.White, SpriteEffects.FlipHorizontally),
                               new Stats
                              {
                                  Name = "Enemy",
                                  Health = 10,
                                  Mana = 5,
                                  Strength = 5,
                                  Defense = 2,
                                  Magic = 2,
                                  Speed = 3
                              })
                       };
            _currentPhase = Phase.Intro;
            _counter = 0; 
            _statusWindow = new WindowStats(new Vector2(800 - 510, 480 - 160), 150, 500, _player); //Should use screen width/height variables here instead of hardcorded
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
            _statusWindow.LoadContent(content);
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
            _statusWindow.Draw(spriteBatch);
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
