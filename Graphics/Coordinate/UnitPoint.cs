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

    public override string ToString() => $"x: {Math.Round(X, 2).ToString("0.00")}    y: {Math.Round(Y, 2).ToString("0.00")}";
}