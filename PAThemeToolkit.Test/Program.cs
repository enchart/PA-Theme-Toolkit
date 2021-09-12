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
            Theme theme = new Theme("Full white");

            // Set GUI color
            theme.GUI = "#FFFFFF";

            // Set background color (RGB)
            theme.Background = Theme.RGBToHex(255, 255, 255);

            // Set arrays of colors
            theme.Players = new string[4];
            for (int i = 0; i < 4; i++)
            {
                theme.Players[i] = "#FFFFFF";
            }

            theme.Objects = new string[9];
            for (int i = 0; i < 9; i++)
            {
                theme.Objects[i] = "#FFFFFF";
            }

            theme.BackgroundObjects = new string[9];
            for (int i = 0; i < 9; i++)
            {
                theme.BackgroundObjects[i] = Theme.RGBToHex(255, 255, 255);
            }

            // Export to file
            theme.ExportToFile("full_white.lst");

            Console.WriteLine("Theme reading test");

            Theme readTheme = new Theme(JSON.Parse(File.ReadAllText("full_white.lst")));
            Console.WriteLine(readTheme);
        }
    }
}
