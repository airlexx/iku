using System;

namespace iku.Game.Graphics.Coordinates;

public struct ScreenPoint
{
    public int X { get; set; }
    public int Y { get; set; }

    public ScreenPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static ScreenPoint operator +(ScreenPoint a, ScreenPoint b)
    {
        return new ScreenPoint(a.X + b.X, a.Y + b.Y);
    }

    public override readonly string ToString() => $"({X}, {Y})";
}
