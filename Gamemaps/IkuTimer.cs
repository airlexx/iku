using System;
using System.Diagnostics;
using Raylib_cs;

namespace iku.Game.Gamemaps;

public static class IkuTimer
{
    public static double Time;
    private static Stopwatch Stopwatch = new Stopwatch();

    public static void Start()
    {
        Stopwatch.Start();
    }

    public static void Stop()
    {
        Stopwatch.Stop();
    }

    public static void Reset()
    {
        Stopwatch.Reset();
    }

    public static void UpdateTime()
    {
        Time = Stopwatch.Elapsed.TotalSeconds;
    }
}
