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
    private static byte status;
    private static float thick;

    public static void Draw()
    {
        size = (PointConvertion.MapToScreen(new MapPoint(1f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X) * hitPointSize;
        status = 1;
        thick = 1f;

        HitPoint[] hitPoint = MapLoader.HitPoints;
        CheckPoint[] checkPoint = MapLoader.CheckPoints;

        for (int i = 0; i < hitPoint.Length; i++)
        {
            MapPoint point = PointConvertion.ScreenToMap(new ScreenPoint((int)hitPoint[i].Position.X, (int)hitPoint[i].Position.Y));

            ScreenPoint hitPointPosStart = PointConvertion.MapToScreen(hitPoint[i].Position);
            ScreenPoint hitPointPosEnd = PointConvertion.MapToScreen(MapLoader.GetHitPointID(i+1).Position);

            ScreenPoint checkPointPos = PointConvertion.MapToScreen(checkPoint[i].Position);

            Vector2 vec2HitPointPosStart = new(hitPointPosStart.X, hitPointPosStart.Y);
            Vector2 vec2HitPointPosEnd = new(hitPointPosEnd.X, hitPointPosEnd.Y);
            
            float cameraX1 = GameCamera.MapPosition.X - renderDistance;
            float cameraX2 = GameCamera.MapPosition.X + renderDistance;
            float cameraY1 = GameCamera.MapPosition.Y - renderDistance;
            float cameraY2 = GameCamera.MapPosition.Y + renderDistance;

            if (point.X >= cameraX1 && point.X <= cameraX2 && point.Y >= cameraY1 && point.Y <= cameraY2)
            {
                Raylib.DrawLineEx(vec2HitPointPosStart, vec2HitPointPosEnd, thick, Graphics.Color.White);
                SkinLoader.DrawPoint((HitPointAction)hitPoint[i].Action, status, vec2HitPointPosStart, size);
                Raylib.DrawCircle(checkPointPos.X, checkPointPos.Y, 4f, Graphics.Color.Red);
            }
        }
    }
}
