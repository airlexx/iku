using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Graphics;

public static class Print
{
    public static void Draw(string text, IkuFont font, UnitPoint position, TextAlign alignX, TextAlign alignY, float fontSize, float spacing, Raylib_cs.Color color)
    {
        float adjustmentX = default;
        float adjustmentY = default;

        Vector2 stringSize = Raylib.MeasureTextEx(FontManager.GetFont(font), text, fontSize, spacing);

        switch (alignX)
        {
            case TextAlign.center:
                adjustmentX -= stringSize.X / 2;
                break;

            case TextAlign.right:
                adjustmentX -= stringSize.X;
                break;

            default:
                adjustmentX = 0;
                break;
        }

        switch (alignY)
        {
            case TextAlign.top:
                adjustmentY -= stringSize.Y;
                break;

            case TextAlign.middle:
                adjustmentY -= stringSize.Y / 2;
                break;

            default:
                adjustmentY = 0;
                break;
        }

        ScreenPoint point = PointConvertion.UnitToScreen(position);
        Vector2 vec2 = new(point.X + adjustmentX, point.Y + adjustmentY);

        Raylib.SetTextureFilter(FontManager.GetFont(font).texture, TextureFilter.TEXTURE_FILTER_BILINEAR);
        Raylib.DrawTextEx(FontManager.GetFont(font), text, vec2, fontSize, spacing, color);
    }
}
