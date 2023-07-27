using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps.Players;
using iku.Game.Gamemaps;

namespace iku.Game.Overlays;

public static class Debug
{
    public static void Show()
    {
        PlayerCoodinate.Show();
        GamePerformance.Show();
        MapDebug.Show();
    }
}