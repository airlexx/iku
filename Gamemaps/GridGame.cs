using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps;

public static class GridGame
{
    private static int GridSize = 500;
    private static float GridThick = 1f;
    private static RenderTexture2D GridTexture;

    public static void Load()
    {
        int gridCellSize = PointConvertion.MapToScreen(new MapPoint(10f, 0f)).X - PointConvertion.MapToScreen(new MapPoint(0f, 0f)).X;

        int gridX = gridCellSize * GridSize;
        int gridY = gridCellSize * GridSize;

        GridTexture = Raylib.LoadRenderTexture(gridX, gridY);

        // Generate texture
        Raylib.BeginTextureMode(GridTexture);

            // Draw vertical lines
            for (int x = 1; x <= gridX; x += gridCellSize)
                Raylib.DrawLineEx(new Vector2(x, 0), new Vector2(x, gridY), GridThick, Graphics.Color.Gray);

            // Draw horizontal lines
            for (int y = -1; y <= gridY; y += gridCellSize)
                Raylib.DrawLineEx(new Vector2(0, y), new Vector2(gridX, y), GridThick, Graphics.Color.Gray);

        Raylib.EndTextureMode();
    }

    public static void Draw()
    {
        for (int r = 0; r <= 360; r += 90)
            Raylib.DrawTextureEx(GridTexture.texture, new Vector2(Window.Width/2, Window.Height/2), r, 1f, Graphics.Color.White);
    }
}
