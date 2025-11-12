// See https://aka.ms/new-console-template for more information
using commandline;
using System.CommandLine;

RootCommand rootCommand = new("Sample app for System.CommandLine");
rootCommand.Subcommands.Add(new FileCommand());


ParseResult parseResult = rootCommand.Parse(args);
return parseResult.Invoke();
