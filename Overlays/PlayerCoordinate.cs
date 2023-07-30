using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps.Players;

namespace iku.Game.Overlays;

public static class PlayerCoodinate
{
    public static void Show()
    {
        MapPoint position = PointConvertion.ScreenToMap(new ScreenPoint((int)PlayerPoint.X, (int)PlayerPoint.Y));

        Print.Draw($@"X : {position.X}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.90f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Y : {position.Y}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.80f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);

        Print.Draw($@"Max Speed : {PlayerPoint.Speed} u/s", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.70f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
    }
}