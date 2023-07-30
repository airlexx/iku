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

        PlayerPoint.Init();
        Gamemap.Load();

        DebugMode = true;

       Logger.Info("Gamemap screen loaded");
    }

    public void Unload()
    {
        Gamemap.Unload();

        Logger.Info("Gamemap screen unloaded");
    }

    public void Update()
    {
        Gamemap.Update();
        
        GridGame.Update();

        IkuTimer.UpdateTime();

        MapPoint player = new MapPoint(PlayerPoint.X-Window.Width / 2 / GameCamera.Zoom, PlayerPoint.Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F10))
            if (DebugMode == true)
                DebugMode = false;
            else
                DebugMode = true;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5))
        {
            IkuTimer.Start();
            PlayerTrack.Start();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F6))
        {
            IkuTimer.Stop();
            PlayerTrack.Stop();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F7))
        {
            IkuTimer.Reset();
            PlayerTrack.Reset();
        }
    }

    public void Draw()
    {
        Raylib.BeginMode2D(GameCamera.Camera);

        Gamemap.Display();
        PlayerPoint.Display();

        Raylib.EndMode2D();

        Overlays();
    }

    private void Overlays()
    {
        if (DebugMode == true)
            Debug.Show();
    }
}