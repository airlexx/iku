using System;

namespace iku.Game.Utils;

public static class Logger
{
    private const string dirName = "Logs";
    private const string fileName = "runtime";

    private static void Log(LogLevel level, string message)
    {
        string date = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzzz");

        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirName);
        string path = Path.Combine(dir, fileName + ".log");

        Console.ForegroundColor = level switch
        {
            LogLevel.TRACE => ConsoleColor.DarkGreen,
            LogLevel.DEBUG => ConsoleColor.Green,
            LogLevel.INFO => ConsoleColor.Blue,
            LogLevel.WARN => ConsoleColor.DarkYellow,
            LogLevel.ERROR => ConsoleColor.Red,
            LogLevel.FATAL => ConsoleColor.DarkRed,
            _ => ConsoleColor.Gray,
        };

        Console.Write($"{level}: ");
        Console.ResetColor();
        Console.WriteLine(message);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        using StreamWriter writer = File.AppendText(path);
        writer.WriteLine($"{date} {level}: {message}");
    }

    public static void Trace(string message) => Log(LogLevel.TRACE, message);

    public static void Debug(string message) => Log(LogLevel.DEBUG, message);

    public static void Info(string message) => Log(LogLevel.INFO, message);

    public static void Warn(string message) => Log(LogLevel.WARN, message);

    public static void Error(string message) => Log(LogLevel.ERROR, message);

    public static void Fatal(string message) => Log(LogLevel.FATAL, message);
}
