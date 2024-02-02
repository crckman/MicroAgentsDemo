namespace Microsoft.Microagents.Tools;

using System.Text.Json;

public partial class Translator : DiagnosticPlugin
{
    private string TranslateFailure(string methodName, string phrase)
    {
        return
            CaptureCall(
                methodName,
                JsonSerializer.Serialize("(service failure - unable to translate)"),
                new()
                {
                    { nameof(phrase), phrase },
                });
    }
}
