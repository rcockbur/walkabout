using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Vec2iComparer : IEqualityComparer<Vec2i>
{
    public bool Equals(Vec2i a, Vec2i b)
    {
        if (a.X != b.X || a.Y != b.Y)
        {
            return false;
        }
        return true;
    }
    public int GetHashCode(Vec2i a)
    {
        return (a.X + 1) + (a.Y + 1) * 3;
    }
}

public class Vec2i
{
    public int X { get; set; }
    public int Y { get; set; }
    public Vec2i(int x, int y)
    {
        X = x;
        Y = y;
    }
    public bool Equals(Vec2i other)
    {
        if (X != other.X || Y != other.Y)
        {
            return false;
        }
        return true;
    }

    public bool IsNone()
    {
        return (X == 0 && Y == 0);
    }
}


public class Vec2f
{
    public float X { get; set; }
    public float Y { get; set; }
    public Vec2f(float x, float y)
    {
        X = x;
        Y = y;
    }
    public bool Equals(Vec2f other)
    {
        if (X != other.X || Y != other.Y)
        {
            return false;
        }
        return true;
    }

    public bool IsNone()
    {
        return (X == 0 && Y == 0);
    }
}

