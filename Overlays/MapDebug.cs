using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;

namespace iku.Game.Overlays;

public static class MapDebug
{
    public static void Show()
    {
        Print.Draw($@"Time : {Math.Round(IkuTimer.Time, 3).ToString("0.000")} s", IkuFont.FiraCodeMedium ,new UnitPoint(0f, 0.90f), TextAlign.center, TextAlign.bottom, 22f, 4f, Graphics.Color.White);

        Print.Draw($@"{PlayerTrack.CurrentHitPointID - 1} / {MapLoader.HitPointCount} : HitPoints", IkuFont.FiraCodeMedium ,new UnitPoint(0.90f, 0.90f), TextAlign.right, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
    }
}