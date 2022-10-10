using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TriInspector;
using UnityEngine.UIElements;

public class PanelSettings : PanelBase
{
    public static Action<Languages> OnLanguageClicked;

    Button buttonClose, buttonEnglish, buttonRussian;

    protected override void Awake()
    {
        base.Awake();

        PanelMenu.OnSettingsClicked += () =>
        {
            Show();
        };

        buttonClose = document.rootVisualElement.Q<Button>("button-close");
        buttonClose.RegisterCallback((ClickEvent click) =>
        {
            Hide();
        });
        buttonEnglish = document.rootVisualElement.Q<Button>("button-english");
        buttonEnglish.RegisterCallback((ClickEvent click) =>
        {
            Language.LanguageCurrent = Languages.English;
        });
        buttonRussian = document.rootVisualElement.Q<Button>("button-russian");
        buttonRussian.RegisterCallback((ClickEvent click) =>
        {
            Language.LanguageCurrent = Languages.Russian;
        });
    }
}
