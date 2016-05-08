using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace protocraft
{
    public class Protocraft : Game
    {
        public static Protocraft self;

        private readonly GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        entities.CharacterEntity character;

        public Protocraft()
        {
            Protocraft.self = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            /*
            // TESTING.
            if (false)
            {
                Exit();
            }
            // */

            // Timing:
            IsFixedTimeStep = true;
            // this.TargetElapsedTime  // Game ticks (default 60 / second) 

            graphics.PreferredBackBufferWidth = Constants.ScreenWidth;
            graphics.PreferredBackBufferHeight = Constants.ScreenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "ProtoCraft";

            character = entities.DudeFactory.createCharacter(entities.DudeFactory.Dudes.Chief);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            character.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            character.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}