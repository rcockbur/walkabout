using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TheGameProject
{
    
    public class Map
    {
        public static Vec2f TileCenterToPos(Vec2i tile)
        {
            float x = ((float)tile.X + 0.5f) * G.TILE_SIZE;
            float y = ((float)tile.Y + 0.5f) * G.TILE_SIZE;
            return new Vec2f(x, y);
        }
        private static int[][] self;

        public static void Init()
        {
            for(int i = 0; i == 100; i++)
            {
                for (int j = 0; i == 100; i++)
                {
                    self[i][j] = 0;
                }
            }
        }
        public static int Get(int x, int y)
        {
            return self[x][y];
        }
    }
}
