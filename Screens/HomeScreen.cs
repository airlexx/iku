using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics.Coordinates;

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
        string text = "iku";

        ScreenPoint point = PointConvertion.UnitToScreen(new UnitPoint(-0.9f, 0.9f));
        Vector2 vec2 = new Vector2(point.X, point.Y);

        Raylib.SetTextureFilter(Graphics.Font.fontChillaxBold.texture, TextureFilter.TEXTURE_FILTER_BILINEAR);

        Raylib.DrawTextEx(Graphics.Font.fontChillaxBold, text, vec2, 300, 4, Graphics.Color.White);
    }
}
