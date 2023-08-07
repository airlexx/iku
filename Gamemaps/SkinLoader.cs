using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Gamemaps.Points;

namespace iku.Game.Gamemaps;

public static class SkinLoader
{
    private const string SkinDir = "Skins/iku";

    public static readonly Texture2D[] HitPointRight = new Texture2D[3];
    public static readonly Texture2D[] HitPointLeft = new Texture2D[3];
    public static readonly Texture2D[] HitPointUp = new Texture2D[3];
    public static readonly Texture2D[] HitPointDown = new Texture2D[3];

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

        HitPointRight[0] = Raylib.LoadTextureFromImage(hitPointR0);
        HitPointLeft[0] = Raylib.LoadTextureFromImage(hitPointL0);
        HitPointUp[0] = Raylib.LoadTextureFromImage(hitPointU0);
        HitPointDown[0] = Raylib.LoadTextureFromImage(hitPointD0);

        HitPointRight[1] = Raylib.LoadTextureFromImage(hitPointR1);
        HitPointLeft[1] = Raylib.LoadTextureFromImage(hitPointL1);
        HitPointUp[1] = Raylib.LoadTextureFromImage(hitPointU1);
        HitPointDown[1] = Raylib.LoadTextureFromImage(hitPointD1);

        HitPointRight[2] = Raylib.LoadTextureFromImage(hitPointR2);
        HitPointLeft[2] = Raylib.LoadTextureFromImage(hitPointL2);
        HitPointUp[2] = Raylib.LoadTextureFromImage(hitPointU2);
        HitPointDown[2] = Raylib.LoadTextureFromImage(hitPointD2);

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
}
