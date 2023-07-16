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

        Print.Info($"X : {position.X.ToString("0.00")}", new UnitPoint(-0.90f, 0.90f));
        Print.Info($"Y : {position.Y.ToString("0.00")}", new UnitPoint(-0.90f, 0.85f));
    }
}