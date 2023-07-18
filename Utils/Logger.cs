using System;

namespace iku.Game.Utils;

public static class Logger
{
    private const string DirName = "Logs";
    private const string FileName = "runtime";

    private static void Log(LogLevel level, string message)
    {
        string date = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzzz");

        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirName);
        string path = Path.Combine(dir, FileName + ".log");

        switch (level)
        {
            case LogLevel.TRACE:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            break;

            case LogLevel.DEBUG:
                Console.ForegroundColor = ConsoleColor.Green;
            break;

            case LogLevel.INFO:
                Console.ForegroundColor = ConsoleColor.Blue;
            break;

            case LogLevel.WARN:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;

            case LogLevel.ERROR:
                Console.ForegroundColor = ConsoleColor.Red;
            break;

            case LogLevel.FATAL:
                Console.ForegroundColor = ConsoleColor.DarkRed;
            break;

            default:
                Console.ForegroundColor = ConsoleColor.Gray;
            break;
        }

        Console.Write($"{level}: ");
        Console.ResetColor();
        Console.WriteLine(message);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        using (StreamWriter writer = File.AppendText(path))
            writer.WriteLine($"{date} {level}: {message}");
    }

    public static void Trace(string message) => Log(LogLevel.TRACE, message);

    public static void Debug(string message) => Log(LogLevel.DEBUG, message);

    public static void Info(string message) => Log(LogLevel.INFO, message);

    public static void Warn(string message) => Log(LogLevel.WARN, message);

    public static void Error(string message) => Log(LogLevel.ERROR, message);

    public static void Fatal(string message) => Log(LogLevel.FATAL, message);
}
