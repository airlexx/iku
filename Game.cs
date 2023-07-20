using System;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Overlays;
using iku.Game.Gamemaps;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;

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

        GameCamera.Init();
        GameCamera.SetZoom(1.0f);
        
        Map.Load();
    }

    private void Update()
    {
        Window.Update();
        PlayerBall.GameInputListener();

        MapPoint player = new MapPoint(PlayerBall.X-Window.Width / 2 / GameCamera.Zoom, PlayerBall.Y-Window.Height / 2 / GameCamera.Zoom);
        GameCamera.Target(player);

        GameCamera.PostionUpdate();
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
        Raylib.BeginMode2D(GameCamera.Camera);

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
