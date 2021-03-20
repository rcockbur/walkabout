using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace TheGameProject
{
    public struct RenderComponent
    {
        public Texture2D texture;
        public Vec2i size;
        public Vec2i anchor;
        
        public RenderComponent(int id, Texture2D _texture, Vec2i _size, Vec2i _anchor)
        {
            texture = _texture;
            size = _size;
            anchor = _anchor;
            G.renderComponents.Add(id, this);
        }
    }
    public struct PositionComponent
    {
        public Vec2f position;

        public PositionComponent(int id, Vec2f p)
        {
            position = p;
            G.positionComponents.Add(id, this);
        }
    }
    public struct TileComponent
    {
        public Vec2i tile;

        public TileComponent(int id, Vec2i t)
        {
            tile = t;
            G.tileComponents.Add(id, this);
        }
    }

    public struct MoveComponent
    {
        public Vec2f position;
    }

    public struct AbilityQueue
    {
        public List<Ability> queue;
    }
}
