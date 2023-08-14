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
    public static int Width { get; set; }
    public static int Height { get; set; }
    public static float WindowRatio { get; set; }
    public static int FrameRate { get; set; }
    public static int FrameLimit { get; set; }
    public static float FrameTime { get; set; }
    public static double RunningTime { get; set; }
    public static int MonitorCount { get; set; }
    public static int CurrentMonitor { get; set; }
    public static int MonitorWidth { get; set; }
    public static int MonitorHeight { get; set; }
    public static float MonitorRatio { get; set; }
    public static float MonitorRefreshRate { get; set; }

    public Window()
    {
        Width = 960;
        Height = 720;

        WindowRatio = (float)Width / (float)Height;
        MonitorRatio = (float)MonitorWidth / (float)MonitorHeight;

        FrameLimit = 9999;

        Logger.Info($"ikuzo!");

        Raylib.SetTraceLogLevel(TraceLogLevel.LOG_WARNING);

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
        WindowRatio = (float)Width / (float)Height;

        FrameRate = Raylib.GetFPS();
        FrameTime = Raylib.GetFrameTime();

        RunningTime = Raylib.GetTime();

        MonitorCount = Raylib.GetMonitorCount();
        CurrentMonitor = Raylib.GetCurrentMonitor();
        MonitorWidth = Raylib.GetMonitorWidth(CurrentMonitor);
        MonitorHeight = Raylib.GetMonitorHeight(CurrentMonitor);
        MonitorRatio = (float)MonitorWidth / (float)MonitorHeight;
        MonitorRefreshRate = Raylib.GetMonitorRefreshRate(CurrentMonitor);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F11))
        {
            Raylib.SetWindowSize(MonitorWidth, MonitorHeight);
            Raylib.ToggleFullscreen();
            Raylib.SetWindowPosition(100, 100);
        }

        if (Raylib.IsWindowResized())
            Logger.Info($"Window resized to {Width}x{Height} ({Math.Round(WindowRatio, 2)}:1)");
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