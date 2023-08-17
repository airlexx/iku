using System;
using iku.Game.Graphics;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Overlays;

public static class GamePerformance
{
    private static int frameRate;
    private static float frameTime;
    private static double elapsedTime;
    private static readonly float refreshTime = 0.5f;

    public static void Show()
    {
        float deltaTime = Window.FrameTime;
        elapsedTime += deltaTime;

        if (elapsedTime >= refreshTime)
        {
            frameRate = Window.FrameRate;
            frameTime = Window.FrameTime;

            elapsedTime = 0;
        }

        Print.Draw($@"{frameRate} fps", IkuFont.FiraCodeMedium, new UnitPoint(0.90f, -0.80f), TextAlign.right, TextAlign.top, 22f, 4f, Color.White);
        Print.Draw($@"{Math.Round(frameTime * 1000, 2)}  ms", IkuFont.FiraCodeMedium, new UnitPoint(0.90f, -0.90f), TextAlign.right, TextAlign.top, 22f, 4f, Color.White);
    }
}
