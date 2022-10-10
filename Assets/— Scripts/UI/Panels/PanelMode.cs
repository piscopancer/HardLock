using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PanelMode : VisualElement
{
    public new class UxmlFactory : UxmlFactory<PanelMode> { }

    Translation textModeName, textScoreName;

    LabelWithTranslation modeName;
    Button buttonInfo;
    Label scoreBest; 
    LabelWithTranslation scoreText;

    public static Action<PuzzleMode> OnInfoClicked;

    public PanelMode()
    {
        AddToClassList("panel-mode");

        var header = new VisualElement();
        header.AddToClassList("header");
        header.name = "header";
        Add(header);

        modeName = new LabelWithTranslation();
        modeName.AddToClassList("mode-name");
        modeName.name = "mode-name";
        modeName.text = "mode";
        header.Add(modeName);

        buttonInfo = new Button();
        buttonInfo.AddToClassList("button-info");
        buttonInfo.name = "button-info";
        buttonInfo.text = "";
        header.Add(buttonInfo);

        var buttonInfoLabel = new Label();
        buttonInfoLabel.AddToClassList("button-info-label");
        buttonInfoLabel.name = "button-info-label";
        buttonInfoLabel.text = "?";
        buttonInfo.Add(buttonInfoLabel);



        var main = new VisualElement();
        main.AddToClassList("main");
        main.name = "main";
        Add(main);

        var score = new VisualElement();
        score.AddToClassList("score");
        score.name = "score";
        main.Add(score);

        scoreBest = new Label();
        scoreBest.AddToClassList("score-best");
        scoreBest.name = "score-best";
        scoreBest.text = "0";
        score.Add(scoreBest);

        scoreText = new  LabelWithTranslation();
        scoreText.AddToClassList("score-text");
        scoreText.name = "score-text";
        scoreText.text = "Best score";
        score.Add(scoreText);
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
    }
}
