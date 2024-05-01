using NBP.Configuration;
using NBP.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NBP.Commands;

public class InitCommand: AsyncCommand<InitSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, InitSettings settings)
    {
        AnsiConsole.MarkupLine("[bold]Initializing Solution[/]");

        SolutionConfiguration config = ConfigurationService.ConfigurationPrompt();
        AnsiConsole.MarkupLine(Constants.CliSeparator);
        AnsiConsole.MarkupLine("[bold]Solution Configuration[/]");
        AnsiConsole.MarkupLine($"[bold]{config}[/]");
        AnsiConsole.MarkupLine(Constants.CliSeparator);
        
        AnsiConsole.MarkupLine("[green]Done[/]");

        return 0;
    }
}

public sealed class InitSettings : CommandSettings
{
}