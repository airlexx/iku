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

    public override string ToString() => $"x: {Math.Round(X, 2).ToString("0.00")}    y: {Math.Round(Y, 2).ToString("0.00")}";
}