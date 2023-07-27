using System;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Screens;

public class StatsScreen : IScreen
{
    public void Load()
    {
        Logger.Info($"Stats screen loaded");
    }

    public void Unload()
    {
        Logger.Info($"Stats screen unloaded");
    }

    public void Update()
    {
        //
    }

    public void Draw()
    {
        Print.Draw("statistics", IkuFont.FiraCodeMedium ,new UnitPoint(0f, 0.9f), TextAlign.center, TextAlign.bottom, 36f, 4f, Graphics.Color.White);
    }
}