using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TriInspector;
using UnityEngine.UIElements;

public class PanelSettings : PanelBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}

public class PanelSettingsFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelSettingsFile> { }

    public static Action<Languages> OnLanguageClicked;

    public PanelSettingsFile()
    {
        PanelMenuFile.OnSettingsClicked += () => {
            Translate(this, new Vector2(0, 0), new Vector2(-3000, 0));
        };
        SaveSystem.OnAppStarted += () => {
            TranslateInstantly(this, new Vector2(-3000, 0));
        };

        var body = new ThemedContainerSecond();
        Add(body);
        body.name = "body";

        #region header

        var header = new ThemedContainerFirst();
        body.Add(header);
        header.name = "header";

        var labelHeader = new ThemedLabelSecond(new Translation("Settings", "Настройки"));
        header.Add(labelHeader);
        labelHeader.name = "label-header";

        var buttonHide = new ThemedButtonSecond();
        header.Add(buttonHide);
        buttonHide.name = "button-hide";
        buttonHide.RegisterCallback((ClickEvent click) =>
        {
            Back();
            Translate(this, new Vector2(-3000, 0));
        });
        var buttonHideIcon = new ThemedIconSecond();
        buttonHide.Add(buttonHideIcon);
        buttonHideIcon.name = "button-hide-icon";

        #endregion

        #region main

        var main = new VisualElement();
        body.Add(main);
        main.name = "main";

        var labelChooseLang = new ThemedLabelFirst(new Translation("Choose language", "Выберите язык"));
        main.Add(labelChooseLang);
        labelChooseLang.AddClasses("label-title");

        var buttonsLanguage = new VisualElement();
        main.Add(buttonsLanguage);
        buttonsLanguage.name = "buttons-language";

        var buttonEnglish = new ButtonLanguage("English");
        buttonsLanguage.Add(buttonEnglish);
        buttonEnglish.AddClasses("button-language");
        buttonEnglish.name = "button-english";
        buttonEnglish.RegisterCallback((ClickEvent click) =>
        {
            OnLanguageClicked?.Invoke(Languages.English);
        });

        var buttonRussian = new ButtonLanguage("Русский");
        buttonsLanguage.Add(buttonRussian);
        buttonRussian.AddClasses("button-language");
        buttonRussian.name = "button-russian";
        buttonRussian.RegisterCallback((ClickEvent click) =>
        {
            OnLanguageClicked?.Invoke(Languages.Russian);
        });

        #endregion
    }
}

public class ButtonLanguage : ThemedButtonFirst
{
    public new class UxmlFactory : UxmlFactory<ButtonLanguage> { }

    public ButtonLanguage(): base() { }

    public ButtonLanguage(string langName) : base() {
        var languageIcon = new VisualElement();
        Add(languageIcon);
        languageIcon.name = "icon";
        var languageName = new ThemedLabelFirst(langName);
        Add(languageName);
        languageName.name = "name";
    }
}
