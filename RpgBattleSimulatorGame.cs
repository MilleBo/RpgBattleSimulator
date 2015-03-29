using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgBattleSimulator.Manager;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator
{
    class RpgBattleSimulatorGame : Game
    {
        private GraphicsDeviceManager _deviceManager;
        private BattleManager _battleManager; 
        private SpriteBatch _spriteBatch;

        public RpgBattleSimulatorGame()
        {
            _deviceManager = new GraphicsDeviceManager(this);
            _deviceManager.PreferredBackBufferHeight = 480;
            _deviceManager.PreferredBackBufferWidth = 800;
            _battleManager = new BattleManager();
            Content.RootDirectory = "Content"; 
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _battleManager.LoadContent(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _battleManager.Update(gameTime.ElapsedGameTime.Milliseconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FromBgra(12898209));
            _spriteBatch.Begin();
            _battleManager.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
