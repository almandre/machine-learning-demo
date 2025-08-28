using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MachineLearningDemo;

public static class ScoreService
{
    public static async Task<HttpResponseMessage> PostData(AppSettings appSettings, string body)
    {
        string? endpoint = appSettings.EndpointUrl;
        string? apiKey = appSettings.ApiKey;

        if (string.IsNullOrWhiteSpace(endpoint))
        {
            Console.Error.WriteLine("EndpointUrl missing in appsettings.json.");

            throw new InvalidOperationException("EndpointUrl missing in appsettings.json.");
        }

        using var client = new HttpClient();

        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        using var content = new StringContent(body, Encoding.UTF8, "application/json");

        try
        {
            return await client.PostAsync(endpoint, content);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Request error: {ex.Message}");
        }
    }
}
