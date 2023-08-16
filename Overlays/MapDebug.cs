using System;
using iku.Game.Graphics;
using iku.Game.Gamemaps.Points;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps;

namespace iku.Game.Overlays;

public static class MapDebug
{
    public static void Show()
    {
        uint id = PlayerTrack.FocusedHitPointID;
        double hitPointTime = MapLoader.HitPoints[id].Time;
        double lastHitTime = PlayerTrack.LastHitTime;

        Print.Draw($@"Time: {PlayerTimer.RunningTime:0.000} s", IkuFont.FiraCodeMedium, new UnitPoint(0f, 0.9f), TextAlign.center, TextAlign.bottom, 22f, 4f, Graphics.Color.White);

        Print.Draw($@"Test: {HitPointChecker.IsCollided}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, -0.9f), TextAlign.left, TextAlign.top, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Focused point: {PlayerTrack.FocusedHitPointID}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, -0.8f), TextAlign.left, TextAlign.top, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Current point: {PlayerTrack.CurrentHitPointID}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, -0.7f), TextAlign.left, TextAlign.top, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Focused time: {hitPointTime}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, -0.5f), TextAlign.left, TextAlign.top, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"Last Hit time: {lastHitTime:0.000}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, -0.4f), TextAlign.left, TextAlign.top, 22f, 4f, Graphics.Color.White);
    }
}
