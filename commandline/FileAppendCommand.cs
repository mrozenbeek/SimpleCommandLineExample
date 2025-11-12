using System.CommandLine;

namespace commandline
{
    internal class FileAppendCommand: Command
    {

        public FileAppendCommand(ReadOnlySpan<Option> options): base("append", "Appends text to a file")
        {
            foreach (var option in options)
            {
                Add(option);
            }
            Add(new Option<string>("--text-to-append")
            {
                Description = "The text to append to the file.",
                Required = true,
                CustomParser = result => 
                {
                    if (string.IsNullOrWhiteSpace(result.Tokens.First().Value))
                    {
                        result.AddError("The --text-to-append option requires a non-empty value.");
                        return string.Empty;
                    }

                    return result.Tokens.First().Value;
                }
            });

            SetAction(parseResult => FileMethods.ReadFileAndAppend(
                parseResult.GetValue<FileInfo>("--file-path"),
                parseResult.GetValue<int>("--delay"),
                parseResult.GetValue<ConsoleColor>("--fgcolor"),
                parseResult.GetValue<bool>("--light-mode"),
                parseResult.GetValue<string>("--text-to-append")));
        }
    }
}
