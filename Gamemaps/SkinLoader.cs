using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Gamemaps.Points;

namespace iku.Game.Gamemaps;

public static class SkinLoader
{
    private const string SkinDir = "Skins/iku";

    private static readonly Texture2D[] hitPointRight = new Texture2D[3];
    private static readonly Texture2D[] hitPointLeft = new Texture2D[3];
    private static readonly Texture2D[] hitPointUp = new Texture2D[3];
    private static readonly Texture2D[] hitPointDown = new Texture2D[3];

    public static void Load()
    {
        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SkinDir);

        Image hitPointR0 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-right-0.png"));
        Image hitPointL0 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-left-0.png"));
        Image hitPointU0 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-up-0.png"));
        Image hitPointD0 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-down-0.png"));

        Image hitPointR1 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-right-1.png"));
        Image hitPointL1 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-left-1.png"));
        Image hitPointU1 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-up-1.png"));
        Image hitPointD1 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-down-1.png"));

        Image hitPointR2 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-right-2.png"));
        Image hitPointL2 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-left-2.png"));
        Image hitPointU2 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-up-2.png"));
        Image hitPointD2 = Raylib.LoadImage(Path.Combine(dir, "hitpoint-down-2.png"));


        hitPointRight[0] = Raylib.LoadTextureFromImage(hitPointR0);
        hitPointLeft[0] = Raylib.LoadTextureFromImage(hitPointL0);
        hitPointUp[0] = Raylib.LoadTextureFromImage(hitPointU0);
        hitPointDown[0] = Raylib.LoadTextureFromImage(hitPointD0);

        hitPointRight[1] = Raylib.LoadTextureFromImage(hitPointR1);
        hitPointLeft[1] = Raylib.LoadTextureFromImage(hitPointL1);
        hitPointUp[1] = Raylib.LoadTextureFromImage(hitPointU1);
        hitPointDown[1] = Raylib.LoadTextureFromImage(hitPointD1);

        hitPointRight[2] = Raylib.LoadTextureFromImage(hitPointR2);
        hitPointLeft[2] = Raylib.LoadTextureFromImage(hitPointL2);
        hitPointUp[2] = Raylib.LoadTextureFromImage(hitPointU2);
        hitPointDown[2] = Raylib.LoadTextureFromImage(hitPointD2);

        Raylib.UnloadImage(hitPointR0);
        Raylib.UnloadImage(hitPointL0);
        Raylib.UnloadImage(hitPointU0);
        Raylib.UnloadImage(hitPointD0);

        Raylib.UnloadImage(hitPointR1);
        Raylib.UnloadImage(hitPointL1);
        Raylib.UnloadImage(hitPointU1);
        Raylib.UnloadImage(hitPointD1);

        Raylib.UnloadImage(hitPointR2);
        Raylib.UnloadImage(hitPointL2);
        Raylib.UnloadImage(hitPointU2);
        Raylib.UnloadImage(hitPointD2);
    }

    public static void DrawPoint(HitPointAction action, byte status, Vector2 position, float size)
    {
        Rectangle recSource = new(0, 0, 256, 256);
        Rectangle recDest = new(position.X, position.Y, size, size);
        Vector2 origin = new(size / 2, size / 2);

        var hitPointTexture = action switch
        {
            HitPointAction.Right => hitPointRight[status],
            HitPointAction.Left => hitPointLeft[status],
            HitPointAction.Up => hitPointUp[status],
            HitPointAction.Down => hitPointDown[status],
            _ => hitPointDown[0],
        };

        Raylib.DrawTexturePro(hitPointTexture, recSource, recDest, origin, 0f, Color.WHITE);
    }
}
