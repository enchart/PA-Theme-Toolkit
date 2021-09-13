/*
    Copyright (c) 2021 Reimnop
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/
// shut up ruymock

namespace PAThemeToolkit
{
    /// <summary>
    /// Color struct.
    /// </summary>
    public struct Color
    {
        private float r, g, b;

        /// <summary>
        /// R component in range [0..1].
        /// </summary>
        public float R
        {
            get => r;
            set => r = value;
        }

        /// <summary>
        /// G component in range [0..1].
        /// </summary>
        public float G
        {
            get => g;
            set => g = value;
        }

        /// <summary>
        /// B component in range [0..1].
        /// </summary>
        public float B
        {
            get => b;
            set => b = value;
        }

        /// <summary>
        /// R component in range [0..255].
        /// </summary>
        public int RInt
        {
            get => (int)(r * 255.0f);
            set => r = value / 255.0f;
        }

        /// <summary>
        /// G component in range [0..255].
        /// </summary>
        public int GInt
        {
            get => (int)(g * 255.0f);
            set => g = value / 255.0f;
        }

        /// <summary>
        /// B component in range [0..255].
        /// </summary>
        public int BInt
        {
            get => (int)(b * 255.0f);
            set => b = value / 255.0f;
        }

        /// <summary>
        /// Constructs the color with values in range [0..1].
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// Constructs the color with values in range [0..255].
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public Color(int r, int g, int b)
        {
            this.r = r / 255.0f;
            this.g = g / 255.0f;
            this.b = b / 255.0f;
        }

        /// <summary>
        /// Constructs the color from hex code.
        /// </summary>
        /// <param name="hexCode"></param>
        public Color(string hexCode)
        {
            if (hexCode[0] == '#')
            {
                hexCode = hexCode.Substring(1, hexCode.Length - 1);
            }
            hexCode = hexCode.ToLower();

            int r1 = hexCode[0] > '9' ? hexCode[0] - 'a' + 10 : hexCode[0] - '0';
            int r2 = hexCode[1] > '9' ? hexCode[1] - 'a' + 10 : hexCode[1] - '0';
            int g1 = hexCode[2] > '9' ? hexCode[2] - 'a' + 10 : hexCode[2] - '0';
            int g2 = hexCode[3] > '9' ? hexCode[3] - 'a' + 10 : hexCode[3] - '0';
            int b1 = hexCode[4] > '9' ? hexCode[4] - 'a' + 10 : hexCode[4] - '0';
            int b2 = hexCode[5] > '9' ? hexCode[5] - 'a' + 10 : hexCode[5] - '0';

            int r = r1 * 16 + r2;
            int g = g1 * 16 + g2;
            int b = b1 * 16 + b2;

            this.r = r / 255.0f;
            this.g = g / 255.0f;
            this.b = b / 255.0f;
        }

        /// <summary>
        /// Gets the RGB values in range [0..1].
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public void AsRgbFloat(out float r, out float g, out float b)
        {
            r = this.r;
            g = this.g;
            b = this.b;
        }

        /// <summary>
        /// Gets the RGB values in range [0..255].
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public void AsRgbInt(out int r, out int g, out int b)
        {
            r = (int)(this.r * 255.0f);
            g = (int)(this.g * 255.0f);
            b = (int)(this.b * 255.0f);
        }

        public override string ToString()
        {
            return $"{RInt:X2}{GInt:X2}{BInt:X2}";
        }
    }
}