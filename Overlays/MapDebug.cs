using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps;

namespace iku.Game.Overlays;

public static class MapDebug
{
    public static void Show()
    {
        int hitPointCount = MapLoader.rowCount;

        Print.Draw($@"HitPoints : {hitPointCount}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.60f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
    }
}