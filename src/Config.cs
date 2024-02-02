namespace Microagents;

/// <summary>
/// Configuration for the demo based on environment:
///     OPENAI_KEY - The OpenAI API key
///     OPENAI_MODEL - The target transformer model (defaults to gpt-4-1106-preview)
///     RESULT_PATH - The output path for writing results (defaults to ./results)
/// 
/// Only OPENAI_KEY is required.
/// </summary>
internal static class Config
{
    /// <summary>
    /// Required OpenAI API key.
    /// </summary>
    public static string ApiKey =>
        Environment.GetEnvironmentVariable("OPENAI_KEY") ??
        throw new InvalidOperationException("Environment variable 'OPENAI_KEY' undefined.");

    /// <summary>
    /// The model name (defaults to gpt-4-1106-preview).
    /// </summary>
    public static string ModelName =>
        Environment.GetEnvironmentVariable("OPENAI_MODEL") ??
        Models.Gpt4Turbo;

    /// <summary>
    /// The output path for writing results (defaults to ./results).
    /// </summary>
    public static string ResultPath =>
        Environment.GetEnvironmentVariable("RESULT_PATH") ??
        "./results";
}
