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
    public static double RunningTime;

    public Window()
    {
        Width = 1920;
        Height = 1080;
        FrameLimit = 240;

        Raylib.InitWindow(Width, Height, NAME);

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

        Console.WriteLine($"Running time: {hours:00}:{minutes:00}:{seconds:00}");
    }
}