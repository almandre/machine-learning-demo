using MachineLearningDemo;

var configuration = Configuration.Load();
var requestBody = await ReadFile(configuration.FileName);

HttpResponseMessage response = await ScoreService.PostData(configuration, requestBody);

if (!response.IsSuccessStatusCode)
{
    Console.Error.WriteLine($"Request failed: {(int)response.StatusCode} {response.ReasonPhrase}");
    string responseContent = await response.Content.ReadAsStringAsync();
    Console.Error.WriteLine(responseContent);
}

string result = await response.Content.ReadAsStringAsync();

Console.WriteLine(result);

async Task<string> ReadFile(string? filename)
{
    if (!string.IsNullOrWhiteSpace(filename))
    {
        if (!File.Exists(filename))
        {
            throw new InvalidOperationException($"Request file not found: '{filename}'.");
        }

        return await File.ReadAllTextAsync(filename);
    }

    throw new InvalidOperationException("Filename is missing.");
}
