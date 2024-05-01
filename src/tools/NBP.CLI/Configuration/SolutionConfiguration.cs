using System.Text;

namespace NBP.Configuration;

public class SolutionConfiguration
{
    public string SolutionName { get; set; }
    public List<string> Features { get; set; }
    public string Deployment { get; set; }
    public bool InitializeGit { get; set; }
    

    public override string ToString()
    {
        StringBuilder sb = new();
        
        sb.AppendLine($"Solution Name: {SolutionName}");
        sb.AppendLine($"Deployment: {Deployment}");
        sb.AppendLine("Features:");
        foreach (string feature in Features)
        {
            sb.AppendLine($"- {feature}");
        }
        sb.AppendLine($"Initialize Git: {InitializeGit}");
        
        return sb.ToString();
    }
}