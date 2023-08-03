using System;
using iku.Game.Graphics;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Overlays;

public static class MapDebug
{
    public static void Show()
    {
        Print.Draw($@"Time: {PlayerTimer.RunningTime:0.000} s", IkuFont.FiraCodeMedium ,new UnitPoint(0f, 0.9f), TextAlign.center, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
    }
}