namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;

public partial class AnimalSounds : DiagnosticPlugin
{

    [KernelFunction]
    [Description("Get the animal sound made by a Antelope.")]
    public string GetAntelopeSound()
    {
        return GetAnimalSound(nameof(GetAntelopeSound), "Antelope", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Bat.")]
    public string GetBatSound()
    {
        return GetAnimalSound(nameof(GetBatSound), "Bat", "screech");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Bear.")]
    public string GetBearSound()
    {
        return GetAnimalSound(nameof(GetBearSound), "Bear", "growl");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Beaver.")]
    public string GetBeaverSound()
    {
        return GetAnimalSound(nameof(GetBeaverSound), "Beaver", "gnaw");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Bee.")]
    public string GetBeeSound()
    {
        return GetAnimalSound(nameof(GetBeeSound), "Bee", "buzz");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Bird.")]
    public string GetBirdSound()
    {
        return GetAnimalSound(nameof(GetBirdSound), "Bird", "chirp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Boar.")]
    public string GetBoarSound()
    {
        return GetAnimalSound(nameof(GetBoarSound), "Boar", "grunt");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Cat.")]
    public string GetCatSound()
    {
        return GetAnimalSound(nameof(GetCatSound), "Cat", "meow");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Chicken.")]
    public string GetChickenSound()
    {
        return GetAnimalSound(nameof(GetChickenSound), "Chicken", "cluck");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Cow.")]
    public string GetCowSound()
    {
        return GetAnimalSound(nameof(GetCowSound), "Cow", "mooo");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Cricket.")]
    public string GetCricketSound()
    {
        return GetAnimalSound(nameof(GetCricketSound), "Cricket", "chirp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Crocodile.")]
    public string GetCrocodileSound()
    {
        return GetAnimalSound(nameof(GetCrocodileSound), "Crocodile", "snap");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Deer.")]
    public string GetDeerSound()
    {
        return GetAnimalSound(nameof(GetDeerSound), "Deer", "snort");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Dog.")]
    public string GetDogSound()
    {
        return GetAnimalSound(nameof(GetDogSound), "Dog", "woof");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Donkey.")]
    public string GetDonkeySound()
    {
        return GetAnimalSound(nameof(GetDonkeySound), "Donkey", "hee-haw");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Duck.")]
    public string GetDuckSound()
    {
        return GetAnimalSound(nameof(GetDuckSound), "Duck", "quack");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Eagle.")]
    public string GetEagleSound()
    {
        return GetAnimalSound(nameof(GetEagleSound), "Eagle", "screech");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Elephant.")]
    public string GetElephantSound()
    {
        return GetAnimalSound(nameof(GetElephantSound), "Elephant", "trumpet");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Fox.")]
    public string GetFoxSound()
    {
        return GetAnimalSound(nameof(GetFoxSound), "Fox", "yelp");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Frog.")]
    public string GetFrogSound()
    {
        return GetAnimalSound(nameof(GetFrogSound), "Frog", "ribbit");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Goat.")]
    public string GetGoatSound()
    {
        return GetAnimalSound(nameof(GetGoatSound), "Goat", "bleat");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Horse.")]
    public string GetHorseSound()
    {
        return GetAnimalSound(nameof(GetHorseSound), "Horse", "neigh");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Lion.")]
    public string GetLionSound()
    {
        return GetAnimalSound(nameof(GetLionSound), "Lion", "roar");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Monkey.")]
    public string GetMonkeySound()
    {
        return GetAnimalSound(nameof(GetMonkeySound), "Monkey", "oo-oo-aa-aa");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Mouse.")]
    public string GetMouseSound()
    {
        return GetAnimalSound(nameof(GetMouseSound), "Mouse", "squeak");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Mule.")]
    public string GetMuleSound()
    {
        return GetAnimalSound(nameof(GetMuleSound), "Mule", "hee-haw");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Owl.")]
    public string GetOwlSound()
    {
        return GetAnimalSound(nameof(GetOwlSound), "Owl", "hoot");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Parrot.")]
    public string GetParrotSound()
    {
        return GetAnimalSound(nameof(GetParrotSound), "Parrot", "squawk");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Pig.")]
    public string GetPigSound()
    {
        return GetAnimalSound(nameof(GetPigSound), "Pig", "oink");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Pony.")]
    public string GetPonySound()
    {
        return GetAnimalSound(nameof(GetPonySound), "Pony", "neigh");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Rabbit.")]
    public string GetRabbitSound()
    {
        return GetAnimalSound(nameof(GetRabbitSound), "Rabbit", "thump");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Raccoon.")]
    public string GetRaccoonSound()
    {
        return GetAnimalSound(nameof(GetRaccoonSound), "Raccoon", "trill");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Rooster.")]
    public string GetRoosterSound()
    {
        return GetAnimalSound(nameof(GetRoosterSound), "Rooster", "cock-a-doodle-doo");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Sheep.")]
    public string GetSheepSound()
    {
        return GetAnimalSound(nameof(GetSheepSound), "Sheep", "baa");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Snake.")]
    public string GetSnakeSound()
    {
        return GetAnimalSound(nameof(GetSnakeSound), "Snake", "hiss");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Squirrel.")]
    public string GetSquirrelSound()
    {
        return GetAnimalSound(nameof(GetSquirrelSound), "Squirrel", "chatter");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Tiger.")]
    public string GetTigerSound()
    {
        return GetAnimalSound(nameof(GetTigerSound), "Tiger", "grrr");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Turkey.")]
    public string GetTurkeySound()
    {
        return GetAnimalSound(nameof(GetTurkeySound), "Turkey", "gobble");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Walrus.")]
    public string GetWalrusSound()
    {
        return GetAnimalSound(nameof(GetWalrusSound), "Walrus", "grunt");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Wolf.")]
    public string GetWolfSound()
    {
        return GetAnimalSound(nameof(GetWolfSound), "Wolf", "howl");
    }


    [KernelFunction]
    [Description("Get the animal sound made by a Zebra.")]
    public string GetZebraSound()
    {
        return GetAnimalSound(nameof(GetZebraSound), "Zebra", "bray");
    }

}