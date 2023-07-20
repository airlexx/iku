using System;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public struct HitPoint
{
    public MapPoint Position;
    public float Time;
    public byte Action;

    public HitPoint(MapPoint position, float time, byte action)
    {
        Position = position;
        Time = time;
        Action = action;
    }

    public override string ToString() => $"{Position.X}, {Position.Y}, {Time}, {Action}";
}
