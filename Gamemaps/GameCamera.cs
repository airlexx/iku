using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;
using iku.Game.Utils;

namespace iku.Game.Gamemaps;

public class GameCamera
{
    private static float zoom;
    private static Camera2D camera;
    private static MapPoint mapPosition;
    private const float DefaultZoom = 1.0f;

    public static MapPoint MapPosition { get => mapPosition; set => mapPosition = value; }
    public static Camera2D Camera { get => camera; }
    public static float Zoom { get => zoom; }

    public static void Init()
    {
        camera = new Camera2D();

        zoom = DefaultZoom;
        camera.zoom = DefaultZoom;

        Logger.Info("Camera initialized");
    }

    public static void SetZoom(float z)
    {
        zoom = z;
        camera.zoom = Zoom;

        Logger.Info($"Camera zoomed in x{zoom}");
    }

    public static void Target(MapPoint position)
    {
        camera.target = new Vector2(position.X, position.Y);
    }

    public static void PostionUpdate()
    {
        ScreenPoint position = new((int)camera.target.X + Window.Width / 2, (int)camera.target.Y + Window.Height / 2);
        MapPosition = PointConvertion.ScreenToMap(position);
    }
}
