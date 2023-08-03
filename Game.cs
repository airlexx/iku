using System;
using Raylib_cs;
using iku.Game.Screens;
using iku.Game.Graphics;

namespace iku.Game;

public class Game
{
    private readonly ScreenManager screenManager = new();

    public void Run()
    {
        Init();

        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Stop();
    }

    private void Init()
    {
        _ = new Window();
        screenManager.Init();
        FontManager.LoadFonts();
    }

    private void Update()
    {
        Window.Update();
        screenManager.Update();
    }

    private void Draw()
    {
        Raylib.BeginDrawing();

        Background.Display();
        screenManager.Draw();

        Raylib.EndDrawing();
    }

    private static void Stop()
    {
        FontManager.UnloadFonts();
        Raylib.CloseWindow();
        Window.Close();
    }
}
