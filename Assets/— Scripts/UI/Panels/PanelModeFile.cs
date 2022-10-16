using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PanelModeFile : VisualElement
{
    public new class UxmlFactory : UxmlFactory<PanelModeFile> { }

    ThemedLabel modeName;
    Button buttonInfo;
    Label scoreBest; 
    ThemedLabel scoreText;

    public static Action<PuzzleMode> OnInfoClicked;

    public PanelModeFile() { }
    public PanelModeFile(PuzzleMode mode) {
        name = "panel-mode";

        #region header

        var header = new ThemedContainerFirst();
        header.name = "header";
        Add(header);

        modeName = new ThemedLabelZero(mode.Name);
        modeName.name = "mode-name";
        header.Add(modeName);

        buttonInfo = new ThemedButtonSecond();
        header.Add(buttonInfo);
        buttonInfo.name = "button-info";
        buttonInfo.text = "";
        buttonInfo.RegisterCallback((ClickEvent click) => {
            OnInfoClicked?.Invoke(mode);
        });

        var buttonInfoLabel = new ThemedLabelSecond();
        buttonInfoLabel.name = "button-info-label";
        buttonInfoLabel.text = "?";
        buttonInfo.Add(buttonInfoLabel);

        #endregion

        #region main

        var main = new ThemedContainerSecond();
        main.name = "main";
        Add(main);

        var score = new VisualElement();
        score.name = "score";
        main.Add(score);

        scoreBest = new ThemedLabelFirst($"{mode.GetProgressValue()}");
        scoreBest.name = "score-best";
        score.Add(scoreBest);

        scoreText = new ThemedLabelSecond(mode.TextScore);
        scoreText.name = "score-text";
        score.Add(scoreText);

        #endregion


    }
}
