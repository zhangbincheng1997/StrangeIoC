using UnityEngine;
using System.Collections.Generic;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    // public const string Language = Chinese;
    public const string Language = English;
    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    private Dictionary<string, string> langDict = new Dictionary<string, string>();

    private LocalizationManager()
    {
        // langDict.Clear();

        TextAsset langInfo = Resources.Load<TextAsset>(Language);
        string[] lines = langInfo.text.Split('\n');
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] pro = line.Split('=');
                string key = pro[0];
                string value = pro[1];
                langDict.Add(key, value);
            }
        }
    }

    public void Init()
    {
        // NONE
    }

    public string GetValue(string key)
    {
        string value;
        langDict.TryGetValue(key, out value);
        if (value != null)
        {
            return value;
        }
        else
        {
            Debug.LogWarning(key + "  Non-existent");
            return null;
        }
    }
}
