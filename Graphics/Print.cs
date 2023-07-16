using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Graphics;

public static class Print
{
    public static void Info(string text, UnitPoint position)
    {
        ScreenPoint point = PointConvertion.UnitToScreen(position);
        Vector2 vec2 = new Vector2(point.X, point.Y);

        Raylib.SetTextureFilter(Font.fontFiraCodeMedium.texture, TextureFilter.TEXTURE_FILTER_POINT);

        Raylib.DrawTextEx(Font.fontFiraCodeMedium, text, vec2, 24, 4, Color.SpringGreen);
    }
}