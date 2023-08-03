using System;
using System.Numerics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Points;

public static class HitPointDrawer
{
    private const float renderDistance = 100;
    private const float hitPointSize = 1;

    public static void Draw()
    {
        float size = (PointConvertion.MapToScreen(new MapPoint(1f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X) * hitPointSize;
        byte status = 1;

        foreach (var HitPoint in MapLoader.HitPoints)
        {
            MapPoint point = PointConvertion.ScreenToMap(new ScreenPoint((int)HitPoint.Position.X, (int)HitPoint.Position.Y));
            ScreenPoint hitPointPosition = PointConvertion.MapToScreen(HitPoint.Position);
            
            float cameraX1 = GameCamera.MapPosition.X - renderDistance;
            float cameraX2 = GameCamera.MapPosition.X + renderDistance;

            float cameraY1 = GameCamera.MapPosition.Y - renderDistance;
            float cameraY2 = GameCamera.MapPosition.Y + renderDistance;

            if (point.X >= cameraX1 && point.X <= cameraX2 && point.Y >= cameraY1 && point.Y <= cameraY2)
                SkinLoader.DrawPoint((HitPointAction)HitPoint.Action, status, new Vector2(hitPointPosition.X, hitPointPosition.Y), size);
        }
    }
}
