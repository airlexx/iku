using System;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public struct HitPoint
{
    public uint ID { get; set; }
    public MapPoint Position { get; set; }
    public double Time { get; set; }
    public byte Action { get; set; }

    public HitPoint(uint id, MapPoint position, double time, byte action)
    {
        ID = id;
        Position = position;
        Time = time;
        Action = action;
    }

    public readonly ScreenPoint GetScreenPoint()
    {
        return PointConvertion.MapToScreen(Position);
    }

    public override readonly string ToString() => $"{ID}, {Position.X}, {Position.Y}, {Time}, {Action}";
}
