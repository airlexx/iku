using System;

namespace iku.Game.Graphics.Coordinates;

public struct MapPoint
{
    public float X { get; set; }
    public float Y { get; set; }

    public MapPoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static MapPoint operator +(MapPoint a, MapPoint b)
    {
        return new MapPoint(a.X + b.X, a.Y + b.Y);
    }

    public static MapPoint operator -(MapPoint a, MapPoint b)
    {
        return new MapPoint(a.X - b.X, a.Y - b.Y);
    }

    public override readonly string ToString() => $"({X}, {Y})";
}
