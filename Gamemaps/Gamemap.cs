using System;
using iku.Game.Gamemaps.Players;

namespace iku.Game.Gamemaps;

public static class Gamemap
{
    public static void Load()
    {
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
        PlayerBall.Update();
        PlayerTrack.Update();
    }

    public static void Display()
    {
        GridGame.Draw();
        MapLoader.Draw();
    }
}
