using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PanelPuzzleMode : PanelBase
{
    PuzzleMode puzzleMode;
    [SerializeField, Required] TextWithTranslation textName, textNameScore;
    //[SerializeField, Required] TextMeshProUGUI textScore;
    [SerializeField, Required] Button buttonDescription;

    public static Action<PuzzleMode> OnDescriptionClicked;

    protected override void Awake()
    {
        base.Awake();
        buttonDescription.onClick.AddListener(delegate
        {
            OnDescriptionClicked?.Invoke(puzzleMode);
        });  
    }

    public void Setup(PuzzleMode puzzleMode)
    {
        this.puzzleMode = puzzleMode;
        textName.SetText(puzzleMode.Name);
        textNameScore.SetText(puzzleMode.TextScore);
        //textScore.text = puzzleMode.GetProgressValue().ToString();
    }
}
