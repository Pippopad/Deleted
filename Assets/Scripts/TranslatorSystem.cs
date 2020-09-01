using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class TranslatorSystem
{
    public static Dictionary<String, String> Fields { get; private set; }

    static TranslatorSystem()
    {
        LoadLanguage();
    }

    private static void LoadLanguage()
    {
        if (Fields == null)
            Fields = new Dictionary<string, string>();

        Fields.Clear();
        string lang = Get2LetterISOCodeFromSystemLanguage().ToLower();

        var textAsset = Resources.Load(@"Languages/" + lang);
        string allTexts = "";
        if (textAsset == null) textAsset = Resources.Load(@"Languages/en") as TextAsset;
        if (textAsset == null) Debug.LogError("Language file not found: Assets/Resources/Languages/en.txt");
        allTexts = (textAsset as TextAsset).text;
        string[] lines = allTexts.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        string key, value;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IndexOf("=") >= 0 && !lines[i].StartsWith("#"))
            {
                key = lines[i].Substring(0, lines[i].IndexOf("="));
                value = lines[i].Substring(lines[i].IndexOf("=") + 1,
                        lines[i].Length - lines[i].IndexOf("=") - 1).Replace("\\n", Environment.NewLine);
                Fields.Add(key, value);
            }
        }
    }

    public static string GetLanguage()
    {
        return Get2LetterISOCodeFromSystemLanguage().ToLower();
    }

    private static string Get2LetterISOCodeFromSystemLanguage()
    {
        SystemLanguage lang = Application.systemLanguage;
        string result = "EN";
        switch (lang)
        {
            case SystemLanguage.Afrikaans: result = "AF"; break;
            case SystemLanguage.Arabic: result = "AR"; break;
            case SystemLanguage.Basque: result = "EU"; break;
            case SystemLanguage.Belarusian: result = "BY"; break;
            case SystemLanguage.Bulgarian: result = "BG"; break;
            case SystemLanguage.Catalan: result = "CA"; break;
            case SystemLanguage.Chinese: result = "ZH"; break;
            case SystemLanguage.ChineseSimplified: result = "ZH"; break;
            case SystemLanguage.ChineseTraditional: result = "ZH"; break;
            case SystemLanguage.Czech: result = "CS"; break;
            case SystemLanguage.Danish: result = "DA"; break;
            case SystemLanguage.Dutch: result = "NL"; break;
            case SystemLanguage.English: result = "EN"; break;
            case SystemLanguage.Estonian: result = "ET"; break;
            case SystemLanguage.Faroese: result = "FO"; break;
            case SystemLanguage.Finnish: result = "FI"; break;
            case SystemLanguage.French: result = "FR"; break;
            case SystemLanguage.German: result = "DE"; break;
            case SystemLanguage.Greek: result = "EL"; break;
            case SystemLanguage.Hebrew: result = "IW"; break;
            case SystemLanguage.Hungarian: result = "HU"; break;
            case SystemLanguage.Icelandic: result = "IS"; break;
            case SystemLanguage.Indonesian: result = "IN"; break;
            case SystemLanguage.Italian: result = "IT"; break;
            case SystemLanguage.Japanese: result = "JA"; break;
            case SystemLanguage.Korean: result = "KO"; break;
            case SystemLanguage.Latvian: result = "LV"; break;
            case SystemLanguage.Lithuanian: result = "LT"; break;
            case SystemLanguage.Norwegian: result = "NO"; break;
            case SystemLanguage.Polish: result = "PL"; break;
            case SystemLanguage.Portuguese: result = "PT"; break;
            case SystemLanguage.Romanian: result = "RO"; break;
            case SystemLanguage.Russian: result = "RU"; break;
            case SystemLanguage.SerboCroatian: result = "SH"; break;
            case SystemLanguage.Slovak: result = "SK"; break;
            case SystemLanguage.Slovenian: result = "SL"; break;
            case SystemLanguage.Spanish: result = "ES"; break;
            case SystemLanguage.Swedish: result = "SV"; break;
            case SystemLanguage.Thai: result = "TH"; break;
            case SystemLanguage.Turkish: result = "TR"; break;
            case SystemLanguage.Ukrainian: result = "UK"; break;
            case SystemLanguage.Unknown: result = "EN"; break;
            case SystemLanguage.Vietnamese: result = "VI"; break;
        }

        return result;
    }
}
