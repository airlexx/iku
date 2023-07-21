using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Screens;

public static class LoadingScreen
{
    public static void Update()
    {
        //
    }

    public static void Draw()
    {
        string text = "loading...";

        ScreenPoint point = PointConvertion.UnitToScreen(new UnitPoint(-0.9f, 0.9f));
        Vector2 vec2 = new Vector2(point.X, point.Y);

        Raylib.SetTextureFilter(Graphics.Font.fontFiraCodeMedium.texture, TextureFilter.TEXTURE_FILTER_POINT);

        Raylib.DrawTextEx(Graphics.Font.fontFiraCodeMedium, text, vec2, 90, 4, Graphics.Color.White);
    }
}
