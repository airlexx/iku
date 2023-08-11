using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public static class HitPointDrawer
{
    private const float renderDistance = 100f;
    private const float hitPointSize = 0.5f;

    private static float size;
    private static byte pointStatus;
    private static float lineThick;
    private static int pointID;

    private static MapPoint point;

    private static Vector2 vec2HitPointPosStart;
    private static Vector2 vec2HitPointPosEnd;

    private static HitPoint[] hitPoints = Array.Empty<HitPoint>();
    private static HitCircle[] hitCirlces = Array.Empty<HitCircle>();

    private static float[] hitCircleRadSizes = Array.Empty<float>();

    private static float cameraX1; // not optimized
    private static float cameraX2; // not optimized
    private static float cameraY1; // not optimized
    private static float cameraY2; // not optimized

    public static void Init()
    {
        pointStatus = 1;
        lineThick = 1f;

        hitCircleRadSizes = new float[3];

        hitPoints = MapLoader.HitPoints;
        hitCirlces = MapLoader.HitCircles;

        size = (PointConvertion.MapToScreen(new MapPoint(1f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X) * hitPointSize;
    }

    public static void DrawPoint(HitPointAction action, byte status, Vector2 position, float size)
    {
        Rectangle recSource = new(0, 0, 256, 256);
        Rectangle recDest = new(position.X, position.Y, size, size);
        Vector2 origin = new(size / 2, size / 2);

        var hitPointTexture = action switch
        {
            HitPointAction.Right => SkinLoader.HitPointRight[status],
            HitPointAction.Left => SkinLoader.HitPointLeft[status],
            HitPointAction.Up => SkinLoader.HitPointUp[status],
            HitPointAction.Down => SkinLoader.HitPointDown[status],
            _ => SkinLoader.HitPointDown[0],
        };

        Raylib.DrawTexturePro(hitPointTexture, recSource, recDest, origin, 0f, Color.WHITE);
    }

    public static void Draw()
    {
        for (pointID = 0; pointID < hitPoints.Length; pointID++)
        {
            point = PointConvertion.ScreenToMap(new ScreenPoint((int)hitPoints[pointID].Position.X, (int)hitPoints[pointID].Position.Y));

            ScreenPoint hitPointPosStart = PointConvertion.MapToScreen(hitPoints[pointID].Position);
            ScreenPoint hitPointPosEnd = PointConvertion.MapToScreen(MapLoader.GetHitPoint((uint)pointID + 1).Position);

            vec2HitPointPosStart = new(hitPointPosStart.X, hitPointPosStart.Y);
            vec2HitPointPosEnd = new(hitPointPosEnd.X, hitPointPosEnd.Y);

            cameraX1 = GameCamera.MapPosition.X - renderDistance;
            cameraX2 = GameCamera.MapPosition.X + renderDistance;
            cameraY1 = GameCamera.MapPosition.Y - renderDistance;
            cameraY2 = GameCamera.MapPosition.Y + renderDistance;

            for (int j = 0; j < hitCirlces[pointID].Radius.Length; j++)
                hitCircleRadSizes[j] = PointConvertion.MapToScreen(new MapPoint(hitCirlces[pointID].Radius[j], 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X;

            Drawing();
        }
    }

    public static void Drawing()
    {
        if (point.X >= cameraX1 && point.X <= cameraX2 && point.Y >= cameraY1 && point.Y <= cameraY2)
        {
            uint[] levels = {0, 1, 2};
            DrawCircle(levels);
            DrawLine();
            DrawPoint((HitPointAction)hitPoints[pointID].Action, pointStatus, vec2HitPointPosStart, size);
        }
    }

    public static void DrawLine()
    {
        Raylib.DrawLineEx(vec2HitPointPosStart, vec2HitPointPosEnd, lineThick, Graphics.Color.White);
    }

    public static void DrawCircle(uint[] levels)
    {
        for (int i = 0; i < levels.Length; i++)
            Raylib.DrawCircleV(vec2HitPointPosStart, hitCircleRadSizes[levels[i]], Graphics.Color.Red25);
    }
}
