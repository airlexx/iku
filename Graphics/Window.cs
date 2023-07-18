using System;
using Raylib_cs;
using iku.Game.Utils;

namespace iku.Game.Graphics;

public struct Window
{
#if DEBUG
    public const string Name = "iku (development)";
#else
    public const string Name = "iku";
#endif
    public static int Width;
    public static int Height;
    public static float Ratio;
    public static int FrameRate;
    public static int FrameLimit;
    public static float FrameTime;
    public static double RunningTime;

    public Window()
    {
        Width = 1920;
        Height = 1080;

        Ratio = (float)Width / (float)Height;
        
        FrameLimit = 240;

        Raylib.InitWindow(Width, Height, Name);

        Image icon = Raylib.LoadImage("Assets/iku-desktop.png");
        Raylib.SetWindowIcon(icon);

        Raylib.SetTargetFPS(FrameLimit);
    }

    public void FrameRefresh()
    {
        FrameRate = Raylib.GetFPS();
        FrameTime = Raylib.GetFrameTime();
        RunningTime = Raylib.GetTime();
    }

    public static void Close()
    {
        uint totalSeconds = (uint)RunningTime;

        uint hours = totalSeconds / 3600;
        uint minutes = (totalSeconds % 3600) / 60;
        uint seconds = totalSeconds % 60;

        Logger.Info($"Running time: {hours:00}:{minutes:00}:{seconds:00}");
    }
}