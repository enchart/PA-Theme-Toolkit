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
        /// The theme's ID. This value is chosen randomly. This field is read-only.
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// The theme's name. This will be visible in the Project Arrhythmia Editor.
        /// </summary>
        public string Name;

        /// <summary>
        /// The theme's background color.
        /// </summary>
        public Color Background;

        /// <summary>
        /// The theme's GUI color.
        /// </summary>
        public Color GUI;

        /// <summary>
        /// The theme's players colors.
        /// </summary>
        public Color[] Players;

        /// <summary>
        /// The theme's objects colors.
        /// </summary>
        public Color[] Objects;

        /// <summary>
        /// The theme's background objects colors.
        /// </summary>
        public Color[] BackgroundObjects;

        /// <summary>
        /// Default Theme constructor. Name is assigned to "Untitled".
        /// </summary>
        public Theme()
        {
            ID = GenId();
            Name = "Unitlted";
            Players = new Color[4];
            Objects = new Color[9];
            BackgroundObjects = new Color[9];
        }

        /// <summary>
        /// Theme constructor.
        /// </summary>
        /// <param name="name">Theme name.</param>
        public Theme(string name)
        {
            ID = GenId();
            Name = name;
            Players = new Color[4];
            Objects = new Color[9];
            BackgroundObjects = new Color[9];
        }

        /// <summary>
        /// Theme constructor.
        /// </summary>
        /// <param name="name">Theme name.</param>
        /// <param name="background">Theme background color.</param>
        /// <param name="gui">Theme GUI color.</param>
        /// <param name="players">Theme players colors.</param>
        /// <param name="objects">Theme objects colors.</param>
        /// <param name="backgroundObjects">Theme background objects colors.</param>
        public Theme(string name, Color background, Color gui, Color[] players, Color[] objects, Color[] backgroundObjects)
        {
            ID = GenId();
            Name = name;
            Background = background;
            GUI = gui;
            Players = players;
            Objects = objects;
            BackgroundObjects = backgroundObjects;
        }

        /// <summary>
        /// Construct a theme prefab with a JSON object.
        /// </summary>
        /// <param name="json">A JSONNode object.</param>
        public Theme(JSONNode json)
        {
            ID = GenId();
            Name = json["name"];
            Background = new Color(json["bg"]);
            GUI = new Color(json["gui"]);

            Players = new Color[4];
            for (int i = 0; i < 4; i++)
            {
                Players[i] = new Color(json["players"][i]);
            }

            Objects = new Color[9];
            for (int i = 0; i < 9; i++)
            {
                Objects[i] = new Color(json["objs"][i]);
            }

            BackgroundObjects = new Color[9];
            for (int i = 0; i < 9; i++)
            {
                BackgroundObjects[i] = new Color(json["bgs"][i]);
            }
        }

        /// <summary>
        /// Writes the theme to a file.
        /// </summary>
        /// <param name="path">A file path.</param>
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, ToJson().ToString());
        }

        public override string ToString()
        {
            return ToJson().ToString();
        }

        /// <summary>
        /// Gets a JSON object of the theme.
        /// </summary>
        /// <returns>A JSONNode object.</returns>
        public JSONNode ToJson()
        {
            JSONObject json = new JSONObject();
            json["id"] = ID;
            json["name"] = Name;
            json["bg"] = Background.ToString();
            json["gui"] = GUI.ToString();

            for (int i = 0; i < 4; i++)
            {
                json["players"].Add(Players[i].ToString());
            }

            for (int i = 0; i < 9; i++)
            {
                json["objs"].Add(Objects[i].ToString());
            }

            for (int i = 0; i < 9; i++)
            {
                json["bgs"].Add(BackgroundObjects[i].ToString());
            }

            return json;
        }
    }
}