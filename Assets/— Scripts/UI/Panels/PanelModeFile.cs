using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PanelModeFile : VisualElement
{
    public new class UxmlFactory : UxmlFactory<PanelModeFile> { }

    Translation textModeName, textScoreName;

    LabelWithTranslation modeName;
    Button buttonInfo;
    Label scoreBest; 
    LabelWithTranslation scoreText;
    Button buttonPlay;

    public static Action<PuzzleMode> OnInfoClicked;
    public static Action<PuzzleMode> OnPlayClicked;

    public PanelModeFile()
    {
        name = "panel-mode";
        this.AddClasses("background-first");

        #region header

        var header = new VisualElement();
        header.AddToClassList("background-second");
        header.name = "header";
        Add(header);

        modeName = new LabelWithTranslation();
        modeName.AddClasses("text-second");
        modeName.name = "mode-name";
        modeName.text = "[mode name]";
        header.Add(modeName);

        buttonInfo = new Button();
        buttonInfo.AddClasses("button-second");
        buttonInfo.name = "button-info";
        buttonInfo.text = "";
        header.Add(buttonInfo);

        var buttonInfoLabel = new Label();
        buttonInfoLabel.AddClasses("text-second");
        buttonInfoLabel.name = "button-info-label";
        buttonInfoLabel.text = "?";
        buttonInfo.Add(buttonInfoLabel);

        #endregion

        #region main

        var main = new VisualElement();
        main.name = "main";
        Add(main);

        var score = new VisualElement();
        score.name = "score";
        main.Add(score);

        scoreBest = new Label();
        scoreBest.AddClasses("text-first");
        scoreBest.name = "score-best";
        scoreBest.text = "[0]";
        score.Add(scoreBest);

        scoreText = new  LabelWithTranslation();
        scoreText.AddClasses("text-second");
        scoreText.name = "score-text";
        scoreText.text = "[Best score]";
        score.Add(scoreText);

        buttonPlay = new Button();
        main.Add(buttonPlay);
        buttonPlay.name = "button-play";
        var iconPlay = new VisualElement();
        buttonPlay.Add(iconPlay);
        iconPlay.name = "icon-play";
        var labelPlay = new LabelWithTranslation(new Translation("Start", "Старт"));
        buttonPlay.Add(labelPlay);
        labelPlay.AddClasses("text-first");

        #endregion
    }

    public void Setup(PuzzleMode mode)
    {
        modeName.SetTranslation(mode.Name);
        scoreBest.text = $"{mode.GetProgressValue()}";
        scoreText.SetTranslation(mode.TextScore);
        buttonInfo.RegisterCallback((ClickEvent click) =>
        {
            OnInfoClicked?.Invoke(mode);
        });
        buttonPlay.RegisterCallback((ClickEvent click) =>
        {
            OnPlayClicked?.Invoke(mode);
            Debug.Log("play clicked with mode: " + mode.Name.Text);
        });
    }
}
