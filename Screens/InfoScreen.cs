using System;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Screens;

namespace iku.Game.Screens;

public class InfoScreen : IScreen
{
    private float letterSpacing;

    public void Load()
    {
        Logger.Info($"Info screen loaded");
    }

    public void Unload()
    {
        Logger.Info($"Info screen unloaded");
    }

    public void Update()
    {
        //
    }

    public void Draw()
    {
        letterSpacing = 2f;

        Print.Draw(@"information", IkuFont.FiraCodeMedium, new UnitPoint(0f, 0.9f), TextAlign.center, TextAlign.bottom, 36f, letterSpacing, Graphics.Color.White);

        Print.Draw(@"Desktop", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.6f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
        Print.Draw($@"Size : {Window.MonitorWidth}x{Window.MonitorHeight} ({Window.MonitorRatio:0.000})", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.5f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
        Print.Draw($@"Monitor ID : {Window.CurrentMonitor} / {Window.MonitorCount}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.4f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
        Print.Draw($@"Refresh rate : {Window.MonitorRefreshRate}hz", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.3f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);

        Print.Draw(@"Window", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.2f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
        Print.Draw($@"Size : {Window.Width}x{Window.Height} ({Window.WindowRatio:0.000})", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0.1f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
        Print.Draw($@"Frame limit : {Window.FrameLimit}", IkuFont.FiraCodeMedium, new UnitPoint(-0.9f, 0f), TextAlign.left, TextAlign.bottom, 22f, letterSpacing, Graphics.Color.White);
    }
}
