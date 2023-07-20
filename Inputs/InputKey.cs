using System;
using System.Drawing;
using Raylib_cs;
using iku.Game.Graphics.Coordinates;
using iku.Game.Graphics;
using Color = iku.Game.Graphics.Color;

namespace iku.Game.Inputs;

public class InputKey
{
    private static int CodeKeyPressed = 0;

    public static void Test()
    {
        int a = Raylib.GetKeyPressed();

        if (a != 0)
        {
            CodeKeyPressed = a;
        }

        Raylib.DrawText("Key Pressed: " + CodeKeyPressed, 10, 10, 20, Color.Red);
    }
}