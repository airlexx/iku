using System;

namespace iku.Game.Graphics.Coordinate;

public static class PointConvertion
{
    // Convert unit to screen point
    public static ScreenPoint UnitToScreen(UnitPoint position)
    {
        int X = (int)((position.X + 1) * Window.Width / 2);
        int Y = (int)((1 - position.Y) * Window.Height / 2);

        return new ScreenPoint(X, Y);
    }

    // Convert screen to unit point
    public static UnitPoint ScreenToUnit(int screenWidth, int screenHeight, int screenX, int screenY)
    {
        float X = (float)(screenX - (screenWidth / 2)) / (screenWidth / 2);
        float Y = (float)((screenHeight / 2) - screenY) / (screenHeight / 2);

        return new UnitPoint(X, Y);
    }

    // Convert screen to map point
    public static MapPoint ScreenToMap(ScreenPoint position)
    {
        float ratio = Window.Ratio;

        float X = (float)(position.X - (Window.Width / 2)) / (Window.Width / 2);
        float Y = (float)((Window.Height / 2) - position.Y) / (Window.Height / 2);

        if (ratio > 1.0f)
            X *= ratio;

        if ( ratio < 1.0f)
            X *= ratio;

        return new MapPoint(X * 100, Y * 100);
    }

    // Convert map point to screen point
    public static ScreenPoint MapToScreen(MapPoint position)
    {
        float ratio = Window.Ratio;

        float X = (float)(((position.X / 100) + 1) * Window.Width / 2);
        float Y = (float)((1 - (position.Y / 100)) * Window.Height / 2);

        if (ratio > 1.0f)
            X /= ratio;

        if ( ratio < 1.0f)
            X /= ratio;

        X = (int)(X + ((Window.Width / 2) - (Window.Width / 2 / ratio)));

        return new ScreenPoint((int)X, (int)Y);
    }
}