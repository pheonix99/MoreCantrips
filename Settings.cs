using BlueprintCore.Utils;
using Kingmaker.Localization;
using ModMenu.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;
using Menu = ModMenu.ModMenu;

namespace MoreCantrips
{
    class Settings
    {
        private const string RootKey = "morecantrips.settings";
        private static readonly string RootStringKey = "MoreCantrips.Settings";
        internal static bool IsEnabled(string key)
        {
            return Menu.GetSettingValue<bool>(GetKey(key.ToLower()));
        }
        private static string GetKey(string partialKey)
        {
            return ($"{RootKey}.{partialKey}").ToLower();
        }

        internal static bool IsCharOpsPlusEnabled()
        {
            return UnityModManager.modEntries.Where(
                mod => mod.Info.Id.Equals("CharacterOptionsPlus") && mod.Enabled && !mod.ErrorOnLoading)
              .Any();
        }

        internal static bool IsLevelableAivuEnabled()
        {
            return UnityModManager.modEntries.Where(
                mod => mod.Info.Id.Equals("LevelableAivu") && mod.Enabled && !mod.ErrorOnLoading)
              .Any();
        }

        internal static bool ScalingOn()
        {
            return UnityModManager.modEntries.Where(
                mod => mod.Info.Id.Equals("PhoenixCantrips") && mod.Enabled && !mod.ErrorOnLoading)
              .Any() && Menu.GetSettingValue<bool>(GetKey("phoenixcantrips.settings.scaling"));
        }

        public static void Make()
        {
            LocalizationTool.LoadLocalizationPack("Mods\\MoreCantrips\\Localization\\Settings.json");
            LocalizationTool.LoadLocalizationPack("Mods\\MoreCantrips\\Localization\\LocalizedStrings.json");
            var builder = SettingsBuilder.New(RootKey, GetString("Title"));
            builder.AddToggle(MakeToggle("Firebolt", true, true));
            builder.AddToggle(MakeToggle("BurningTouch", true, true));
            builder.AddToggle(MakeToggle("PainfulNote", true, true));
            builder.AddToggle(MakeToggle("DissonantTouch", true, true));
            builder.AddToggle(MakeToggle("LesserCorrosiveTouch", true, true));
            builder.AddToggle(MakeToggle("LesserShockingGrasp", true, true));
            builder.AddToggle(MakeToggle("FrostyTouch", true, true));
            
            ModMenu.ModMenu.AddSettings(builder);
        }

        private static LocalizedString GetString(string key, bool usePrefix = true)
        {
            var fullKey = usePrefix ? $"{RootStringKey}.{key}" : key;
            return LocalizationTool.GetString(fullKey);
        }

        private static Toggle MakeToggle(string keyStub, bool defaultVal, bool desc = true)
        {

            var toggle = Toggle.New($"{RootKey}.{keyStub.ToLower()}", defaultVal, GetString(keyStub));
            if (desc)
                toggle.WithLongDescription(GetString($"{keyStub}.Desc"));

            return toggle;
        }
    }
}
