using Microsoft.Extensions.Configuration;
namespace MachineLearningDemo;

public class AppSettings
{
    public string? EndpointUrl { get; set; }
    public string? ApiKey { get; set; }
    public string? FileName { get; set; }
    public string? RequestBody { get; set; }
}

public static class Configuration
{
    public static AppSettings Load()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        return configuration.Get<AppSettings>() ?? new AppSettings();
    }
}
