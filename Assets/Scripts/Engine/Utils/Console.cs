using UnityEngine;

namespace Assets.Scripts.Engine.Utils {
    public static class Console {
        private enum TextColor {
            Red,
            Blue,
            Green,
            Teal,
            Purple,
            DarkBlue
        }

        private enum FontStyle {
            None,
            Italic,
            Bold
        }

        public static void LogError(string message) {
            Log(GetColor(TextColor.Red), message);
        }

        public static void LogEvent(string message) {
            Log(GetColor(TextColor.DarkBlue), message);
        }

        public static void LogSuccess(string message) {
            Log(GetColor(TextColor.Green), message);
        }

        public static void LogInfo(string message) {
            Log(GetColor(TextColor.Blue), message);
        }

        public static void LogParameter(string message) {
            Log(GetColor(TextColor.Teal), message, FontStyle.Italic);
        }

        public static void LogImportant(string message) {
            Log(GetColor(TextColor.Purple), message, FontStyle.Bold);
        }

        public static void LogSecondary(string message) {
            Log(GetColor("666666"), message);
        }

        private static string GetColor(TextColor color) {
            return color.ToString();
        }

        private static string GetColor(string color) {
            return "#" + color + "ff";
        }

        private static void Log(string color, string message, FontStyle style = FontStyle.None) {
#if UNITY_EDITOR
            var msg = string.Format("<color={0}>{1}</color>", color, message);
            string modifier = null;
            switch (style) {
                case FontStyle.Italic:
                    modifier = "i";
                    break;

                case FontStyle.Bold:
                    modifier = "b";
                    break;
            }
            if (modifier != null) {
                msg = string.Format("<{0}>{1}</{0}>", modifier, msg);
            }
#else
            var msg  = message;
#endif

            Debug.Log(msg);
        }
    }
}