using System;

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

    public static void Display()
    {
        GridGame.Draw();
        MapLoader.Draw();
    }
}
