using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps;

public static class GridGame
{
    private static int GridSize = 20;
    private static int GridChunkSize = 500;
    private static float GridLineThick = 1f;
    private static int GridWidth;
    private static int GridHeight;
    private static int MidWindowWidth;
    private static int MidWindowHeight;
    private static RenderTexture2D GridTexture;

    public static void Load()
    {
        int gridCellSize = PointConvertion.MapToScreen(new MapPoint(1f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X;

        GridWidth = gridCellSize * GridChunkSize;
        GridHeight = gridCellSize * GridChunkSize;

        GridTexture = Raylib.LoadRenderTexture(GridWidth, GridHeight);

        // Generate texture
        Raylib.BeginTextureMode(GridTexture);

            // Draw vertical lines
            for (int x = 1; x <= GridWidth; x += gridCellSize)
                Raylib.DrawLineEx(new Vector2(x, 0), new Vector2(x, GridHeight), GridLineThick, Graphics.Color.Gray);

            // Draw horizontal lines
            for (int y = -1; y <= GridHeight; y += gridCellSize)
                Raylib.DrawLineEx(new Vector2(0, y), new Vector2(GridWidth, y), GridLineThick, Graphics.Color.Gray);

            // Draw border lines
            Raylib.DrawLineEx(new Vector2(0, GridHeight), new Vector2(GridWidth, GridHeight), GridLineThick * 2, Graphics.Color.Gray); // Top
            Raylib.DrawLineEx(new Vector2(GridWidth, GridHeight), new Vector2(GridWidth, 0), GridLineThick * 2, Graphics.Color.Gray); // Right
            Raylib.DrawLineEx(new Vector2(GridWidth, 0), new Vector2(0, 0), GridLineThick * 2, Graphics.Color.Gray); // Bottom
            Raylib.DrawLineEx(new Vector2(0, 0), new Vector2(GridWidth, 0), GridLineThick * 2, Graphics.Color.Gray); // Left

        Raylib.EndTextureMode();
    }

    public static void Unload()
    {
        Raylib.UnloadRenderTexture(GridTexture);
    }

    public static void Update()
    {
        MidWindowWidth = Window.Width / 2;
        MidWindowHeight = Window.Height / 2;
    }

    public static void Draw()
    {
        // Top left
        for (int y = 1; y <= GridSize; y++)
            for (int x = 1; x <= GridSize; x++)
                Raylib.DrawTextureEx(GridTexture.texture, new Vector2(MidWindowWidth + GridWidth * x * -1, MidWindowHeight + GridWidth * y * -1), 0, 1f, Graphics.Color.White);

        // Top right
        for (int y = 1; y <= GridSize; y++)
            for (int x = 0; x < GridSize; x++)
                Raylib.DrawTextureEx(GridTexture.texture, new Vector2(MidWindowWidth + GridWidth * x, MidWindowHeight + GridWidth * y * -1), 0, 1f, Graphics.Color.White);

        // Bottom right
        for (int y = 0; y < GridSize; y++)
            for (int x = 0; x < GridSize; x++)
                Raylib.DrawTextureEx(GridTexture.texture, new Vector2(MidWindowWidth + GridWidth * x, MidWindowHeight + GridWidth * y), 0, 1f, Graphics.Color.White);

        // Bottom left
        for (int y = 0; y < GridSize; y++)
            for (int x = 1; x <= GridSize; x++)
                Raylib.DrawTextureEx(GridTexture.texture, new Vector2(MidWindowWidth + GridWidth * x * -1, MidWindowHeight + GridWidth * y), 0, 1f, Graphics.Color.White);
    }
}
