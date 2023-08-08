using System;

namespace iku.Game.Gamemaps.Points;

public struct HitCircle
{
    public HitPoint HitPoint { get; set; }
    public float[] Radius { get; set; }

    public HitCircle(HitPoint hitPoint, float[] radius)
    {
        HitPoint = hitPoint;
        Radius = radius;
    }

    public override readonly string ToString() => $"{HitPoint}, {Radius}";
}
