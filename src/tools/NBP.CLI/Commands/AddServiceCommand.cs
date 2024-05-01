using Spectre.Console;
using Spectre.Console.Cli;

namespace NBP.Commands;

public class AddServiceCommand : AsyncCommand<AddServiceSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, AddServiceSettings settings)
    {
        AnsiConsole.MarkupLine($"[bold]Adding Service [green]{settings.Name}[/][/]");
        AnsiConsole.MarkupLine("[green]Done[/]");
        return 0;
    }
}

public class AddSettings : CommandSettings
{
}

public class AddServiceSettings : AddSettings
{
    [CommandArgument(0, "<name>")] 
    public string Name { get; init; } = string.Empty;
}
