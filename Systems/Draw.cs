using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.Linq;

namespace TheGameProject.Systems
{
    public class Draw
    {
        private static SpriteFont Arial24Font;
        public static Texture2D tileTexture;
        public static Texture2D unitTexture;
        private static GraphicsDeviceManager graphics;
        public static void Init(ContentManager content, GraphicsDeviceManager _graphics)
        {
            graphics = _graphics;
            //tileTexture = content.Load<Texture2D>("grass_tile");
            tileTexture = SquareTexture(G.TILE_SIZE-1, G.TILE_SIZE-1, Color.White);
            unitTexture = SquareTexture(G.TILE_SIZE - 1, G.TILE_SIZE - 1, Color.White);

            Arial24Font = content.Load<SpriteFont>("arial24");
        }
        public static void DrawAll(SpriteBatch _spriteBatch)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            DrawTiles(_spriteBatch);
            DrawEntities(_spriteBatch);
            DrawText(_spriteBatch);
            _spriteBatch.End();
        }
        private static Texture2D SquareTexture(int size_x, int size_y, Color color)
        {
            //Console.WriteLine(size_x);
            Texture2D tileTexture = new Texture2D(graphics.GraphicsDevice, size_x, size_y);
            Color[] data = new Color[size_x * size_y];
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            tileTexture.SetData(data);
            return tileTexture;
        }
        private static Vec2i WorldToScreen(Vec2f world)
        {
            return new Vec2i((int)world.X - G.cameraPos.X, (int)world.Y - G.cameraPos.Y);
        }

        public static void DrawTiles(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < G.MAP_SIZE_X; i++)
            {
                for (int j = 0; j < G.MAP_SIZE_Y; j++)
                {
                    int world_x = i * G.TILE_SIZE;
                    int world_y = j * G.TILE_SIZE;

                    Rectangle dest = new Rectangle(world_x - G.cameraPos.X, world_y - G.cameraPos.Y, G.TILE_SIZE-1, G.TILE_SIZE-1);
                    _spriteBatch.Draw(tileTexture, dest, Color.White);
                }
            }
        }

        public static void DrawEntities(SpriteBatch _spriteBatch)
        {
            List<KeyValuePair<int, float>> e = new List<KeyValuePair<int, float>>();

            foreach (int item in G.allEntities)
            {
                if (G.renderComponents.Keys.Contains(item) || G.positionComponents.Keys.Contains(item))
                {
                    float Z = G.positionComponents[item].position.X + G.positionComponents[item].position.Y;
                    e.Add(new KeyValuePair<int, float>(item, Z));  
                }
            }

            e.Sort(delegate (KeyValuePair<int, float> pair1, KeyValuePair<int, float> pair2) {
                if (pair1.Value < pair2.Value) return -1;
                else if (pair1.Value > pair2.Value) return 1;
                else return 0;
            });

            foreach (KeyValuePair<int, float> pair in e)
            {
                Vec2f position = G.positionComponents[pair.Key].position;
                Vec2i size = G.renderComponents[pair.Key].size;
                Vec2i anchor = G.renderComponents[pair.Key].anchor;
                Texture2D texture = G.renderComponents[pair.Key].texture;
                Vec2i screen = WorldToScreen(position);
                Rectangle dest = new Rectangle(screen.X - anchor.X, screen.Y - anchor.Y, size.X, size.Y);
                _spriteBatch.Draw(texture, dest, Color.White);
            }            
        }

        public static void DrawText(SpriteBatch _spriteBatch)
        {
            string s = G.positionComponents[0].position.X.ToString() + "," + G.positionComponents[0].position.Y.ToString();
            _spriteBatch.DrawString(Arial24Font, "Pos: " + s, new Vector2(10, 10), Color.Black);
        }
    }
}
