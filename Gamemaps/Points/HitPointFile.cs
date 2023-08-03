using System;

namespace iku.Game.Gamemaps.Points;

public struct HitPointFile
{
    public uint ID { get; set; }
    public double Time { get; set; }
    public byte Action { get; set; }

    public HitPointFile(uint id, double time, byte action)
    {
        ID = id;
        Time = time;
        Action = action;
    }

    public override readonly string ToString() => $"{ID}, {Time}, {Action}";
}
