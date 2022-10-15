using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Languages
{
    English,
    Russian
}

public class Language : MonoBehaviour
{
    [SerializeField] Languages languageCurrent = Languages.English;
    public static Languages LanguageCurrent
    {
        get
        {
            return FindObjectOfType<Language>().languageCurrent;
        }
    }

    public static Action<Languages> OnLanguageChanged;

    void Awake()
    {
        SaveSystem.OnSaveLoaded += delegate (SaveSystem.SaveData save)
        {
            languageCurrent = save.LanguageCurrent;
        };
        PanelSettingsFile.OnLanguageClicked += ChangeLanguage;
    }

    void ChangeLanguage(Languages newLang)
    {
        languageCurrent = newLang;
        OnLanguageChanged?.Invoke(newLang);
    }
}
