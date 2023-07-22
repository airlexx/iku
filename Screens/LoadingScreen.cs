using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics.Coordinates;

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
        string text = "loading...";

        ScreenPoint point = PointConvertion.UnitToScreen(new UnitPoint(-0.9f, 0.9f));
        Vector2 vec2 = new Vector2(point.X, point.Y);

        Raylib.SetTextureFilter(Graphics.Font.fontFiraCodeMedium.texture, TextureFilter.TEXTURE_FILTER_POINT);

        Raylib.DrawTextEx(Graphics.Font.fontFiraCodeMedium, text, vec2, 90, 4, Graphics.Color.White);
    }
}
