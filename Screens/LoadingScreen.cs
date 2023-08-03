using System;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Screens;

namespace iku.Game.Screens;

public class LoadingScreen : IScreen
{
    public void Load()
    {
        Logger.Info($"Loading screen");
    }

    public void Unload()
    {
        Logger.Info($"Unloaded");
    }

    public void Update()
    {
        //
    }

    public void Draw()
    {
        Print.Draw("loading...", IkuFont.FiraCodeMedium ,new UnitPoint(0.9f, -0.9f), TextAlign.right, TextAlign.top, 36f, 4f, Graphics.Color.White);
    }
}
