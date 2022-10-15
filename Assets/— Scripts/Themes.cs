using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Collections;
using UnityEngine.UIElements;
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
        SaveSystem.OnSaveLoaded += (SaveSystem.SaveData save) =>
        {
            SetTheme(save.ThemeCurrent);
        };
        SaveSystem.OnSaveDoesNotExist += () =>
        {
            SetTheme(ListThemes[0]);
        };
        ThemeButton.OnThemeSelect += SetTheme;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetTheme(ListThemes[1]);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetTheme(ListThemes[0]);
        }
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
        Debug.Log("theme set to: " + newTheme.Name.Text);
    }
}

[Serializable]
public class ThemeProfile : PurchasableItemPermanent
{
    [field: SerializeField, Required, InlineEditor] public Translation Name { get; private set; }
    [field: SerializeField, TriInspector.ReadOnly] public bool IfSelected { get; set; }
    [field: SerializeField, Min(0)] public int Price { get; set; }
    [field: SerializeField] public bool IfBought { get; set; }
    [field: SerializeField] public Color ColorShop { get; private set; } = Color.white;
    [field: SerializeField, Required] public StyleSheet USS { get; private set; }
}
