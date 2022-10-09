using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelMenu : PanelBase
{
    Button buttonPreviousMode, buttonNextMode = null;
    VisualElement modePanels = null;
    //[SerializeField, Required] PanelMode panelModeDocument;
    [SerializeField, ReadOnly] PanelMode panelModeCurrent;
    SliderInt sliderModes;
    Button buttonPlay, buttonShop, buttonSettings, buttonQuit = null;
    const float panelSpawnOffset = 5;
    const float timeChangePanel = 0.3f;

    public static Action OnSettingsClicked, OnPlayClicked, OnShopClicked, OnQuitClicked;
    public static Action<int> OnSliderModesDrag;

    protected override void Awake()
    {
        base.Awake();

        PuzzleModes.OnPuzzleModeChanged += SetPanelMode;

        modePanels = document.rootVisualElement.Q<VisualElement>("mode-panels");
        buttonPlay = document.rootVisualElement.Q<Button>("button-play");
        buttonPlay.RegisterCallback(delegate (ClickEvent click)
        {
            Hide();
        }, TrickleDown.TrickleDown);
        sliderModes = document.rootVisualElement.Q<SliderInt>("slider-modes");
        sliderModes.highValue = PuzzleModes.ListPuzzleModes.Count - 1;
        sliderModes.value = 0;
        sliderModes.RegisterValueChangedCallback((evt) =>
        {
            OnSliderModesDrag?.Invoke(evt.newValue);
        });
    }

    void SetPanelMode(PuzzleMode newMode, int indexPrev, int indexNew)
    {
        if (panelModeCurrent != null)
        {
            panelModeCurrent.RemoveFromHierarchy();
        }
        var panelMode = new PanelMode();
        panelMode.Setup(newMode);
        panelModeCurrent = panelMode;
        modePanels.Add(panelMode);
    }
}
