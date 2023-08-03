using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerPoint
{
    private static ScreenPoint screenPosition;
    private static MapPoint mapPosition;

    public const float Size = 1f;
    public const float SpeedPoint = 10f;
    public const float SpeedSong = 1f;

    private static float distanceBuffer;
    private static int translation;

    public static void Init()
    {
        screenPosition = new(Window.Width / 2, Window.Height / 2);
    }

    public static void Update()
    {
        mapPosition = PointConvertion.ScreenToMap(screenPosition);
    }

    public static ScreenPoint GetScreenPoint()
    {
        return screenPosition;
    }

    public static MapPoint GetMapPosition()
    {
        return mapPosition;
    }

    public static void Display()
    {
        float radius = (PointConvertion.MapToScreen(new MapPoint(0.5f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X) * Size;
        Raylib.DrawCircle(screenPosition.X, screenPosition.Y, radius, Graphics.Color.CyberYellow);
    }

    public static void Movement()
    {
        float screenSpeed = Window.Height / 20f * SpeedPoint;
        distanceBuffer += screenSpeed * Window.FrameTime * SpeedSong;

        PlayerTimer.Record();

        translation = (int)distanceBuffer;
        distanceBuffer -= translation;
    }

    public static void MovePoint(MapPoint position)
    {
        Movement();

        ScreenPoint screenDest = PointConvertion.MapToScreen(position);

        if(screenPosition.X < screenDest.X)
            screenPosition.X += translation;

        if(screenPosition.X > screenDest.X)
            screenPosition.X -= translation;

        if(screenPosition.Y < screenDest.Y)
            screenPosition.Y += translation;

        if(screenPosition.Y > screenDest.Y)
            screenPosition.Y -= translation;
    }

    public static void MoveTime(double time, PlayerDirection direction)
    {
        Movement();

        double runningTime = PlayerTimer.RunningTime;

        if (direction == PlayerDirection.Right && runningTime <= time)
            screenPosition.X += translation;

        if (direction == PlayerDirection.Left && runningTime <= time)
            screenPosition.X -= translation;

        if (direction == PlayerDirection.Up && runningTime <=time)
            screenPosition.Y -= translation;

        if (direction == PlayerDirection.Down && runningTime <= time)
            screenPosition.Y += translation;
    }

    public static void MoveInput()
    {
        Movement();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            screenPosition.X += translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            screenPosition.X -= translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            screenPosition.Y -= translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            screenPosition.Y += translation;
    }

    public static void SetPosition(MapPoint position)
    {
        ScreenPoint screenPoint = PointConvertion.MapToScreen(position);

        screenPosition.X = screenPoint.X;
        screenPosition.Y = screenPoint.Y;
    }

    public static bool IsCollidedMap(MapPoint point1, MapPoint point2, float radius)
    {
        ScreenPoint p1 = PointConvertion.MapToScreen(point1);
        ScreenPoint p2 = PointConvertion.MapToScreen(point2);

        Vector2 center1 = new(p1.X, p1.Y);
        Vector2 center2 = new(p2.X, p2.Y);

        return Raylib.CheckCollisionCircles(center1, radius, center2, radius);
    }
}
