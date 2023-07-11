using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinate;

namespace iku.Game.Overlays;

public static class GamePerformance
{
    public static void Show()
    {
        Print.Info(Window.FrameRate.ToString(), new UnitPoint(0.90f, -0.90f));
    }
}