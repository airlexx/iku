using System;
using Raylib_cs;
using iku.Game.Graphics;

namespace iku.Game.Gamemaps.Players;

public static class PlayerBall
{
    public static float X = Window.Width/2;
    public static float Y = Window.Height/2;
    public static int Size = 10;
    public static float Speed = 1000f;
    private static float DistanceBuffer;

    public static void Display()
    {
        Raylib.DrawCircle((int)X, (int)Y, Size, Graphics.Color.Red);
    }

    public static void GameInputListener()
    {
        DistanceBuffer += Speed * (float)Window.FrameTime;

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