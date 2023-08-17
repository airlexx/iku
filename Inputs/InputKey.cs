using System;
using Raylib_cs;
using Color = iku.Game.Graphics.Color;

namespace iku.Game.Inputs;

public class InputKey
{
    private static int codeKeyPressed = 0;

    public static void Test()
    {
        int a = Raylib.GetKeyPressed();

        if (a != 0)
        {
            codeKeyPressed = a;
        }

        Raylib.DrawText("Key Pressed: " + codeKeyPressed, 10, 10, 20, Color.Red);
    }
}
