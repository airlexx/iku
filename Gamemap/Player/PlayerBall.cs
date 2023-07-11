using System;
using Raylib_cs;
using iku.Game.Graphics;
using System.Numerics;

namespace iku.Game.Gamemap.Player;

public static class PlayerBall
{
    public static float X = Window.Width/2;
    public static float Y = Window.Height/2;
    public static float TX = Window.Width/2;
    public static float TY = Window.Height/2;
    public static float Speed = 10.0f;
    public static float Smooth = 0.1f;

    private static float previousX = X;
    private static float previousY = Y;

    public static void Display()
    {
        Raylib.DrawCircle((int)PlayerBall.X, (int)PlayerBall.Y, 10, Graphics.Color.Red);
    }

    public static void GameInputListener()
    {
        float s = Speed * Window.FrameTime * 100;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            X += s;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            X -= s;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            Y -= s;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            Y += s;
    }
}