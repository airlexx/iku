using System;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Screens;

namespace iku.Game.Screens;

public class HomeScreen : IScreen
{
    public void Load()
    {
        Logger.Info($"Home screen loaded");
    }

    public void Unload()
    {
        Logger.Info($"Home screen unloaded");
    }

    public void Update()
    {
        //
    }

    public void Draw()
    {
        Print.Draw("iku", IkuFont.ChillaxBold, new UnitPoint(0f, 0f), TextAlign.center, TextAlign.middle, 300f, 4f, Graphics.Color.White);
    }
}
