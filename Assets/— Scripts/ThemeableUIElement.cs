using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeableUIElement : MonoBehaviour
{
    public enum ElementType { Background, Background2, Arrow, PieceCenter, PieceBack, Accent, Button, Text}
    public ElementType Type;

    void Awake()
    {
        Themes.OnThemeChanged += SetAppearance;

        SetAppearance(Themes.CurrentTheme);
    }

    void OnEnable()
    {
        SetAppearance(Themes.CurrentTheme);
    }

    void OnDestroy()
    {
        Themes.OnThemeChanged -= SetAppearance;
    }

    private void SetAppearance(ThemeProfile theme)
    {
        switch (Type)
        {
            //case ElementType.Background: GetComponent<Image>().color = theme.ThemeData.BackgroundColor; break;
            //case ElementType.Background2: GetComponent<Image>().color = theme.ThemeData.Background2Color; break;
            //case ElementType.Arrow: GetComponent<Image>().color = theme.ThemeData.ArrowColor; break;
            //case ElementType.PieceCenter: GetComponent<Image>().color = theme.ThemeData.PieceCenterColor; break;
            //case ElementType.PieceBack: GetComponent<Image>().color = theme.ThemeData.PieceBackColor; break;
            //case ElementType.Accent: GetComponent<Image>().color = theme.ThemeData.AccentColor; break;
            //case ElementType.Button: GetComponent<Image>().color = theme.ThemeData.ButtonColor; break;
            //case ElementType.Text: GetComponent<TextMeshProUGUI>().color = theme.ThemeData.TextColor; break;
        }
    }
}
