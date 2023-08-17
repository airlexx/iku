using System;

namespace iku.Game.Overlays;

public static class Debug
{
    public static void Show()
    {
        PlayerCoodinate.Show();
        GamePerformance.Show();
        MapDebug.Show();
    }
}
