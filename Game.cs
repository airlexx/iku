using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Screens;
using iku.Game.Gamemaps;

namespace iku.Game;

public class Game
{
    private Window Window;
    private ScreenManager screenManager = new ScreenManager();

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
        Window = new Window();
        screenManager.Init();
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

    private void Stop()
    {
        Raylib.CloseWindow();
        Window.Close();
    }
}
