using System;
using System.Globalization;
using UnityEngine;

namespace Extensions
{
    public static class ColorRGBExtension
    {
        /// <summary>
        /// It takes a hex color string, converts it to a decimal number, then splits it into its RGB components, returns Color
        /// </summary>
        /// <param name="hex">The hex color string to convert.</param>
        /// <param name="Alpha">The alpha value of the color.</param>
        /// <returns>
        /// A Color32 object
        /// </returns>
        public static Color HexToRGB(this string hex, byte Alpha = 255)
        {
            hex = FixAndBasicValidateHexColorString(hex);
            var decimalHexColor = int.Parse(hex, NumberStyles.HexNumber);

            if (hex.ToUpper() != decimalHexColor.ToString("X"))
                throw new ArgumentException();

            var R = (byte) ((decimalHexColor >> 16) & byte.MaxValue);
            var G = (byte) ((decimalHexColor >> 8) & byte.MaxValue);
            var B = (byte) (decimalHexColor & byte.MaxValue);

            return new Color32(R, G, B, Alpha);
        }

        /// <summary>
        /// If the color is dark, return true
        /// </summary>
        /// <param name="Color">The color you want to check.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public static bool IsDarkColor(this Color c)
        {
            var luminance = (byte) (0.2126 * c.r + 0.7152 * c.g + 0.0722 * c.b);
            var yic = (byte) ((c.r * 299 + c.g * 587 + c.b * 114) / 1000);
            return yic < 177 || luminance < 80;
        }

        /// <summary>
        /// It takes a hex color string, and returns a valid hex color string
        /// </summary>
        /// <param name="hex">The hex color string to convert.</param>
        /// <returns>
        /// The hex value is being returned.
        /// </returns>
        private static string FixAndBasicValidateHexColorString(string hex)
        {
            if (string.IsNullOrEmpty(hex)) throw new ArgumentNullException();
            if (hex[0] == '#') hex = hex.Substring(1);
            if (hex.Length == 3)
                hex += hex;
            if (hex.Length != 6) throw new ArgumentOutOfRangeException();
            return hex;
        }
    }
}
