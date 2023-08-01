using System;
using iku.Game.Graphics;

namespace iku.Game.Gamemaps.Players;

public static class PlayerTimer
{
    public static double RunningTime = 0;

    public static void Record()
    {
        RunningTime += Window.FrameTime;
    }

    public static void Reset()
    {
        RunningTime = 0;
    }
}
