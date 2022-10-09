using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.Collections;
using TriInspector;

public class Themes : MonoBehaviour
{
    public static ThemeProfile CurrentTheme
    {
        get
        {
            foreach (var theme in FindObjectOfType<Themes>().listThemes)
            {
                if (theme.IfSelected)
                {
                    return theme;
                }
            }
            return FindObjectOfType<Themes>().listThemes[0];
        }
    }
    [SerializeField] List<ThemeProfile> listThemes;
    public static List<ThemeProfile> ListThemes
    {
        get
        {
            return FindObjectOfType<Themes>().listThemes;
        }
    }
    public static Action<ThemeProfile> OnThemeChanged;
    public static Action<ThemeProfile, int> OnThemeBought;

    void Awake()
    {
        ThemeButton.OnThemeSelect += SetTheme;

        SetTheme(CurrentTheme);
    }

    void SetTheme(ThemeProfile newTheme)
    {
        foreach (var theme in listThemes)
        {
            if (newTheme == theme)
            {
                theme.IfSelected = true;
            }
            else
            {
                theme.IfSelected = false;
            }
        }
        OnThemeChanged?.Invoke(newTheme);
    }
}

[Serializable]
public class ThemeProfile : PurchasableItemPermanent
{
    [field: SerializeField, TriInspector.ReadOnly] public bool IfSelected { get; set; }
    [field: SerializeField, Min(0)] public int Price { get; set; }
    [field: SerializeField] public bool IfBought { get; set; }
    [field: SerializeField, InlineEditor] public ThemeData ThemeData { get; private set; }
}
