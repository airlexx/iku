using System;
using System.Diagnostics;
using Raylib_cs;

namespace iku.Game.Gamemaps;

public static class IkuTimer
{
    private static double time;
    private static readonly Stopwatch stopwatch = new();

    public static double Time { get => time; set => time = value; }

    public static void Start()
    {
        stopwatch.Start();
    }

    public static void Stop()
    {
        stopwatch.Stop();
    }

    public static void Reset()
    {
        stopwatch.Reset();
    }

    public static void UpdateTime()
    {
        time = stopwatch.Elapsed.TotalSeconds;
    }
}
