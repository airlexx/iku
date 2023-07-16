using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps;

public static class Map
{
    public static void Load()
    {
        Gamemaps.GridGame.Load();
    }

    public static void Display()
    {
        ScreenPoint p1 = PointConvertion.MapToScreen(new MapPoint(0f, 0f));
        ScreenPoint p2 = PointConvertion.MapToScreen(new MapPoint(0f, 100f));
        ScreenPoint p3 = PointConvertion.MapToScreen(new MapPoint(100f, 0f));
        ScreenPoint p4 = PointConvertion.MapToScreen(new MapPoint(0f, -100f));
        ScreenPoint p5 = PointConvertion.MapToScreen(new MapPoint(-100f, 0f));

        Raylib.DrawCircleV(new Vector2(p1.X, p1.Y), 4, Graphics.Color.White);
        Raylib.DrawCircleV(new Vector2(p2.X, p2.Y), 4, Graphics.Color.White);
        Raylib.DrawCircleV(new Vector2(p3.X, p3.Y), 4, Graphics.Color.White);
        Raylib.DrawCircleV(new Vector2(p4.X, p4.Y), 4, Graphics.Color.White);
        Raylib.DrawCircleV(new Vector2(p5.X, p5.Y), 4, Graphics.Color.White);

        Gamemaps.GridGame.Draw();
    }
}
