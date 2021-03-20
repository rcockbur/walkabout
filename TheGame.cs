using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TheGameProject
{
    public class TheGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState PreviousState;
        private int Updates = 0;
        private int Frames = 0;

        public TheGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize(); 
        }

        protected override void LoadContent()
        {
            G.Init();
            Map.Init();
            Systems.Draw.Init(Content, graphics);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            EntityCreators.CreateUnit(Content, new Vec2f(0, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(0, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(1, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(2, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(3, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(4, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(5, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(6, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(7, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(8, 0));
            EntityCreators.CreateBuilding(Content, new Vec2i(9, 0));

            EntityCreators.CreateBuilding(Content, new Vec2i(0, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(1, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(2, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(3, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(4, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(5, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(6, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(7, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(8, 9));
            EntityCreators.CreateBuilding(Content, new Vec2i(9, 9));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || (Keyboard.GetState().IsKeyDown(Keys.Q)))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                G.cameraPos.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                G.cameraPos.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                G.cameraPos.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                G.cameraPos.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                G.positionComponents[0].position.Y -= 0.2f;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                G.positionComponents[0].position.X -= 0.2f;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                G.positionComponents[0].position.Y += 0.2f;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                G.positionComponents[0].position.X += 0.2f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Systems.Draw.DrawAll(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
