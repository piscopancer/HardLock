using System;
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
    VisualElement modeContainer;

    public static Action OnSettingsClicked, OnPlayClicked, OnShopClicked, OnQuitClicked;
    public static Action OnPrevModeClicked, OnNextModeClicked;

    public PanelMenuFile()
    {
        PuzzleModes.OnPuzzleModeChanged += SetPanelMode;
        OnBack += (PanelFileBase panel) =>
        {
            if (panel is PanelSettingsFile || panel is PanelShopFile)
            {
                this.Translate(new Vector2(0, 0));
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

        var crystalCount = new ThemedLabelFirst($"{Balance.Coins}");
        crystals.Add(crystalCount);

        #endregion;

        #region modes;

        var modes = new VisualElement();
        Add(modes);
        modes.name = "modes";

        modeContainer = new VisualElement();
        modes.Add(modeContainer);
        modeContainer.name = "mode-container";

        var buttonsMode = new VisualElement();
        modes.Add(buttonsMode);
        buttonsMode.pickingMode = PickingMode.Ignore;
        buttonsMode.name = "buttons-mode";

        var buttonPrevMode = new ThemedButtonFirst();
        buttonsMode.Add(buttonPrevMode);
        buttonPrevMode.text = "";
        buttonPrevMode.AddClasses("button-mode");
        buttonPrevMode.name = "button-prev-mode";
        var iconPrev = new ThemedIconFirst();
        buttonPrevMode.Add(iconPrev);
        iconPrev.name = "icon-prev";
        iconPrev.AddClasses("icon");

        var buttonPlay = new ThemedButtonFirst();
        buttonsMode.Add(buttonPlay);
        buttonPlay.name = "button-play";
        buttonPlay.RegisterCallback((ClickEvent click) => {
            OnPlayClicked?.Invoke();
        });
        var iconPlay = new ThemedIconFirst();
        buttonPlay.Add(iconPlay);
        iconPlay.name = "icon-play";
        var labelPlay = new ThemedLabelFirst(new Translation("Start", "Старт"));
        buttonPlay.Add(labelPlay);

        var buttonNextMode = new ThemedButtonFirst();
        buttonsMode.Add(buttonNextMode);
        buttonNextMode.text = "";
        buttonNextMode.AddClasses("button-mode");
        buttonNextMode.name = "button-next-mode";
        var iconNext = new ThemedIconFirst();
        buttonNextMode.Add(iconNext);
        iconNext.name = "icon-next";
        iconNext.AddClasses("icon");

        #endregion;

        #region buttons;

        VisualElement buttons = new();
        Add(buttons);
        buttons.name = "buttons";

        ThemedButtonZero buttonShop = new();
        buttons.Add(buttonShop);
        buttonShop.RegisterCallback((ClickEvent click) =>
        {
            this.Translate(new Vector2(0, -3000));
            OnShopClicked?.Invoke();
        });
        buttonShop.name = "button-shop";
        buttonShop.AddClasses("button-zero");
        ThemedIconFirst iconShop = new();
        buttonShop.Add(iconShop);
        iconShop.name = "icon-shop";
        ThemedLabelZero labelShop = new(new Translation("Shop", "Магазин"));
        buttonShop.Add(labelShop);
        labelShop.name = "label-shop";

        VisualElement buttonsBottom = new();
        buttons.Add(buttonsBottom);
        buttonsBottom.name = "buttons-bottom";

        Button buttonSettings = new();
        buttonsBottom.Add(buttonSettings);
        buttonSettings.RegisterCallback((ClickEvent click) =>
        {
            OnSettingsClicked?.Invoke();
            this.Translate(new Vector2(3000, 0));
        });
        buttonSettings.name = "button-settings";
        ThemedIconFirst buttonSettingsIcon = new();
        buttonSettings.Add(buttonSettingsIcon);
        buttonSettingsIcon.name = "icon-settings";
        buttonSettingsIcon.AddClasses("icon");

        Button buttonQuit = new();
        buttonsBottom.Add(buttonQuit);
        buttonQuit.RegisterCallback((ClickEvent click) =>
        {
            OnQuitClicked?.Invoke();
        });
        buttonQuit.name = "button-quit";
        ThemedIconFirst buttonExitIcon = new();
        buttonQuit.Add(buttonExitIcon);
        buttonExitIcon.name = "icon-quit";
        buttonExitIcon.AddClasses("icon");

        #endregion;

        Balance.OnNewBalance += (int balance) => {
            crystalCount.text = $"{balance}";
        };
    }

    void SetPanelMode(PuzzleMode newMode, int indexPrev, int indexNew)
    {
        if (panelModeCurrent != null)
        {
            panelModeCurrent.RemoveFromHierarchy();
        }
        var panelMode = new PanelModeFile(newMode);
        panelModeCurrent = panelMode;
        modeContainer.Add(panelMode);
    }
}
