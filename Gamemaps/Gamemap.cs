using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;
using iku.Game.Overlays;

namespace iku.Game.Gamemaps;

public static class Gamemap
{
    private static bool DebugMode;

    public static void Load()
    {
        DebugMode = true;

        GameCamera.Init();
        PlayerPoint.Init();
        GridGame.Load();
        SkinLoader.Load();
        MapLoader.Load();
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

        MapPoint player = new MapPoint(PlayerPoint.X-Window.Width / 2 / GameCamera.Zoom, PlayerPoint.Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();
    }

    public static void InputListener()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F10))
            if (DebugMode == true)
                DebugMode = false;
            else
                DebugMode = true;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F5))
        {
            PlayerTrack.Start();
            IkuTimer.Start();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F6))
        {
            PlayerTrack.Stop();
            IkuTimer.Stop();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F7))
        {
            IkuTimer.Reset();
            PlayerTrack.Reset();
        }
    }

    public static void Display()
    {
        GridGame.Draw();
        MapLoader.Draw();
        PlayerPoint.Display();
    }

    public static void Overlay()
    {
        if (DebugMode == true)
            Debug.Show();
    }
}
