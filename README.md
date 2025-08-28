# Machine Learning Demo (.NET)

Minimal console app that calls an HTTP scoring endpoint (e.g., Azure ML Online Endpoint).

This app is configured only via `appsettings.json`.

## Configuration

Edit `appsettings.json`:

```
{
	"EndpointUrl": "https://<your-endpoint>/score",
	"ApiKey": "<your-key-if-required>",
	"FileName": "sample-request.json"
}
```

Notes:
- `appsettings.json` and `sample-request.json` are copied to the output folder on build.

## Run (Windows PowerShell)

```
dotnet run --
```

On success, the response body is printed to stdout. On failure (e.g., missing or non-existent `FileName`), details are printed to stderr and the process exits with a non‑zero code.

## Files

- `Program.cs` — entry point; reads config, builds request, posts JSON, prints result.
- `Configuration.cs` — loads strongly typed settings from `appsettings.json`.
- `sample-request.json` — sample payload stub.

Tested with .NET 9.0.

## Reference

- This demo is based on: <https://microsoftlearning.github.io/mslearn-ai-fundamentals/Instructions/Exercises/01-machine-learning.html>