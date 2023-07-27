using System;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;
using iku.Game.Overlays;

namespace iku.Game.Screens;

public class GamemapScreen : IScreen
{
    private bool DebugMode;

    public void Load()
    {
        GameCamera.Init();
        GameCamera.SetZoom(1.0f);

        PlayerBall.Init();
        Gamemap.Load();

        Logger.Info("Gamemap screen loaded");

        DebugMode = true;
    }

    public void Unload()
    {
        Gamemap.Unload();
        Logger.Info("Gamemap screen unloaded");
    }

    public void Update()
    {
        PlayerBall.GameInputListener();
        
        GridGame.Update();

        MapPoint player = new MapPoint(PlayerBall.X-Window.Width / 2 / GameCamera.Zoom, PlayerBall.Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F10))
            if (DebugMode == true)
                DebugMode = false;
            else
                DebugMode = true;
    }

    public void Draw()
    {
        Raylib.BeginMode2D(GameCamera.Camera);

        Gamemap.Display();
        PlayerBall.Display();

        Raylib.EndMode2D();

        Overlays();
    }

    private void Overlays()
    {
        if (DebugMode == true)
            Debug.Show();
    }
}