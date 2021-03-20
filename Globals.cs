using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameProject
{
    
    class G
    {
        public static Dictionary<int, RenderComponent> renderComponents;
        public static Dictionary<int, PositionComponent> positionComponents;
        public static Dictionary<int, TileComponent> tileComponents;
        public static int MAP_SIZE_X = 10;
        public static int MAP_SIZE_Y = 10;

        public static int TILE_SIZE = 50;

        public static Vec2i cameraPos = new Vec2i(-150, -200);
        public static List<int> allEntities = new List<int>(1000);

        public static void Init()
        {
            renderComponents = new Dictionary<int, RenderComponent>();
            positionComponents = new Dictionary<int, PositionComponent>();
            tileComponents = new Dictionary<int, TileComponent>();
        }
    }

    
}
