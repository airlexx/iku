using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Gamemaps;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerTrack
{
    public static bool Running = false;
    public static uint CurrentHitPointID = 1;

    public static void Update()
    {
        if (CurrentHitPointID != MapLoader.HitPointCount + 1)
        {
            if (IsHitPointCollide(CurrentHitPointID) == true)
                CurrentHitPointID++;
        }
        else
            Reset();

        if (Running == true)
            PlayerPoint.Move(MapLoader.GetPoint(CurrentHitPointID).Position);
    }

    public static bool IsHitPointCollide(uint hitPointID)
    {
        float radius = 0f;

        ScreenPoint playerPoint = PlayerPoint.GetScreenPoint();
        ScreenPoint hitPoint = MapLoader.GetPoint(hitPointID).GetScreenPoint();

        Vector2 center1 = new Vector2(playerPoint.X, playerPoint.Y);
        Vector2 center2 = new Vector2(hitPoint.X, hitPoint.Y);

        return Raylib.CheckCollisionCircles(center1, radius, center2, radius);
    }

    public static void Start()
    {
        Running = true;
    }

    public static void Stop()
    {
        Running = false;
    }

    public static void Reset()
    {
        CurrentHitPointID = 1;
        PlayerPoint.SetPosition(new MapPoint(0f, 0f));
    }
}