namespace Microsoft.Microagents.Tools;

using System.Text.Json;

public partial class AnimalSounds : DiagnosticPlugin
{
    private string GetAnimalSound(string methodName, string animal, string sound)
    {
        return
            CaptureCall(
                methodName,
                JsonSerializer.Serialize(sound),
                new()
                {
                    { nameof(animal), animal },
                });
    }
}
