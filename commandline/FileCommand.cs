using System.Collections.ObjectModel;
using System.CommandLine;

namespace commandline
{
    internal class FileCommand : Command
    {
        private static readonly Option[] _options = [
                    new Option<FileInfo>("--file-path")
            {
                Description = "The file to read and display on the console."
            },
            new Option<int>("--delay")
            {
                Description = "Delay between lines, specified as milliseconds per character in a line.",
                DefaultValueFactory = parseResult => 42
            },
            new Option<ConsoleColor>("--fgcolor")
            {
                Description = "Foreground color of text displayed on the console.",
                DefaultValueFactory = parseResult => ConsoleColor.White
            },
            new Option<bool>("--light-mode")
            {
                Description = "Background color of text displayed on the console: default is black, light mode is white."
            }
               ];
        public FileCommand() : base("file", "Reads file contents")
        {

            foreach (var option in _options)
            {
                Add(option);
            }

            SetAction(parseResult => FileMethods.ReadFile(
                parseResult.GetValue<FileInfo>("--file-path"),
                parseResult.GetValue<int>("--delay"),
                parseResult.GetValue<ConsoleColor>("--fgcolor"),
                parseResult.GetValue<bool>("--light-mode"), null));

            Add(new FileAppendCommand(_options));
        }
    }
}
