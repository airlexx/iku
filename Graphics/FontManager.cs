using System;
using Raylib_cs;

namespace iku.Game.Graphics;

public static class FontManager
{
    private static Raylib_cs.Font fontChillaxLight;
    private static Raylib_cs.Font fontChillaxMedium;
    private static Raylib_cs.Font fontChillaxRegular;
    private static Raylib_cs.Font fontChillaxSemiBold;
    private static Raylib_cs.Font fontChillaxBold;

    private static Raylib_cs.Font fontFiraCodeLight;
    private static Raylib_cs.Font fontFiraCodeMedium;
    private static Raylib_cs.Font fontFiraCodeRegular;
    private static Raylib_cs.Font fontFiraCodeSemiBold;
    private static Raylib_cs.Font fontFiraCodeBold;

    public static void LoadFonts()
    {
        fontChillaxLight = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Light.ttf", 512, null, 0);
        fontChillaxMedium = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Medium.ttf", 512, null, 0);
        fontChillaxRegular = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Regular.ttf", 512, null, 0);
        fontChillaxSemiBold = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-SemiBold.ttf", 512, null, 0);
        fontChillaxBold = Raylib.LoadFontEx("Resources/Fonts/Chillax/Chillax-Bold.ttf", 512, null, 0);

        fontFiraCodeLight = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-Light.ttf", 512, null, 0);
        fontFiraCodeMedium = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-Medium.ttf", 512, null, 0);
        fontFiraCodeRegular = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-Regular.ttf", 512, null, 0);
        fontFiraCodeSemiBold = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-SemiBold.ttf", 512, null, 0);
        fontFiraCodeBold = Raylib.LoadFontEx("Resources/Fonts/FiraCode/FiraCode-Bold.ttf", 512, null, 0);
    }

    public static void UnloadFonts()
    {
        Raylib.UnloadFont(fontChillaxLight);
        Raylib.UnloadFont(fontChillaxMedium);
        Raylib.UnloadFont(fontChillaxRegular);
        Raylib.UnloadFont(fontChillaxSemiBold);
        Raylib.UnloadFont(fontChillaxBold);

        Raylib.UnloadFont(fontFiraCodeLight);
        Raylib.UnloadFont(fontFiraCodeMedium);
        Raylib.UnloadFont(fontFiraCodeRegular);
        Raylib.UnloadFont(fontFiraCodeSemiBold);
        Raylib.UnloadFont(fontFiraCodeBold);
    }

    public static Raylib_cs.Font GetFont(IkuFont fontType)
    {
        switch (fontType)
        {
            case IkuFont.ChillaxLight:
                return fontChillaxLight;

            case IkuFont.ChillaxMedium:
                return fontChillaxMedium;

            case IkuFont.ChillaxRegular:
                return fontChillaxRegular;

            case IkuFont.ChillaxSemiBold:
                return fontChillaxSemiBold;

            case IkuFont.ChillaxBold:
                return fontChillaxBold;

            case IkuFont.FiraCodeLight:
                return fontFiraCodeLight;

            case IkuFont.FiraCodeMedium:
                return fontFiraCodeMedium;

            case IkuFont.FiraCodeRegular:
                return fontFiraCodeRegular;

            case IkuFont.FiraCodeSemiBold:
                return fontFiraCodeSemiBold;

            case IkuFont.FiraCodeBold:
                return fontFiraCodeBold;

            default:
                return fontChillaxMedium;
        }
    }
}
