using System;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Overlays;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;
using iku.Game.Gamemaps.Points;

namespace iku.Game.Gamemaps;

public static class Gamemap
{
    private static bool debugMode;

    public static void Load()
    {
        debugMode = true;

        GameCamera.Init();
        PlayerPoint.Init();
        GridGame.Load();
        SkinLoader.Load();
        MapLoader.Init();
        MapLoader.LoadHitPointsFile();
        MapLoader.LoadHitPoints();
        PlayerTrack.Load();
    }

    public static void Unload()
    {
        GridGame.Unload();
    }

    public static void Update()
    {
        InputListener();

        PlayerPoint.Update();
        PlayerTrack.Update();
        GridGame.Update();
        IkuTimer.UpdateTime();

        MapPoint player = new(PlayerPoint.GetScreenPoint().X-Window.Width / 2 / GameCamera.Zoom, PlayerPoint.GetScreenPoint().Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();
    }

    public static void InputListener()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F10))
            if (debugMode == true)
                debugMode = false;
            else
                debugMode = true;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5))
            PlayerTrack.Start();

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F6))
            PlayerTrack.Stop();

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F7))
            PlayerTrack.Reset();
    }

    public static void Display()
    {
        GridGame.Draw();
        HitPointDrawer.Draw();
        PlayerPoint.Display();
    }

    public static void Overlay()
    {
        if (debugMode == true)
            Debug.Show();
    }
}
