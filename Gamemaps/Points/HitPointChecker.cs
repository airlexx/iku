using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public struct HitPointChecker
{
    private static bool isCollided;

    public static bool IsCollided { get => isCollided; set => isCollided = value; }

    public static void Init()
    {
        isCollided = false;
    }

    public static void Update()
    {
        uint id = PlayerTrack.FocusedHitPointID;
        HitPointCollided(MapLoader.HitCircles[id], 2);
    }

    public static void HitPointCollided(HitCircle hitCircle, int radLevel)
    {
        float playerRadius = PlayerPoint.Size;
        float hitCircleRadius = hitCircle.Radius[radLevel];
        MapPoint playerPos = PlayerPoint.GetMapPosition();
        MapPoint hitCirclePos = hitCircle.HitPoint.Position;

        Vector2 center1 = new (playerPos.X, playerPos.Y);
        Vector2 center2 = new (hitCirclePos.X, hitCirclePos.Y);

        isCollided = Raylib.CheckCollisionCircles(center1, playerRadius, center2, hitCircleRadius);
    }
}
