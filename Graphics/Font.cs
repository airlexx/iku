using System;
using Raylib_cs;

namespace iku.Game.Graphics;

public class Font
{
    public static Raylib_cs.Font fontChillaxMedium = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Bold.ttf", 96, null, 0);

    public static Raylib_cs.Font fontChillaxLight = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Light.ttf", 96, null, 0);

    public static Raylib_cs.Font fontFiraCodeMedium = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-Medium.ttf", 96, null, 0);
}
