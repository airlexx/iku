using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Utils;

namespace iku.Game.Gamemaps;

public static class GameCamera
{
    public static float Zoom;
    public static Camera2D Camera;
    public static MapPoint Position;

    public static void Init()
    {
        Camera = new Camera2D();

        Logger.Info("Camera initialized");
    }

    public static void SetZoom(float zoom)
    {
        Zoom = zoom;
        Camera.zoom = zoom;

        Logger.Info($"Camera zoomed in x{zoom}");
    }

    public static void Target(MapPoint position)
    {
        Camera.target = new Vector2(position.X, position.Y);
    }

    public static void PostionUpdate()
    {
        ScreenPoint position = new ScreenPoint((int)Camera.target.X + Window.Width / 2, (int)Camera.target.Y + Window.Height / 2);
        Position = PointConvertion.ScreenToMap(position);
    }
}
