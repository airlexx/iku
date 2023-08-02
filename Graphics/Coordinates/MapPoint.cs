using System;

namespace iku.Game.Graphics.Coordinates;

public struct MapPoint
{
    public float X;
    public float Y;

    public MapPoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static MapPoint operator +(MapPoint a, MapPoint b)
    {
        return new MapPoint(a.X + b.X, a.Y + b.Y);
    }

    public override string ToString() => $"({X}, {Y})";
}