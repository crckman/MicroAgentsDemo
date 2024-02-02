namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;

public partial class AnimalSounds : DiagnosticPlugin
{

    [KernelFunction]
    [Description("Get the animal sound made by a Rusa.")]
    public string GetRusaSound()
    {
        return GetAnimalSound(nameof(GetRusaSound), "Rusa", "bark");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Rusty-Spotted Cat.")]
    public string GetRustySpottedCatSound()
    {
        return GetAnimalSound(nameof(GetRustySpottedCatSound), "Rusty-Spotted Cat", "purr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sable.")]
    public string GetSableSound()
    {
        return GetAnimalSound(nameof(GetSableSound), "Sable", "chirp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Saiga.")]
    public string GetSaigaSound()
    {
        return GetAnimalSound(nameof(GetSaigaSound), "Saiga", "grunt");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sambar.")]
    public string GetSambarSound()
    {
        return GetAnimalSound(nameof(GetSambarSound), "Sambar", "bark");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sand Cat.")]
    public string GetSandCatSound()
    {
        return GetAnimalSound(nameof(GetSandCatSound), "Sand Cat", "purr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Seal.")]
    public string GetSealSound()
    {
        return GetAnimalSound(nameof(GetSealSound), "Seal", "bark");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Serow.")]
    public string GetSerowSound()
    {
        return GetAnimalSound(nameof(GetSerowSound), "Serow", "bleat");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Serval.")]
    public string GetServalSound()
    {
        return GetAnimalSound(nameof(GetServalSound), "Serval", "purr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sheep.")]
    public string GetSheepSound()
    {
        return GetAnimalSound(nameof(GetSheepSound), "Sheep", "baa");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Short-Eared Dog.")]
    public string GetShortEaredDogSound()
    {
        return GetAnimalSound(nameof(GetShortEaredDogSound), "Short-Eared Dog", "yelp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sika Deer.")]
    public string GetSikaDeerSound()
    {
        return GetAnimalSound(nameof(GetSikaDeerSound), "Sika Deer", "squeak");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sitatunga.")]
    public string GetSitatungaSound()
    {
        return GetAnimalSound(nameof(GetSitatungaSound), "Sitatunga", "bark");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Skunk.")]
    public string GetSkunkSound()
    {
        return GetAnimalSound(nameof(GetSkunkSound), "Skunk", "hiss");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Snake.")]
    public string GetSnakeSound()
    {
        return GetAnimalSound(nameof(GetSnakeSound), "Snake", "hiss");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Snow Leopard.")]
    public string GetSnowLeopardSound()
    {
        return GetAnimalSound(nameof(GetSnowLeopardSound), "Snow Leopard", "purr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Springbok.")]
    public string GetSpringbokSound()
    {
        return GetAnimalSound(nameof(GetSpringbokSound), "Springbok", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Squirrel.")]
    public string GetSquirrelSound()
    {
        return GetAnimalSound(nameof(GetSquirrelSound), "Squirrel", "chatter");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Stoat.")]
    public string GetStoatSound()
    {
        return GetAnimalSound(nameof(GetStoatSound), "Stoat", "squeak");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Swift Fox.")]
    public string GetSwiftFoxSound()
    {
        return GetAnimalSound(nameof(GetSwiftFoxSound), "Swift Fox", "yelp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tahr.")]
    public string GetTahrSound()
    {
        return GetAnimalSound(nameof(GetTahrSound), "Tahr", "bleat");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tapir.")]
    public string GetTapirSound()
    {
        return GetAnimalSound(nameof(GetTapirSound), "Tapir", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tibetan Fox.")]
    public string GetTibetanFoxSound()
    {
        return GetAnimalSound(nameof(GetTibetanFoxSound), "Tibetan Fox", "yelp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tiger.")]
    public string GetTigerSound()
    {
        return GetAnimalSound(nameof(GetTigerSound), "Tiger", "grrr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tigon.")]
    public string GetTigonSound()
    {
        return GetAnimalSound(nameof(GetTigonSound), "Tigon", "roar");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Turkey.")]
    public string GetTurkeySound()
    {
        return GetAnimalSound(nameof(GetTurkeySound), "Turkey", "gobble");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Unicorn.")]
    public string GetUnicornSound()
    {
        return GetAnimalSound(nameof(GetUnicornSound), "Unicorn", "neigh");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Urial.")]
    public string GetUrialSound()
    {
        return GetAnimalSound(nameof(GetUrialSound), "Urial", "bleat");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Vicuna.")]
    public string GetVicunaSound()
    {
        return GetAnimalSound(nameof(GetVicunaSound), "Vicuna", "hum");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Walrus.")]
    public string GetWalrusSound()
    {
        return GetAnimalSound(nameof(GetWalrusSound), "Walrus", "grunt");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Warthog.")]
    public string GetWarthogSound()
    {
        return GetAnimalSound(nameof(GetWarthogSound), "Warthog", "grunt");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Water Deer.")]
    public string GetWaterDeerSound()
    {
        return GetAnimalSound(nameof(GetWaterDeerSound), "Water Deer", "whistle");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Waterbuck.")]
    public string GetWaterbuckSound()
    {
        return GetAnimalSound(nameof(GetWaterbuckSound), "Waterbuck", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Weasel.")]
    public string GetWeaselSound()
    {
        return GetAnimalSound(nameof(GetWeaselSound), "Weasel", "squeak");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Whale.")]
    public string GetWhaleSound()
    {
        return GetAnimalSound(nameof(GetWhaleSound), "Whale", "sing");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a White-Tailed Deer.")]
    public string GetWhiteTailedDeerSound()
    {
        return GetAnimalSound(nameof(GetWhiteTailedDeerSound), "White-Tailed Deer", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Wildcat.")]
    public string GetWildcatSound()
    {
        return GetAnimalSound(nameof(GetWildcatSound), "Wildcat", "purr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Wildebeest.")]
    public string GetWildebeestSound()
    {
        return GetAnimalSound(nameof(GetWildebeestSound), "Wildebeest", "gru-gru");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Wolf.")]
    public string GetWolfSound()
    {
        return GetAnimalSound(nameof(GetWolfSound), "Wolf", "howl");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Wolverine.")]
    public string GetWolverineSound()
    {
        return GetAnimalSound(nameof(GetWolverineSound), "Wolverine", "growl");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Zebra.")]
    public string GetZebraSound()
    {
        return GetAnimalSound(nameof(GetZebraSound), "Zebra", "bray");
    }

}