using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;
using iku.Game.Overlays;

namespace iku.Game.Screens;

public static class GamemapScreen
{   
    public static void Update()
    {
        PlayerBall.GameInputListener();
        
        MapPoint player = new MapPoint(PlayerBall.X-Window.Width / 2 / GameCamera.Zoom, PlayerBall.Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();
    }

    public static void Draw()
    {
        Raylib.BeginMode2D(GameCamera.Camera);

        Map.Display();
        PlayerBall.Display();

        Raylib.EndMode2D();

        Overlays();
    }

    private static void Overlays()
    {
        GamePerformance.Show();
        PlayerCoodinate.Show();
    }
}