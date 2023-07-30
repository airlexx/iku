using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerPoint
{
    public static float X;
    public static float Y;
    public static float Size = 1f;
    public static float Speed = 1f;
    public static float ScreenSpeed;
    private static float DistanceBuffer;
    private static int Translation;
    private static ScreenPoint ScreenPosition;
    private static MapPoint MapPosition;

    public static void Init()
    {
        X = Window.Width / 2;
        Y = Window.Height / 2;
    }

    public static void Update()
    {
        ScreenPosition = new ScreenPoint((int)X, (int)Y);
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
        Raylib.DrawCircle((int)X, (int)Y, radius, Graphics.Color.CyberYellow);
    }

    public static void Mouvement()
    {
        ScreenSpeed = PointConvertion.MapToScreen(new MapPoint(0f, -Speed)).Y;
        DistanceBuffer += ScreenSpeed * (float)Window.FrameTime;

        Translation = (int)DistanceBuffer;
        DistanceBuffer -= Translation;
    }

    public static void Move(MapPoint position)
    {
        Mouvement();

        ScreenPoint screenDest = PointConvertion.MapToScreen(position);

        if(X < screenDest.X)
            X += Translation;

        if(X > screenDest.X)
            X -= Translation;

        if(Y < screenDest.Y)
            Y += Translation;

        if(Y > screenDest.Y)
            Y -= Translation;
    }

    public static void SetPosition(MapPoint position)
    {
        ScreenPoint screenPoint = PointConvertion.MapToScreen(position);

        X = screenPoint.X;
        Y = screenPoint.Y;
    }

    public static void GameInputListener()
    {
        Mouvement();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            X += Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            X -= Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            Y -= Translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            Y += Translation;
    }
}