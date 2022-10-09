using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelModeDescription : PanelBase
{
    Button buttonOK;
    Label labelDescription, labelModeDescription;

    public static Action OnOKClicked;

    protected override void Awake()
    {
        base.Awake();

        PanelMode.OnInfoClicked += (PuzzleMode mode) =>
        {
            Show();
            Setup(mode);
        };

        buttonOK = document.rootVisualElement.Q<Button>("button-ok");
        buttonOK.RegisterCallback((ClickEvent click) =>
        {
            OnOKClicked?.Invoke();
            Hide();
        });
        labelDescription = document.rootVisualElement.Q<Label>("description");
        labelDescription.text = "";
        labelModeDescription = document.rootVisualElement.Q<Label>("mode-description");
        labelModeDescription.text = "";
    }

    public void Setup(PuzzleMode mode)
    {
        labelDescription.text = mode.Name.Text;
        labelModeDescription.text = mode.Description.Text;
    }
}
