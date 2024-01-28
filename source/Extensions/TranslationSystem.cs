using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using AmongUs.Data;
using HarmonyLib;

namespace TownOfUs.Extensions
{
    public class Language {
        private static string ResourceDir = "TownOfUs.Resources.Languages";
        private static Language language = null;
        private static Dictionary<string, string> defaultLanguageSet = new Dictionary<string, string>();
        public Dictionary<string, string> languageSet;

        public Language() {
            languageSet = new Dictionary<string, string>(defaultLanguageSet);
        }

        public bool Deserialize(string path) {
            try {
                using StreamReader sr = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                return Deserialize(sr);
            } catch {
                return false;
            }
        }

        public bool Deserialize(Stream stream) {
            using StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
		    return Deserialize(sr);
        }

        public bool Deserialize(StreamReader reader) {
            bool result = true;
            try {
                string data = "";
			    string line;
                while ((line = reader.ReadLine()) != null)
                    if (line.Length >= 3)
                        data = ((!data.Equals("")) ? (data + "," + line) : line);
                if (!data.Equals("")) {
                    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                    jsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                    jsonSerializerOptions.WriteIndented = true;
                    JsonSerializerOptions option = jsonSerializerOptions;
                    foreach (KeyValuePair<string, string> entry in JsonSerializer.Deserialize<Dictionary<string, string>>("{ " + data + " }", option))
                        languageSet[entry.Key] = entry.Value;
                    result = true;
                }
            } catch (Exception e) {
                TownOfUs.Logger.LogMessage("Language.Deserialize Exception: " + e.Message);
                result = false;
            }
            return result;
        }

        public static void Load() {
            string lang = GetLanguage((uint)(int)DataManager.Settings.Language.CurrentLanguage);
            language = new Language();
            language.Deserialize(GetDefaultLanguageStream());
		    Stream builtinLang = GetBuiltinLanguageStream(lang);
            if (builtinLang != null)
                language.Deserialize(builtinLang);
        }

        public static string GetLanguage(uint language) {
            return language switch {
                0u => "English", 
                1u => "Latam", 
                2u => "Brazilian", 
                3u => "Portuguese", 
                4u => "Korean", 
                5u => "Russian", 
                6u => "Dutch", 
                7u => "Filipino", 
                8u => "French", 
                9u => "German", 
                10u => "Italian", 
                11u => "Japanese", 
                12u => "Spanish", 
                13u => "SChinese", 
                14u => "TChinese", 
                15u => "Irish", 
                _ => "English",
            };
        }

        public static void LoadDefaultKey() {
            AddDefaultKey("option.empty", "");
        }

        public static Stream GetDefaultLanguageStream() => Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceDir + ".Lang.dat");

        public static Stream GetBuiltinLanguageStream(string lang) {
            try {
                return Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceDir + "." + lang + ".dat");
            } catch {
                return null;
            }
        }

        public static string GetString(string key) {
            Language obj = language;
            if (obj != null && obj.languageSet.ContainsKey(key))
                return language.languageSet[key];
            return "*" + key;
        }

        public static bool CheckValidKey(string key) => language?.languageSet.ContainsKey(key) ?? true;

        public static void AddDefaultKey(string key, string format) {
            defaultLanguageSet.Add(key, format);
            if (!CheckValidKey(key))
                language.languageSet.Add(key, format);
        }
    }
}