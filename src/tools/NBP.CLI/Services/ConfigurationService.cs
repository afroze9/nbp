using NBP.Configuration;
using Spectre.Console;

namespace NBP.Services;

public class ConfigurationService
{
    public static SolutionConfiguration ConfigurationPrompt()
    {
        TextPrompt<string> solutionPrompt = new TextPrompt<string>("Solution Name")
            .AllowEmpty()
            .DefaultValue("my-solution");

        SelectionPrompt<string> deploymentPrompt = new SelectionPrompt<string>()
            .Title("Where will the solution be deployed?")
            .AddChoices(new[]
            {
                "On-Prem",
                "Azure (Native)",
                "Azure (K8s)",
                "AWS"
            });

        MultiSelectionPrompt<string> featurePrompt = new MultiSelectionPrompt<string>()
            .Title("Select Features")
            .InstructionsText(
                "[grey](Press [blue]<space>[/] to toggle a feature, " +
                "[green]<enter>[/] to accept)[/]")
            .AddChoices(new[]
            {
                "Auth",
                "Logging",
                "Monitoring",
                "Tracing",
                "Persistence",
            });

        string solutionName = AnsiConsole.Prompt(solutionPrompt);
        string deployment = AnsiConsole.Prompt(deploymentPrompt);
        List<string> features = AnsiConsole.Prompt(featurePrompt);
        bool initializeGit = AnsiConsole.Confirm("Initialize Git repository?");

        SolutionConfiguration configuration = new()
        {
            SolutionName = solutionName,
            Deployment = deployment,
            Features = features,
            InitializeGit = initializeGit
        };

        return configuration;
    }
}