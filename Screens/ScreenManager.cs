using System;
using Raylib_cs;
using iku.Game.Utils;
using iku.Screens;

namespace iku.Game.Screens;

public class ScreenManager
{
    private readonly Dictionary<int, IScreen> screens = new();
    private int currentScreen;

    public void Init()
    {
        Add(1, new LoadingScreen());
        Add(2, new HomeScreen());
        Add(3, new GamemapScreen());
        Add(4, new StatsScreen());
        Add(5, new InfoScreen());

        Switch(3);
    }

    public void Add(int screenType, IScreen screen)
    {
        screens.Add(screenType, screen);
    }

    public void Switch(int screenType)
    {
        if (screens.TryGetValue(currentScreen, out var screen))
            screen.Unload();

        if (screens.TryGetValue(screenType, out var newScreen))
        {
            currentScreen = screenType;
            newScreen.Load();
        }
        else
            Logger.Error("Screen not found");
    }

    public void Switcher()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F1))
            Switch(1);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F2))
            Switch(2);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F3))
            Switch(3);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F4))
            Switch(4);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F9))
            Switch(5);
    }

    public void Update()
    {
        Switcher();


        if (screens.TryGetValue(currentScreen, out var screen))
        {
            screen.Update();

            if (Raylib.IsWindowResized())
            {
                screen.Unload();
                screen.Load();
                Logger.Info($"Refreshed");
            }
        }
    }

    public void Draw()
    {
        if (screens.TryGetValue(currentScreen, out var screen))
            screen.Draw();
    }
}
