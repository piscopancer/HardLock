using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelMenu : PanelBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}

public class PanelMenuFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelMenuFile> { }

    [SerializeField, ReadOnly] PanelModeFile panelModeCurrent;
    VisualElement panelModeContainer;

    public static Action OnSettingsClicked, OnPlayClicked, OnShopClicked, OnQuitClicked;
    public static Action OnPrevModeClicked, OnNextModeClicked;

    public PanelMenuFile()
    {
        PuzzleModes.OnPuzzleModeChanged += SetPanelMode;
        PanelModeFile.OnInfoClicked += (PuzzleMode mode) =>
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

        #region balance;

        var balance = new VisualElement();
        balance.name = "balance";
        Add(balance);

        var crystals = new VisualElement();
        crystals.name = "crystals";
        balance.Add(crystals);

        var crystalIcon = new VisualElement();
        crystalIcon.name = "icon-crystal";
        crystals.Add(crystalIcon);

        var crystalCount = new Label("0");
        crystals.Add(crystalCount);
        crystalCount.AddClasses(textFirst);

        #endregion;

        #region modes;

        var modes = new VisualElement();
        Add(modes);
        modes.name = "modes";

        panelModeContainer = new VisualElement();
        modes.Add(panelModeContainer);
        panelModeContainer.name = "panel-mode-container";
        //var mp = new PanelModeFile();
        //panelModeContainer.Add(mp);

        var buttonsMode = new VisualElement();
        modes.Add(buttonsMode);
        buttonsMode.pickingMode = PickingMode.Ignore;
        buttonsMode.name = "buttons-mode";

        var buttonPrevMode = new Button();
        buttonsMode.Add(buttonPrevMode);
        buttonPrevMode.text = "";
        buttonPrevMode.AddClasses("button-mode", buttonSecond);
        buttonPrevMode.name = "button-prev-mode";
        var iconPrev = new VisualElement();
        buttonPrevMode.Add(iconPrev);
        iconPrev.name = "icon-prev";
        iconPrev.AddClasses("icon");

        var buttonNextMode = new Button();
        buttonsMode.Add(buttonNextMode);
        buttonNextMode.text = "";
        buttonNextMode.AddClasses("button-mode", buttonSecond);
        buttonNextMode.name = "button-next-mode";
        var iconNext = new VisualElement();
        buttonNextMode.Add(iconNext);
        iconNext.name = "icon-next";
        iconNext.AddClasses("icon");


        #endregion;

        #region buttons;

        var buttons = new VisualElement();
        Add(buttons);
        buttons.name = "buttons";

        var buttonShop = new Button();
        buttons.Add(buttonShop);
        buttonShop.RegisterCallback((ClickEvent click) =>
        {
            OnShopClicked?.Invoke();
        });
        buttonShop.name = "button-shop";
        var iconShop = new VisualElement();
        buttonShop.Add(iconShop);
        iconShop.name = "icon-shop";
        var labelShop = new LabelWithTranslation(new Translation("Shop", "Магазин"));
        buttonShop.Add(labelShop);
        labelShop.AddClasses(textFirst);
        labelShop.name = "label-shop";

        var buttonsBottom = new VisualElement();
        buttons.Add(buttonsBottom);
        buttonsBottom.name = "buttons-bottom";

        var buttonSettings = new Button();
        buttonsBottom.Add(buttonSettings);
        buttonSettings.RegisterCallback((ClickEvent click) =>
        {
            OnSettingsClicked?.Invoke();
        });
        buttonSettings.name = "button-settings";
        var buttonSettingsIcon = new VisualElement();
        buttonSettings.Add(buttonSettingsIcon);
        buttonSettingsIcon.name = "icon-settings";
        buttonSettingsIcon.AddClasses("icon");

        var buttonQuit = new Button();
        buttonsBottom.Add(buttonQuit);
        buttonQuit.RegisterCallback((ClickEvent click) =>
        {
            OnQuitClicked?.Invoke();
        });
        buttonQuit.name = "button-quit";
        var buttonExitIcon = new VisualElement();
        buttonQuit.Add(buttonExitIcon);
        buttonExitIcon.name = "icon-quit";
        buttonExitIcon.AddClasses("icon");

        #endregion;
    }

    void SetPanelMode(PuzzleMode newMode, int indexPrev, int indexNew)
    {
        if (panelModeCurrent != null)
        {
            panelModeCurrent.RemoveFromHierarchy();
        }
        var panelMode = new PanelModeFile();
        panelMode.Setup(newMode);
        panelModeCurrent = panelMode;
        panelModeContainer.Add(panelMode);
    }
}
