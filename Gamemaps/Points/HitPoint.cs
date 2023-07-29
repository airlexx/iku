using System;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public struct HitPoint
{
    public uint ID;
    public MapPoint Position;
    public double Time;
    public byte Action;

    public HitPoint(uint id, MapPoint position, double time, byte action)
    {
        ID = id;
        Position = position;
        Time = time;
        Action = action;
    }

    public ScreenPoint GetScreenPoint()
    {
        return PointConvertion.MapToScreen(Position);
    }

    public override string ToString() => $"{ID}, {Position.X}, {Position.Y}, {Time}, {Action}";
}
