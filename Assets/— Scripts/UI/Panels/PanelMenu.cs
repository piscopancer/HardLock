using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelMenu : PanelBase
{
    //SliderInt sliderModes;
    //Button buttonPlay, buttonShop, buttonSettings, buttonQuit = null;
    [SerializeField, Required, InlineEditor] Translation textPlay, textShop, textSettings, textQuit;
    //LabelWithTranslation labelPlay, labelShop, labelSettings, labelQuit;



    protected override void Awake()
    {
        base.Awake();

        

        //modePanels = Document.rootVisualElement.Q<VisualElement>("mode-panels");
        //buttonPlay = Document.rootVisualElement.Q<Button>("button-play");
        //buttonPlay.RegisterCallback((ClickEvent click) =>
        //{
        //    OnPlayClicked?.Invoke();
        //});
        //labelPlay = Document.rootVisualElement.Q<LabelWithTranslation>("label-play");
        //labelPlay.SetTranslation(textPlay);
        //buttonSettings = Document.rootVisualElement.Q<Button>("button-settings");
        //buttonSettings.RegisterCallback((ClickEvent click) =>
        //{
        //    OnSettingsClicked?.Invoke();
        //    Translate(Document.rootVisualElement, new Vector2(3000, 0));
        //});
        //labelSettings = Document.rootVisualElement.Q<LabelWithTranslation>("label-settings");
        //labelSettings.SetTranslation(textSettings);
        //buttonShop = Document.rootVisualElement.Q<Button>("button-shop");
        //buttonShop.RegisterCallback((ClickEvent click) =>
        //{
        //    OnShopClicked?.Invoke();
        //    Translate(Document.rootVisualElement, new Vector2(0, -3000));
        //});
        //labelShop = Document.rootVisualElement.Q<LabelWithTranslation>("label-shop");
        //labelShop.SetTranslation(textShop);
        //buttonQuit = Document.rootVisualElement.Q<Button>("button-quit");
        //buttonQuit.RegisterCallback((ClickEvent click) =>
        //{
        //    OnQuitClicked?.Invoke();
        //});
        //labelQuit = Document.rootVisualElement.Q<LabelWithTranslation>("label-quit");
        //labelQuit.SetTranslation(textQuit);
        //sliderModes = Document.rootVisualElement.Q<SliderInt>("slider-modes");
        //sliderModes.highValue = PuzzleModes.ListPuzzleModes.Count - 1;
        //sliderModes.value = 0;
        //sliderModes.RegisterValueChangedCallback((evt) =>
        //{
        //    OnSliderModesDrag?.Invoke(evt.newValue);
        //});
    }


}

public class PanelMenuFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelMenuFile> { }

    [SerializeField, ReadOnly] PanelMode panelModeCurrent;
    VisualElement panelModeContainer;

    public static Action OnSettingsClicked, OnPlayClicked, OnShopClicked, OnQuitClicked;
    public static Action OnPrevModeClicked, OnNextModeClicked;

    public PanelMenuFile()
    {
        PuzzleModes.OnPuzzleModeChanged += SetPanelMode;
        PanelMode.OnInfoClicked += (PuzzleMode mode) =>
        {
            Hide();
        };
        OnHide += (PanelFileBase panel) =>
        {
            if (panel is PanelModeDescriptionFile)
            {
                Translate(this, new Vector2(0, 0));
            }
        };
        OnBack += (PanelFileBase panel) =>
        {
            if (panel is PanelSettingsFile || panel is PanelShopFile)
            {
                Translate(this, new Vector2(0, 0));
            }
        };

        name = "panel";

        #region balance;

        var balance = new VisualElement();
        Add(balance);

        var crystals = new VisualElement();
        balance.Add(crystals);

        var crystalIcon = new VisualElement();
        crystalIcon.AddClasses("icon-crystal");
        crystals.Add(crystalIcon);

        var crystalCount = new Label("0");
        crystals.Add(crystalCount);

        #endregion;

        #region modes;

        var modes = new VisualElement();
        Add(modes);

        panelModeContainer = new VisualElement();
        panelModeContainer.AddClasses("panel-mode-container");
        modes.Add(panelModeContainer);

        var buttonsMode = new VisualElement();
        buttonsMode.name = "buttons-mode";
        modes.Add(buttonsMode);

        var buttonPrevMode = new Button();
        buttonPrevMode.text = "";
        buttonPrevMode.AddClasses("button-mode", "button-mode-left");
        buttonsMode.Add(buttonPrevMode);

        var buttonNextMode = new Button();
        buttonNextMode.text = "";
        buttonNextMode.AddClasses("button-mode", "button-mode-left");
        buttonsMode.Add(buttonNextMode);

        #endregion;

        #region buttons;

        var buttons = new VisualElement();
        Add(buttons);

        var buttonShop = new Button();
        buttonShop.name = "button-shop";
        buttons.Add(buttonShop);

        var buttonsBottom = new VisualElement();
        buttons.Add(buttonsBottom);

        var buttonSettings = new Button();
        buttonSettings.name = "button";
        buttonsBottom.Add(buttonSettings);
        var buttonSettingsIcon = new VisualElement();
        buttonSettingsIcon.AddClasses("button-icon");
        buttonSettings.Add(buttonSettingsIcon);

        var buttonExit = new Button();
        buttonExit.name = "button";
        buttonsBottom.Add(buttonExit);
        var buttonExitIcon = new VisualElement();
        buttonExitIcon.AddClasses("button-icon");
        buttonExit.Add(buttonExitIcon);

        #endregion;
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
        panelModeContainer.Add(panelMode);
    }
}
