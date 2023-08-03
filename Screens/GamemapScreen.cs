using System;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Gamemaps;
using iku.Screens;

namespace iku.Game.Screens;

public class GamemapScreen : IScreen
{
    public void Load()
    {
        Gamemap.Load();
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
    }

    public void Draw()
    {
        Raylib.BeginMode2D(GameCamera.Camera);

        Gamemap.Display();

        Raylib.EndMode2D();

        Gamemap.Overlay();
    }
}
