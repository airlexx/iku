using System;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public struct CheckPoint
{
    public uint ID { get; set; }
    public MapPoint Position { get; set; }

    public CheckPoint(uint id, MapPoint position)
    {
        ID = id;
        Position = position;
    }

    public readonly ScreenPoint GetScreenPoint()
    {
        return PointConvertion.MapToScreen(Position);
    }

    public override readonly string ToString() => $"{ID}, {Position.X}, {Position.Y}";
}
