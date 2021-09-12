using System;
using System.IO;
using SimpleJSON;

namespace PAThemeToolkit
{
    /// <summary>
    /// The theme, the base of the library. Use this to make a theme and export to a file or to a stream.
    /// </summary>
    public class Theme
    {
        private static Random random;
        
        static Theme()
        {
            random = new Random();
        }

        private string GenId()
        {
            const string idChars = "0123456789";

            string id = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                id += idChars[random.Next(0, idChars.Length)];
            }

            return id;
        }

        /// <summary>
        /// Converts RGB color into a Hex format color string.
        /// </summary>
        /// <param name="r">Red component (0-255)</param>
        /// <param name="g">Green component (0-255)</param>
        /// <param name="b">Blue component (0-255)</param>
        /// <returns></returns>
        public static string RGBToHex(int r, int g, int b)
        {
            return $"{r:X2}{g:X2}{b:X2}";
        }

        /// <summary>
        /// The theme's ID. This value is chosen randomly. This field is read-only.
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// The theme's name. This will be visible in the Project Arrhythmia Editor.
        /// </summary>
        public string Name;

        /// <summary>
        /// The theme's GUI color.
        /// </summary>
        public string GUI;

        /// <summary>
        /// The theme's background color.
        /// </summary>
        public string Background;

        /// <summary>
        /// The theme's players colors.
        /// </summary>
        public string[] Players;

        /// <summary>
        /// The theme's objects colors.
        /// </summary>
        public string[] Objects;

        /// <summary>
        /// The theme's background objects colors.
        /// </summary>
        public string[] BackgroundObjects;

        /// <summary>
        /// Default theme constructor. Name is assigned to "Untitled".
        /// </summary>
        public Theme()
        {
            ID = GenId();
            Name = "Untitled";
            Players = new string[4];
            Objects = new string[9];
            BackgroundObjects = new string[9];
        }


        /// <summary>
        /// Theme constructor.
        /// </summary>
        /// <param name="name">Theme name</param>
        public Theme(string name)
        {
            ID = GenId();
            Name = name;
            Players = new string[4];
            Objects = new string[9];
            BackgroundObjects = new string[9];
        }

        /// <summary>
        /// Theme constructor.
        /// </summary>
        /// <param name="name">Theme name</param>
        /// <param name="gui">Theme GUI color</param>
        /// <param name="background">Theme background color</param>
        /// <param name="players">Theme players colors</param>
        /// <param name="objects">Theme objects colors</param>
        /// <param name="backgroundObjects">Theme background objects colors</param>
        public Theme(string name, string gui, string background, string[] players, string[] objects, string[] backgroundObjects)
        {
            ID = GenId();
            Name = name;
            GUI = gui;
            Background = background;
            Players = players;
            Objects = objects;
            BackgroundObjects = backgroundObjects;
        }

        /// <summary>
        /// Construct a theme with a JSON object.
        /// </summary>
        /// <param name="json">A JSONNode object</param>
        public Theme(JSONNode json)
        {
            ID = GenId();
            Name = json["name"];
            GUI = json["gui"];
            Background = json["bg"];

            Players = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Players[i] = json["players"][i];
            }

            Objects = new string[9];
            for (int i = 0; i < 9; i++)
            {
                Objects[i] = json["objs"][i];
            }

            BackgroundObjects = new string[9];
            for (int i = 0; i < 9; i++)
            {
                BackgroundObjects[i] = json["bgs"][i];
            }
        }

        /// <summary>
        /// Writes the theme to a file.
        /// </summary>
        /// <param name="path">A file path</param>
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, ToJson().ToString());
        }

        /// <summary>
        /// Gets a JSON object of the theme.
        /// </summary>
        /// <returns>A JSONNode object</returns>
        public JSONNode ToJson()
        {
            JSONObject json = new JSONObject();
            json["id"] = ID;
            json["name"] = Name;
            json["gui"] = GUI;
            json["bg"] = Background;

            for (int i = 0; i < 4; i++)
            {
                json["players"].Add(Players[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                json["objs"].Add(Objects[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                json["bgs"].Add(BackgroundObjects[i]);
            }

            return json;
        }

        public override string ToString()
        {
            return ToJson().ToString();
        }
    }
}