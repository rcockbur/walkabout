using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameProject
{
    enum EntityType { Unit, Building }
    public class EntityCreators
    {
        private static int entityID = 0;
        public static void CreateUnit(ContentManager content, Vec2f position)
        {
            new PositionComponent(entityID, position);
            Vec2i size = new Vec2i(60, 100);
            Vec2i anchor = new Vec2i(30, 84);
            new RenderComponent(entityID, Systems.Draw.unitTexture, size, anchor);

            G.allEntities.Add(entityID);
            entityID++;
        }

        public static void CreateBuilding(ContentManager content, Vec2i tile)
        {
            new TileComponent(entityID, tile);

            Vec2f pos = Map.TileCenterToPos(tile);
            new PositionComponent(entityID, pos);

            Vec2i size = new Vec2i(46, 32);
            Vec2i anchor = new Vec2i(24, 21);
            new RenderComponent(entityID, content.Load<Texture2D>("house"), size, anchor);

            G.allEntities.Add(entityID);
            entityID++;
        }
    }
    
}