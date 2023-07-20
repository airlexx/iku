using System;

namespace iku.Game.Gamemaps;

public static class Map
{
    public static void Load()
    {
        GridGame.Load();
        MapLoader.Load();
    }

    public static void Display()
    {
        GridGame.Draw();
        MapLoader.Draw();
    }
}
