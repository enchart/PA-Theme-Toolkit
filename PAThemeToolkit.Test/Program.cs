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
