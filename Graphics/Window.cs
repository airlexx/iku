using System;
using Raylib_cs;
using iku.Game.Utils;

namespace iku.Game.Graphics;

public struct Window
{
    public const string NAME = "iku (devlopment)";
    public static int Width;
    public static int Height;
    public static int FrameRate;
    public static int FrameLimit;
    public static float FrameTime;

    public Window()
    {
        Width = 1280;
        Height = 720;
        FrameLimit = 240;

        Raylib.InitWindow(Width, Height, NAME);
        Image icon = Raylib.LoadImage("Assets/iku-desktop.png");
        Raylib.SetWindowIcon(icon);   

        Raylib.SetTargetFPS(FrameLimit);
    }

    public void FrameRefresh()
    {
        FrameRate = Raylib.GetFPS();

        FrameTime = Math.Abs(Raylib.GetFrameTime() - FrameTime);
        FrameTime = Math.Min(FrameTime, 0.01f);
    }
}