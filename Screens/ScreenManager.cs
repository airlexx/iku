using System;
using Raylib_cs;
using iku.Game.Utils;

namespace iku.Game.Screens;

public static class ScreenManager
{
    private static Screen CurrentScreen;

    public static void Init()
    {
        CurrentScreen = Screen.Home;
        Logger.Info("Screen manager loaded");
    }

    public static void Update()
    {
        Switcher();

        switch (CurrentScreen)
        {
            case Screen.Home:
                HomeScreen.Update();
                break;
            case Screen.Loading:
                LoadingScreen.Update();
                break;
            case Screen.Gamemap:
                GamemapScreen.Update();
                break;
            default:
                break;
        }
    }

    public static void Draw()
    {
        switch (CurrentScreen)
        {
            case Screen.Home:
                HomeScreen.Draw();
                break;
            case Screen.Loading:
                LoadingScreen.Draw();
                break;
            case Screen.Gamemap:
                GamemapScreen.Draw();
                break;
            default:
                break;
        }
    }

    public static void Switcher()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F1))
            Switch(Screen.Loading);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F2))
            Switch(Screen.Home);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_F3))
            Switch(Screen.Gamemap);
    }

    public static void Switch(Screen scene)
    {
        CurrentScreen = scene;
        Logger.Info($"Screen switched to {scene}");
    }
}