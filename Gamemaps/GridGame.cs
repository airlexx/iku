using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;

namespace iku.Game.Gamemaps;

public static class GridGame
{
    private const int gridSize = 20;
    private const int gridChunkSize = 500;
    private const float gridLineThick = 1f;
    private static float gridCellSize;
    private static float gridWidth;
    private static float gridHeight;
    private static int midWindowWidth;
    private static int midWindowHeight;
    private static RenderTexture2D gridTexture;

    public static void Load()
    {
        gridCellSize = Window.Height / 20f;

        gridWidth = gridCellSize * gridChunkSize;
        gridHeight = gridCellSize * gridChunkSize;

        gridTexture = Raylib.LoadRenderTexture((int)gridWidth, (int)gridHeight);

        // Generate texture
        Raylib.BeginTextureMode(gridTexture);

            // Draw vertical lines
            for (float x = 0; x <= gridWidth; x += gridCellSize)
                Raylib.DrawLineEx(new Vector2(x, 0), new Vector2(x, gridHeight), gridLineThick, Graphics.Color.Gray);

            // Draw horizontal lines
            for (float y = 0; y <= gridHeight; y += gridCellSize)
                Raylib.DrawLineEx(new Vector2(0, y), new Vector2(gridWidth, y), gridLineThick, Graphics.Color.Gray);

            // Draw border lines
            Raylib.DrawLineEx(new Vector2(0, gridHeight), new Vector2(gridWidth, gridHeight), gridLineThick * 2, Graphics.Color.Gray); // Top
            Raylib.DrawLineEx(new Vector2(gridWidth, gridHeight), new Vector2(gridWidth, 0), gridLineThick * 2, Graphics.Color.Gray); // Right
            Raylib.DrawLineEx(new Vector2(gridWidth, 0), new Vector2(0, 0), gridLineThick * 2, Graphics.Color.Gray); // Bottom
            Raylib.DrawLineEx(new Vector2(0, 0), new Vector2(gridWidth, 0), gridLineThick * 2, Graphics.Color.Gray); // Left

        Raylib.EndTextureMode();
    }

    public static void Unload()
    {
        Raylib.UnloadRenderTexture(gridTexture);
    }

    public static void Update()
    {
        midWindowWidth = Window.Width / 2;
        midWindowHeight = Window.Height / 2;
    }

    public static void Draw()
    {
        // Top left
        for (int y = 1; y <= gridSize; y++)
            for (int x = 1; x <= gridSize; x++)
                Raylib.DrawTextureEx(gridTexture.texture, new Vector2(midWindowWidth + gridWidth * x * -1, midWindowHeight + gridWidth * y * -1), 0, 1f, Graphics.Color.White);

        // Top right
        for (int y = 1; y <= gridSize; y++)
            for (int x = 0; x < gridSize; x++)
                Raylib.DrawTextureEx(gridTexture.texture, new Vector2(midWindowWidth + gridWidth * x, midWindowHeight + gridWidth * y * -1), 0, 1f, Graphics.Color.White);

        // Bottom right
        for (int y = 0; y < gridSize; y++)
            for (int x = 0; x < gridSize; x++)
                Raylib.DrawTextureEx(gridTexture.texture, new Vector2(midWindowWidth + gridWidth * x, midWindowHeight + gridWidth * y), 0, 1f, Graphics.Color.White);

        // Bottom left
        for (int y = 0; y < gridSize; y++)
            for (int x = 1; x <= gridSize; x++)
                Raylib.DrawTextureEx(gridTexture.texture, new Vector2(midWindowWidth + gridWidth * x * -1, midWindowHeight + gridWidth * y), 0, 1f, Graphics.Color.White);
    }
}
