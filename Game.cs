using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Screens;
using iku.Game.Gamemaps;

namespace iku.Game;

public class Game
{
    private Window Window;

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

        ScreenManager.Init();

        GameCamera.Init();
        GameCamera.SetZoom(1.0f);
        
        Map.Load();
    }

    private void Update()
    {
        Window.Update();
        ScreenManager.Update();
    }

    private void Draw()
    {
        Raylib.BeginDrawing();

        Background.Display();
        ScreenManager.Draw();

        Raylib.EndDrawing();
    }

    private void Stop()
    {
        Raylib.CloseWindow();
        Window.Close();
    }
}
