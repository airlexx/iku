using System;
using Raylib_cs;

namespace iku.Game.Graphics;

public static class FontManager
{
    private static Font fontChillaxLight;
    private static Font fontChillaxMedium;
    private static Font fontChillaxRegular;
    private static Font fontChillaxSemiBold;
    private static Font fontChillaxBold;

    private static Font fontFiraCodeLight;
    private static Font fontFiraCodeMedium;
    private static Font fontFiraCodeRegular;
    private static Font fontFiraCodeSemiBold;
    private static Font fontFiraCodeBold;

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

    public static Font GetFont(IkuFont fontType)
    {
        return fontType switch
        {
            IkuFont.ChillaxLight => fontChillaxLight,
            IkuFont.ChillaxMedium => fontChillaxMedium,
            IkuFont.ChillaxRegular => fontChillaxRegular,
            IkuFont.ChillaxSemiBold => fontChillaxSemiBold,
            IkuFont.ChillaxBold => fontChillaxBold,
            IkuFont.FiraCodeLight => fontFiraCodeLight,
            IkuFont.FiraCodeMedium => fontFiraCodeMedium,
            IkuFont.FiraCodeRegular => fontFiraCodeRegular,
            IkuFont.FiraCodeSemiBold => fontFiraCodeSemiBold,
            IkuFont.FiraCodeBold => fontFiraCodeBold,
            _ => fontChillaxMedium,
        };
    }
}
