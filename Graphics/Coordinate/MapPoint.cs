using System;

namespace iku.Game.Graphics.Coordinate;

public struct MapPoint
{
    public float X;
    public float Y;

    public MapPoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";
}