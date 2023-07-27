using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Overlays;

public static class GamePerformance
{
    private static int FrameRate;
    private static float FrameTime;
    private static double ElapsedTime;
    private static float RefreshTime = 0.5f;

    public static void Show()
    {
        float deltaTime = Window.FrameTime;
        ElapsedTime += deltaTime;

        if (ElapsedTime >= RefreshTime)
        {
            FrameRate = Window.FrameRate;
            FrameTime = Window.FrameTime;

            ElapsedTime = 0;
        }

        Print.Draw($@"{FrameRate} fps", IkuFont.FiraCodeMedium ,new UnitPoint(0.90f, -0.80f), TextAlign.right, TextAlign.top, 22f, 4f, Graphics.Color.White);
        Print.Draw($@"{Math.Round(FrameTime * 1000, 2)}  ms", IkuFont.FiraCodeMedium ,new UnitPoint(0.90f, -0.90f), TextAlign.right, TextAlign.top, 22f, 4f, Graphics.Color.White);
    }
}