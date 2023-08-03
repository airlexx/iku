using System;
using System.Text.RegularExpressions;
using iku.Game.Utils;
using iku.Game.Gamemaps.Points;
using iku.Game.Gamemaps.Players;
using iku.Game.Graphics.Coordinates;

namespace iku.Game.Gamemaps;

public static partial class MapLoader
{
    private const string mapsDir = @"Maps";
    private const string mapName = @"game";
    private const string mapExt = @".iku";

    private static float speedMap;

    private static HitPointFile[] hitPointsFile = Array.Empty<HitPointFile>();
    private static HitPoint[] hitPoints = Array.Empty<HitPoint>();

    private static MapPoint currentHitPoint;
    private static PlayerDirection direction;
    private static double currentHitTime;

    [GeneratedRegex("#\\sHitPoints\\r?\\n((\\d+\\.\\d+,\\d+\\r?\\n?)+)", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex hitPointRegex();

    public static HitPointFile[] HitPointsFile { get => hitPointsFile; }
    public static HitPoint[] HitPoints { get => hitPoints; }

    public static void Init()
    {
        speedMap = 10f;
        currentHitPoint = new MapPoint(0f, 0f);
        direction = PlayerDirection.Right;
        currentHitTime = 0;
    }

    public static string GetString()
    {
        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mapsDir);
        string path = Path.Combine(dir, mapName + mapExt);

        return File.ReadAllText(path);
    }

    public static void LoadHitPointsFile()
    {
        Regex regex = hitPointRegex();
        Match match = regex.Match(GetString());

        if (match.Success)
        {
            string hitPointsFileData = match.Groups[1].Value;
            string[] lines = hitPointsFileData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            hitPointsFile = new HitPointFile[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineElements = lines[i].Split(',');

                uint id = (uint)i;
                double time = double.Parse(lineElements[0]);
                byte action = byte.Parse(lineElements[1]);

                hitPointsFile[i] = new HitPointFile(id, time, action);
            }
        }
        else
            Logger.Error("HitPointsFile is not valid");
        Logger.Info(@"Hit points file loaded");
    }

    public static void LoadHitPoints()
    {
        HitPointFile[] hitPointsFiles = hitPointsFile;
        hitPoints = new HitPoint[hitPointsFiles.Length];

        for (int i = 0; i < hitPointsFiles.Length; i++)
        {
            hitPoints[i].ID = hitPointsFiles[i].ID;
            hitPoints[i].Action = hitPointsFiles[i].Action;
            hitPoints[i].Time = hitPointsFiles[i].Time;

            double deltaTime = hitPoints[i].Time - currentHitTime;
            MapPoint postion = PointConvertion.TimeToMap(currentHitPoint, deltaTime, direction, speedMap);
            hitPoints[i].Position = postion;

            direction = (PlayerDirection)hitPoints[i].Action;
            currentHitPoint = postion;
            currentHitTime = hitPoints[i].Time;
        }
    }
}
