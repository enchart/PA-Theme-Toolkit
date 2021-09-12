# Project Arrhythmia Theme Toolkit
A library for modifying and creating [Project Arrhythmia](https://store.steampowered.com/app/440310/Project_Arrhythmia/) themes.

## Installing the library (VS 2019)

 1. Right click your project in the Solution explorer
 2. Click "Manage NuGet packages"
 3. Search "PAThemeToolkit" and select the first result
 4. Click "Install"

 You can download the package manually on it's [NuGet page](https://www.nuget.org/packages/PAThemeToolkit/).
 
# Using the library
## Creating a theme

It is recommended to use the constructor that takes in a `string name`.
```csharp
Theme myTheme = new Theme("Hello Theme Toolkit!");
```

## Creating a color

There are multiple ways to create a color object:

### From a Hex code string
```csharp
Color myColor = new Color("#7F7F7F");
Color myOtherColor = new Color("7F7F7F");
```

### From RGB `float` numbers (0-1)
```csharp
Color myColor = new Color(0.5f, 0.5f, 0.5f);
```

### From RGB `int` numbers (0-255)
```csharp
Color myColor = new Color(127, 127, 127);
```

## Modifying a color
You can modify color's `R`, `G`, and `B` `float` values:
```csharp
myColor.R = 0.5f;
myColor.G = 0.5f;
myColor.B = 0.5f;
```

## Assigning colors
A single Project Arrhythmia theme has 24 colors:
- 1 background color
- 1 GUI color
- 4 players colors
- 9 objects colors
- 9 background objects colors

You can assign a single color like this:
```csharp
Theme myTheme = new Theme("Gray Background");
Color myColor = new Color("#7F7F7F");
myTheme.Background = myColor;
```

And an array of colors like this:
```csharp
Color[] myColors = new Color[4];
myColors[0] = new Color("#7F7F7F");
myColors[1] = new Color("7F7F7F");
myColors[2] = new Color(127, 127, 127);
myColors[3] = new Color(0.5f, 0.5f, 0.5f);
myTheme.Players = myColors;
```

## Building the theme
You can either get a JSON object representing the theme or export it to a file. Note that if the file already exists, it will be overwritten.
```csharp
theme.ExportToFile("my_new_theme.lst");
JSONNode json = theme.ToJson();
```

## Example program
### Full gray theme

```csharp
using System;
using System.IO;
using SimpleJSON;

namespace PAThemeToolkit.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Theme creation test");

            // Create a new theme
            Theme theme = new Theme("Full Gray");

            // Set GUI color from Hex string
            theme.GUI = new Color("#7F7F7F");

            // Set background color from RGB [0..255]
            theme.Background = new Color(127, 127, 127);

            // Set arrays of colors
            theme.Players = new Color[4];
            for (int i = 0; i < 4; i++)
            {
                // Set color from RGB [0..1]
                theme.Players[i] = new Color(0.5f, 0.5f, 0.5f);
            }

            theme.Objects = new Color[9];
            for (int i = 0; i < 9; i++)
            {
                // Set color from Hex string (without #)
                theme.Objects[i] = new Color("7f7f7f");
            }

            theme.BackgroundObjects = new Color[9];
            for (int i = 0; i < 9; i++)
            {
                theme.BackgroundObjects[i] = new Color("#7f7f7f");
            }

            // Export to file
            theme.ExportToFile("full_white.lst");

            Console.WriteLine("Theme reading test");

            Theme readTheme = new Theme(JSON.Parse(File.ReadAllText("full_white.lst")));
            Console.WriteLine(readTheme);
        }
    }
}
```
