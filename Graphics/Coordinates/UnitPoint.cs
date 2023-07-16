using System;

namespace iku.Game.Graphics.Coordinate;

public struct UnitPoint
{
    public float X;
    public float Y;

    public UnitPoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";
}