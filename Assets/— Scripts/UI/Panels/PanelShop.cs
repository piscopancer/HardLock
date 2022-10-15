using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelShop : PanelBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}

public class PanelShopFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelShopFile> { }

    Button buttonBack;
    VisualElement buttonsThemes;

    public PanelShopFile()
    {
        PanelMenuFile.OnShopClicked += () =>
        {
            Translate(this, new Vector2(0, 0), new Vector2(0, 3000));
            Setup();
        };

        TranslateInstantly(this, new Vector2(0, 3000));

        buttonBack = new();
        buttonBack.AddClasses(buttonFirst, buttonLarge);
        Add(buttonBack);

        buttonsThemes = new();
        Add(buttonsThemes);
    }

    public void Setup()
    {
        buttonBack.RegisterCallback((ClickEvent click) =>
        {
            Translate(this, new Vector2(0, 3000));
            Back();
        });

        foreach (var theme in Themes.ListThemes)
        {
            var buttonTheme = new Button();
            buttonTheme.style.backgroundColor = theme.ColorShop;
            buttonsThemes.Add(buttonTheme);
        }
    }
}
