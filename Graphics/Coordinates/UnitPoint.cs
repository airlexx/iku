using System;

namespace iku.Game.Graphics.Coordinates;

public struct UnitPoint
{
    public float X { get; set; }
    public float Y { get; set; }

    public UnitPoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static UnitPoint operator +(UnitPoint a, UnitPoint b)
    {
        return new UnitPoint(a.X + b.X, a.Y + b.Y);
    }

    public static UnitPoint operator -(UnitPoint a, UnitPoint b)
    {
        return new UnitPoint(a.X - b.X, a.Y - b.Y);
    }

    public override readonly string ToString() => $"({X}, {Y})";
}
