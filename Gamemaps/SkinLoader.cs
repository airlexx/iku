using System;
using System.Numerics;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Gamemaps.Points;

namespace iku.Game.Gamemaps;

public static class SkinLoader
{
    private const string SkinDir = "Skins/iku";

    private static Texture2D TextureHitPointRight;
    private static Texture2D TextureHitPointLeft;
    private static Texture2D TextureHitPointUp;
    private static Texture2D TextureHitPointDown;

    public static void Load()
    {
        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SkinDir);

        Image HitPointRight = Raylib.LoadImage(Path.Combine(dir, "hitpoint-right.png"));
        Image HitPointLeft = Raylib.LoadImage(Path.Combine(dir, "hitpoint-left.png"));
        Image HitPointUp = Raylib.LoadImage(Path.Combine(dir, "hitpoint-up.png"));
        Image HitPointDown = Raylib.LoadImage(Path.Combine(dir, "hitpoint-down.png"));

        TextureHitPointRight = Raylib.LoadTextureFromImage(HitPointRight);
        TextureHitPointLeft = Raylib.LoadTextureFromImage(HitPointLeft);
        TextureHitPointUp = Raylib.LoadTextureFromImage(HitPointUp);
        TextureHitPointDown = Raylib.LoadTextureFromImage(HitPointDown);

        Raylib.UnloadImage(HitPointUp);
    }

    public static void DrawPoint(HitPointAction action, Vector2 position, float size)
    {
        Texture2D hitPointTexture;

        Rectangle recSource = new Rectangle(0, 0, 256, 256);
        Rectangle recDest = new Rectangle(position.X, position.Y, size, size);
        Vector2 origin = new Vector2(size / 2, size / 2);

        switch (action)
        {
            case HitPointAction.Right:
                hitPointTexture = TextureHitPointRight;
            break;

            case HitPointAction.Left:
                hitPointTexture = TextureHitPointLeft;
            break;

            case HitPointAction.Up:
                hitPointTexture = TextureHitPointUp;
            break;

            case HitPointAction.Down:
                hitPointTexture = TextureHitPointDown;
            break;

            default:
                hitPointTexture = TextureHitPointUp;
            break;
        }

        Raylib.DrawTexturePro(hitPointTexture, recSource, recDest, origin, 0f, Color.WHITE);
    }
}
