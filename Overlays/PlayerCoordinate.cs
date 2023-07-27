using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps.Players;

namespace iku.Game.Overlays;

public static class PlayerCoodinate
{
    public static void Show()
    {
        MapPoint position = PointConvertion.ScreenToMap(new ScreenPoint((int)PlayerBall.X, (int)PlayerBall.Y));

        Print.Draw($@"X : {position.X.ToString("0.00")}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.90f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Y : {position.Y.ToString("0.00")}", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.80f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);

        Print.Draw($@"Max Speed : {PlayerBall.Speed} u/s", IkuFont.FiraCodeMedium ,new UnitPoint(-0.90f, 0.70f), TextAlign.left, TextAlign.bottom, 22f, 4f, Graphics.Color.White);
    }
}