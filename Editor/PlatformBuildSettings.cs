using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AbyssMoth
{
    public sealed class PlatformBuildSettings : EditorWindow
    {
        private BuildPlatform selectedPlatform = BuildPlatform.None;
        private GUIStyle greenTextStyle;

        [MenuItem("RimuruDev Tools/Platform Build Settings")]
        public static void ShowWindow() =>
            GetWindow<PlatformBuildSettings>("Platform Build Settings");

        private void OnEnable() =>
            selectedPlatform = GetCurrentPlatform();

        private void OnGUI()
        {
            if (greenTextStyle == null)
                greenTextStyle = new GUIStyle(EditorStyles.label) { normal = { textColor = Color.green } };

            GUILayout.Label("Select the build platform:", EditorStyles.boldLabel);

            GUILayout.Label("Current platform: " + selectedPlatform, greenTextStyle);

            selectedPlatform = (BuildPlatform)EditorGUILayout.EnumPopup("Platform", selectedPlatform);

            if (GUILayout.Button("Apply"))
                ApplyPlatformSettings(selectedPlatform);
        }

        private static void ApplyPlatformSettings(BuildPlatform platform)
        {
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            defines = RemoveDefine(defines, "RU_STORE");
            defines = RemoveDefine(defines, "YANDEX_GAMES");
            defines = RemoveDefine(defines, "GOOGLE_PLAY");
            defines = RemoveDefine(defines, "NASH_STORE");

            switch (platform)
            {
                case BuildPlatform.RU_STORE:
                    defines = AddDefine(defines, "RU_STORE");
                    break;
                case BuildPlatform.YANDEX_GAMES:
                    defines = AddDefine(defines, "YANDEX_GAMES");
                    break;
                case BuildPlatform.GOOGLE_PLAY:
                    defines = AddDefine(defines, "GOOGLE_PLAY");
                    break;
                case BuildPlatform.NASH_STORE:
                    defines = AddDefine(defines, "NASH_STORE");
                    break;
                case BuildPlatform.None:
                    break;
                default:
                    defines = AddDefine(defines, "GOOGLE_PLAY");
                    break;
            }

            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, defines);

            Debug.Log($"Platform define set: {platform}");
        }

        private static BuildPlatform GetCurrentPlatform()
        {
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);

            if (defines.Contains("RU_STORE"))
                return BuildPlatform.RU_STORE;

            if (defines.Contains("YANDEX_GAMES"))
                return BuildPlatform.YANDEX_GAMES;

            if (defines.Contains("GOOGLE_PLAY"))
                return BuildPlatform.GOOGLE_PLAY;

            if (defines.Contains("NASH_STORE"))
                return BuildPlatform.NASH_STORE;

            return BuildPlatform.None;
        }

        private static string AddDefine(string defines, string defineToAdd)
        {
            if (!defines.Contains(defineToAdd))
            {
                if (defines.Length > 0)
                    defines += ";";

                defines += defineToAdd;
            }

            return defines;
        }

        private static string RemoveDefine(string defines, string defineToRemove)
        {
            var allDefines = defines.Split(';').ToList();
            
            allDefines.Remove(defineToRemove);
            
            return string.Join(";", allDefines.ToArray());
        }
    }
}