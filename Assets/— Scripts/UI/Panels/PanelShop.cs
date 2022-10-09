using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

public class PanelShop : PanelBase
{
    //[SerializeField, Required] Button buttonClose;
    [SerializeField, Required] RectTransform holderButtonsTheme;
    [SerializeField, Required] ThemeButton prefabButtonTheme;

    protected override void Awake()
    {
        base.Awake();

        foreach (var theme in Themes.ListThemes)
        {
            var button = Instantiate(prefabButtonTheme, holderButtonsTheme);
            button.Setup(theme);
        }
    }
}
