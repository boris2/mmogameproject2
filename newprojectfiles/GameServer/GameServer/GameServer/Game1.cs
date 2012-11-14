using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Lidgren.Network;
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using FarseerPhysics.Physics;
using FarseerPhysics.Common;
using FarseerPhysics.Fluids;
using FarseerPhysics.Controllers;

namespace GameServer
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //LINGREN CODES START//
        private NetServer server;
        //LINGREN CODES END//
        //FARSEER CODES START//
        World world;
        Body body1;
        const float unitToPixel = 100.0f;
        const float pixelToUnit = 1 / unitToPixel;
        Texture2D texture;
        //FARSEER CODES END//

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //LINGREN CODE STARTS//
            //When initialising, create a configuration object.
            NetPeerConfiguration config = new NetPeerConfiguration("Server");
            //Setting the port, where the NetPeer shall listen. 
            config.Port = 50001;
            //Create the NetPeer object with the configurations.
            server = new NetServer(config);
            //Start
            server.Start();
            //LINGREN CODE ENDS//
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //FARSEER CODES START//
            //Create world with 0 gravity
            world = new World(Vector2.Zero);
            Vector2 size = new Vector2(50, 50);
            body1 = BodyFactory.CreateRectangle(world, size.X * pixelToUnit, size.Y * pixelToUnit, 1);
            body1.BodyType = BodyType.Dynamic;
            body1.Position = new Vector2((GraphicsDevice.Viewport.Width / 2.0f) * pixelToUnit, 0);
            //FARSEER CODES END//

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //FARSEER CODES START//
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            //FARSEER CODES END//

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            Vector2 position = body1.Position * unitToPixel;
            Vector2 scale = new Vector2(100 / (float)texture.Width, 100 / (float)texture.Height);
            spriteBatch.Draw(texture, position, null, Color.White, body1.Rotation, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), scale, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
