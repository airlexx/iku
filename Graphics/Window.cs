using System;
using System.Diagnostics;
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
    public static Stopwatch RunningTime = new Stopwatch();

    public Window()
    {
        Width = 1920;
        Height = 1080;
        FrameLimit = 240;

        Raylib.InitWindow(Width, Height, NAME);

        RunningTime.Start();

        Image icon = Raylib.LoadImage("Assets/iku-desktop.png");
        Raylib.SetWindowIcon(icon);

        Raylib.SetTargetFPS(FrameLimit);
    }

    public void FrameRefresh()
    {
        FrameRate = Raylib.GetFPS();

        FrameTime = Math.Abs(Raylib.GetFrameTime() - FrameTime);
        FrameTime = Math.Min(FrameTime, 0.1f);
    }

    public static void Close()
    {
        RunningTime.Stop();

        TimeSpan elapsedTime = RunningTime.Elapsed;
        Console.WriteLine(string.Format("Running time: {0}:{1:mm}:{1:ss}", elapsedTime.Days * 24 + elapsedTime.Hours, elapsedTime));
    }
}