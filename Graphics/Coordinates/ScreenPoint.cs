using System;

namespace iku.Game.Graphics.Coordinates;

public struct ScreenPoint
{
    public int X;
    public int Y;

    public ScreenPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";
}