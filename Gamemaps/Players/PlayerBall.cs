using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps.Players;

public static class PlayerBall
{
    public static float X;
    public static float Y;
    public static int Size = 10;
    public static float Speed = 1f;
    public static float ScreenSpeed;
    private static float DistanceBuffer;

    public static void Init()
    {
        X = Window.Width / 2;
        Y = Window.Height / 2;
    }

    public static void Display()
    {
        Raylib.DrawCircle((int)X, (int)Y, Size, Graphics.Color.Red);
    }

    public static void GameInputListener()
    {
        ScreenSpeed = PointConvertion.MapToScreen(new MapPoint(Speed, 0f)).Y;
        DistanceBuffer += ScreenSpeed * (float)Window.FrameTime;

        int translation = (int)DistanceBuffer;
        DistanceBuffer -= translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            X += translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            X -= translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            Y -= translation;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            Y += translation;
    }
}