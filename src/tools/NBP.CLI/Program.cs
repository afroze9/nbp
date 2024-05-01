using NBP.Commands;
using Spectre.Console;
using Spectre.Console.Cli;

AnsiConsole.Write(new FigletText("Nexus Boilerplate").LeftJustified().Color(Color.Green));

CommandApp app = new();
app.Configure(config =>
{
    config.AddCommand<InitCommand>("init")
        .WithDescription("Create a new nexus solution");
    
    config.AddBranch<AddSettings>("add", options =>
    {
        options.SetDescription("Add a new component");
        options.AddCommand<AddServiceCommand>("service")
            .WithDescription("Add a new service");
    });
});
app.Run(args);