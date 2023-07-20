using System;
using System.Numerics;
using System.Text.RegularExpressions;
using Raylib_cs;
using iku.Game.Utils;
using iku.Game.Gamemaps.Points;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps;

public static class MapLoader
{
    private const string MapsDir = "Maps";
    private const string LevelName = "game";
    private const float RenderDistance = 100;
    private const float HitPointSize = 8;
    
    private static HitPoint[] HitPoints = new HitPoint[0];

    public static void Load()
    {
        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MapsDir);
        string path = Path.Combine(dir, LevelName + ".iku");

        string data = File.ReadAllText(path);

        Regex rx = new Regex(@"#\sHitPoints\r?\n((-?\d+\.\d+,-?\d+\.\d+,\d+\.\d+,\d+\r?\n?)+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Match match = rx.Match(data);

        if (match.Success)
        {
            string hitPointsData = match.Groups[1].Value;
            string[] lines = hitPointsData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int rowCount = lines.Length;
            int colCount = lines[0].Split(',').Length;

            string[,] elements = new string[rowCount, colCount];
            
            HitPoints = new HitPoint[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] lineElements = lines[i].Split(',');

                ScreenPoint postion = PointConvertion.MapToScreen(new MapPoint(float.Parse(lineElements[0]), float.Parse(lineElements[1])));

                float time = float.Parse(lineElements[2]);
                byte action = byte.Parse(lineElements[3]);
                
                for (int j = 0; j < colCount; j++)
                    elements[i, j] = lineElements[j];

                MapPoint position = new MapPoint(postion.X, postion.Y);
                HitPoint hitPoint = new HitPoint(position, time, action);

                HitPoints[i] = hitPoint;
            }       
        }
        else
        {
            Logger.Error("HitPoints is empty");
        }
    }

    public static void Draw()
    {
        foreach (var HitPoint in HitPoints)
        {
            MapPoint point = PointConvertion.ScreenToMap(new ScreenPoint((int)HitPoint.Position.X, (int)HitPoint.Position.Y));
            
            float cameraX1 = GameCamera.Position.X - RenderDistance;
            float cameraX2 = GameCamera.Position.X + RenderDistance;

            float cameraY1 = GameCamera.Position.Y - RenderDistance;
            float cameraY2 = GameCamera.Position.Y + RenderDistance;

            if (point.X >= cameraX1 && point.X <= cameraX2 && point.Y >= cameraY1 && point.Y <= cameraY2)
                Raylib.DrawCircleV(new Vector2(HitPoint.Position.X, HitPoint.Position.Y), HitPointSize, Graphics.Color.White);
        }
    }
}
