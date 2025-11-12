namespace Samples.CommandLine;

internal static class FileMethods
{
    internal static void ReadFile(FileInfo file, int delay, ConsoleColor fgColor, bool lightMode, string? appendedText)
    {
        Console.BackgroundColor = lightMode ? ConsoleColor.White : ConsoleColor.Black;
        Console.ForegroundColor = fgColor;
        foreach (string line in File.ReadLines(file.FullName))
        {
            Console.WriteLine(line);
            Thread.Sleep(TimeSpan.FromMilliseconds(delay * line.Length));
        }

        if (!string.IsNullOrWhiteSpace(appendedText))
        {
            Console.WriteLine(appendedText);
        }

        Console.ResetColor();
    }

    internal static void ReadFileAndAppend(FileInfo file, int delay, ConsoleColor fgColor, bool lightMode, string appendedText)
    {
        ReadFile(file, delay, fgColor, lightMode, appendedText);
    }
}
