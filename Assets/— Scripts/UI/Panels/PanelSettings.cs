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
        PanelMenuFile.OnSettingsClicked += () =>
        {
            Translate(this, new Vector2(0, 0), new Vector2(-3000, 0));
        };
        SaveSystem.OnAppStarted += () =>
        {
            TranslateInstantly(this, new Vector2(-3000, 0));
        };

        this.AddClasses(backgroundFirst);

        #region header

        var header = new VisualElement();
        Add(header);
        header.name = "header";
        header.AddClasses(backgroundSecond);

        var labelHeader = new LabelWithTranslation(new Translation("Settings", "Настройки"));
        header.Add(labelHeader);
        labelHeader.name = "label-header";
        labelHeader.AddClasses(textSecond);

        var buttonHide = new Button();
        header.Add(buttonHide);
        buttonHide.name = "button-hide";
        buttonHide.AddClasses(buttonFirst);
        buttonHide.RegisterCallback((ClickEvent click) =>
        {
            Back();
            Translate(this, new Vector2(-3000, 0));
        });
        var buttonHideIcon = new VisualElement();
        buttonHide.Add(buttonHideIcon);
        buttonHideIcon.AddClasses("icon");

        #endregion

        #region main

        var main = new VisualElement();
        Add(main);
        main.name = "main";

        var labelChooseLang = new LabelWithTranslation(new Translation("Choose language", "Выберите язык"));
        main.Add(labelChooseLang);
        labelChooseLang.AddClasses(textSecond, "label-title");

        var buttonsLanguage = new VisualElement();
        main.Add(buttonsLanguage);
        buttonsLanguage.name = "buttons-language";

        var buttonEnglish = new ButtonLanguage("English");
        buttonsLanguage.Add(buttonEnglish);
        buttonEnglish.AddClasses("button-language", buttonFirst);
        buttonEnglish.name = "button-english";
        buttonEnglish.RegisterCallback((ClickEvent click) =>
        {
            OnLanguageClicked?.Invoke(Languages.English);
        });

        var buttonRussian = new ButtonLanguage("Русский");
        buttonsLanguage.Add(buttonRussian);
        buttonRussian.AddClasses("button-language", buttonFirst);
        buttonRussian.name = "button-russian";
        buttonRussian.RegisterCallback((ClickEvent click) =>
        {
            OnLanguageClicked?.Invoke(Languages.Russian);
        });

        #endregion
    }
}

public class ButtonLanguage : Button
{
    public new class UxmlFactory : UxmlFactory<ButtonLanguage> { }

    public ButtonLanguage()
    {

    }

    public ButtonLanguage(string langName)
    {
        var languageIcon = new VisualElement();
        Add(languageIcon);
        languageIcon.name = "icon";
        var languageName = new Label();
        Add(languageName);
        languageName.text = langName;
        languageName.name = "name";
        languageName.AddClasses("text-first");
    }
}
