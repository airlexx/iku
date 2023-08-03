using System;
using iku.Game.Utils;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerTrack
{
    private static bool isRunning;
    private static uint currentHitPointID;

    public static bool IsRunning { get => isRunning; }
    public static uint CurrentHitPointID { get => currentHitPointID; set => currentHitPointID = 1; }

    public static void Load()
    {
        isRunning = false;
    }

    public static void Update()
    {
        if (isRunning == true)
            PlayerPoint.MovePoint(MapLoader.HitPoints[currentHitPointID].Position);

        if (currentHitPointID != MapLoader.HitPoints.Length - 1)
        {
            float radius = 0f;
            MapPoint playerPoint = PlayerPoint.GetMapPosition();
            MapPoint hitPoint = MapLoader.HitPoints[currentHitPointID].Position;

            if (PlayerPoint.IsCollidedMap(playerPoint, hitPoint, radius) == true)
                currentHitPointID++;
        }
        else
        {
            Reset();
            Logger.Debug(@"Game finished!");
        }
    }

    public static void Start() => isRunning = true;

    public static void Stop() => isRunning = false;


    public static void Reset()
    {
        currentHitPointID = 1;
        PlayerPoint.SetPosition(new MapPoint(0f, 0f));
        PlayerTimer.Reset();
    }
}
