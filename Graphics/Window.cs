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
    public static int CurrentMonitor;
    public static int MonitorWidth;
    public static int MonitorHeight;

    public Window()
    {
        Width = 960;
        Height = 720;

        Ratio = (float)Width / (float)Height;
        
        FrameLimit = 9999;

        Logger.Info($"ikuzo!");

        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(Width, Height, Name);
        Raylib.SetWindowMinSize(720, 540);

        if (Raylib.IsWindowReady())
            Logger.Info($"Window has been initialized successfully");

        Image icon = Raylib.LoadImage("Assets/iku-desktop.png");
        Raylib.SetWindowIcon(icon);

        Raylib.SetTargetFPS(FrameLimit);
    }

    public static void Update()
    {
        Width = Raylib.GetScreenWidth();
        Height = Raylib.GetScreenHeight();
        Ratio = (float)Width / (float)Height;

        FrameRate = Raylib.GetFPS();
        FrameTime = Raylib.GetFrameTime();

        RunningTime = Raylib.GetTime();

        CurrentMonitor = Raylib.GetCurrentMonitor();
        MonitorWidth = Raylib.GetMonitorWidth(CurrentMonitor);
        MonitorHeight = Raylib.GetMonitorHeight(CurrentMonitor);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F11))
        {
            Raylib.SetWindowSize(MonitorWidth, MonitorHeight);
            Raylib.ToggleFullscreen();
            Raylib.SetWindowPosition(100, 100);
        }

        if (Raylib.IsWindowResized())
            Logger.Info($"Window resized to {Width}x{Height} ({Math.Round(Ratio, 2)}:1)");
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