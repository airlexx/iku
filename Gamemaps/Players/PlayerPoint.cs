using System;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerPoint
{
    private static ScreenPoint ScreenPosition;
    private static MapPoint MapPosition;

    public static float Size = 1f;
    public static float Speed = 10f;

    private static float DistanceBuffer;
    private static int Translation;

    public static void Init()
    {
        ScreenPosition.X = Window.Width / 2;
        ScreenPosition.Y = Window.Height / 2;
    }

    public static void Update()
    {
        MapPosition = PointConvertion.ScreenToMap(ScreenPosition);
    }

    public static ScreenPoint GetScreenPoint()
    {
        return ScreenPosition;
    }

    public static MapPoint GetMapPosition()
    {
        return MapPosition;
    }

    public static void Display()
    {
        float radius = (PointConvertion.MapToScreen(new MapPoint(0.5f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X) * Size;
        Raylib.DrawCircle(ScreenPosition.X, ScreenPosition.Y, radius, Graphics.Color.CyberYellow);
    }

    public static void Movement()
    {
        float screenSpeed = Window.Height / 20f * Speed;
        DistanceBuffer += screenSpeed * Window.FrameTime;

        PlayerTimer.Record();

        Translation = (int)DistanceBuffer;
        DistanceBuffer -= Translation;
    }

    public static void MovePoint(MapPoint position)
    {
        Movement();

        ScreenPoint screenDest = PointConvertion.MapToScreen(position);

        if(ScreenPosition.X < screenDest.X)
            ScreenPosition.X += Translation;

        if(ScreenPosition.X > screenDest.X)
            ScreenPosition.X -= Translation;

        if(ScreenPosition.Y < screenDest.Y)
            ScreenPosition.Y += Translation;

        if(ScreenPosition.Y > screenDest.Y)
            ScreenPosition.Y -= Translation;
    }

    public static void MoveTime(double time, PlayerDirection direction)
    {
        Movement();

        double runningTime = PlayerTimer.RunningTime;

        if (direction == PlayerDirection.Right && runningTime <= time)
            ScreenPosition.X += Translation;

        if (direction == PlayerDirection.Left && runningTime <= time)
            ScreenPosition.X -= Translation;

        if (direction == PlayerDirection.Up && runningTime <=time)
            ScreenPosition.Y -= Translation;

        if (direction == PlayerDirection.Down && runningTime <= time)
            ScreenPosition.Y += Translation;
    }

    public static void MoveInput()
    {
        Movement();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            ScreenPosition.X += Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            ScreenPosition.X -= Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            ScreenPosition.Y -= Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            ScreenPosition.Y += Translation;
    }

    public static void SetPosition(MapPoint position)
    {
        ScreenPoint screenPoint = PointConvertion.MapToScreen(position);

        ScreenPosition.X = screenPoint.X;
        ScreenPosition.Y = screenPoint.Y;
    }
}
