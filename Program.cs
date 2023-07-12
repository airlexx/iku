using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Overlays;
using iku.Game.Gamemap;
using iku.Game.Gamemap.Player;

namespace iku.Game;

public static class Program
{
    public static void Main(string[] args)
    {
        Window window = new Window();

        Camera2D camera = new Camera2D();
        camera.zoom = 1.0f;

        // Main game loop
        while (!Raylib.WindowShouldClose())
        {
            window.FrameRefresh();

            PlayerBall.GameInputListener();
            
            camera.target = new Vector2(PlayerBall.X-Window.Width/2, PlayerBall.Y-Window.Height/2);

            // Draw
            Raylib.BeginDrawing();

                // Background
                Background.Display();

                // Game
                Raylib.BeginMode2D(camera);

                    // Map
                    Map.Display();

                    // Player
                    PlayerBall.Display();

                Raylib.EndMode2D();

                // Overlays
                GamePerformance.Show();
                PlayerCoodinate.Show();

            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
        Window.Close();
    }
}
