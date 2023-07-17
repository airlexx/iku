using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Overlays;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;

namespace iku.Game;

public class Game
{
    private Window Window;
    private Camera2D Camera;

    public void Run()
    {
        Init();

        Camera.zoom = 1.0f;

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
        Camera = new Camera2D();

        Map.Load();
    }

    private void Update()
    {
        Window.FrameRefresh();
        PlayerBall.GameInputListener();
        Camera.target = new Vector2(PlayerBall.X-Window.Width / 2 / Camera.zoom, PlayerBall.Y-Window.Height / 2 / Camera.zoom);
    }

    private void Draw()
    {
        Raylib.BeginDrawing();

        // Background
        Background.Display();

        Gamemap();

        // Overlays
        GamePerformance.Show();
        PlayerCoodinate.Show();

        Raylib.EndDrawing();
    }

    private void Gamemap()
    {
        Raylib.BeginMode2D(Camera);

        // Map
        Map.Display();

        // Player
        PlayerBall.Display();

        Raylib.EndMode2D();
    }

    private void Stop()
    {
        Raylib.CloseWindow();
        Window.Close();
    }
}
