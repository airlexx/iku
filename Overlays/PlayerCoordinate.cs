using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps.Players;

namespace iku.Game.Overlays;

public static class PlayerCoodinate
{
    public static void Show()
    {
        MapPoint position = PlayerPoint.GetMapPosition();

        Print.Draw($@"X: {position.X:0.00}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.90f), TextAlign.left, TextAlign.bottom, 22f, 4f, Color.White);
        Print.Draw($@"Y: {position.Y:0.00}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.80f), TextAlign.left, TextAlign.bottom, 22f, 4f, Color.White);
    }
}