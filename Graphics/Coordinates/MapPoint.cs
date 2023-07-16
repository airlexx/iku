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

    public override string ToString() => $"({X}, {Y})";
}