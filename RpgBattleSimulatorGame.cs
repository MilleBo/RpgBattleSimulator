using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;

namespace RpgBattleSimulator
{
    class RpgBattleSimulatorGame : Game
    {
        private GraphicsDeviceManager _deviceManager;
        private SpriteBatch _spriteBatch;

        public RpgBattleSimulatorGame()
        {
            _deviceManager = new GraphicsDeviceManager(this);
            _deviceManager.PreferredBackBufferHeight = 480;
            _deviceManager.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content"; 
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
