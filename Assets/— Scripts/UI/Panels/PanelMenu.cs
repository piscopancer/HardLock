using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelMenu : PanelBase
{
    VisualElement modePanels = null;
    [SerializeField, ReadOnly] PanelMode panelModeCurrent;
    SliderInt sliderModes;
    Button buttonPlay, buttonShop, buttonSettings, buttonQuit = null;
    [SerializeField, Required, InlineEditor] Translation textPlay, textShop, textSettings, textQuit;
    LabelWithTranslation labelPlay, labelShop, labelSettings, labelQuit;

    const float panelSpawnOffset = 5;
    const float timeChangePanel = 0.3f;

    public static Action OnSettingsClicked, OnPlayClicked, OnShopClicked, OnQuitClicked;
    public static Action<int> OnSliderModesDrag;

    protected override void Awake()
    {
        base.Awake();

        PuzzleModes.OnPuzzleModeChanged += SetPanelMode;
        PanelMode.OnInfoClicked += (PuzzleMode mode) =>
        {
            Hide();
        };
        OnHide += (PanelBase panel) =>
        {
            if (panel is PanelModeDescription || panel is PanelSettings) 
            {
                Show();
            }
        };

        modePanels = document.rootVisualElement.Q<VisualElement>("mode-panels");
        buttonPlay = document.rootVisualElement.Q<Button>("button-play");
        buttonPlay.RegisterCallback((ClickEvent click) =>
        {
            OnPlayClicked?.Invoke();
        });
        labelPlay = document.rootVisualElement.Q<LabelWithTranslation>("label-play");
        labelPlay.SetTranslation(textPlay);
        buttonSettings = document.rootVisualElement.Q<Button>("button-settings");
        buttonSettings.RegisterCallback((ClickEvent click) =>
        {
            OnSettingsClicked?.Invoke();
        });
        labelSettings = document.rootVisualElement.Q<LabelWithTranslation>("label-settings");
        labelSettings.SetTranslation(textSettings);
        buttonShop = document.rootVisualElement.Q<Button>("button-settings");
        buttonShop.RegisterCallback((ClickEvent click) =>
        {
            OnShopClicked?.Invoke();
        });
        labelShop = document.rootVisualElement.Q<LabelWithTranslation>("label-shop");
        labelShop.SetTranslation(textShop);
        buttonQuit = document.rootVisualElement.Q<Button>("button-quit");
        buttonQuit.RegisterCallback((ClickEvent click) =>
        {
            OnQuitClicked?.Invoke();
        });
        labelQuit = document.rootVisualElement.Q<LabelWithTranslation>("label-quit");
        labelQuit.SetTranslation(textQuit);
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
