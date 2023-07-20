using System;

namespace iku.Game.Graphics;

public struct Color
{
    public static Raylib_cs.Color White = new Raylib_cs.Color(255, 255, 255, 255);
    public static Raylib_cs.Color Gray = new Raylib_cs.Color(42, 52, 57, 255); // to rename
    public static Raylib_cs.Color Black = new Raylib_cs.Color(0, 0, 0, 255);
    public static Raylib_cs.Color Red = new Raylib_cs.Color(231, 33, 72, 255);
    public static Raylib_cs.Color Green = new Raylib_cs.Color(255, 255, 255, 255); // to fix
    public static Raylib_cs.Color Blue = new Raylib_cs.Color(255, 255, 255, 255); // to fix
    public static Raylib_cs.Color SpringGreen = new Raylib_cs.Color(0, 250, 154, 255);
}