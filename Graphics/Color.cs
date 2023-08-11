using System;

namespace iku.Game.Graphics;

public readonly struct Color
{
    public static readonly Raylib_cs.Color White = new(255, 255, 255, 255);
    public static readonly Raylib_cs.Color Gray = new(42, 52, 57, 255);
    public static readonly Raylib_cs.Color Black = new(0, 0, 0, 255);
    public static readonly Raylib_cs.Color Red = new(231, 33, 72, 255);
    public static readonly Raylib_cs.Color Red25 = new(231, 33, 72, 64);
    public static readonly Raylib_cs.Color SpringGreen = new(0, 250, 154, 255);
    public static readonly Raylib_cs.Color SpringGreen25 = new(0, 250, 154, 64);
    public static readonly Raylib_cs.Color SteelPink = new(204, 60, 192, 255);
    public static readonly Raylib_cs.Color SteelPink25 = new(204, 60, 192, 64);
    public static readonly Raylib_cs.Color EerieBlack = new(27, 27, 27, 255);
    public static readonly Raylib_cs.Color JetBlack = new(14, 14, 16, 255);
    public static readonly Raylib_cs.Color CyberYellow = new(255, 211, 0, 255);
}