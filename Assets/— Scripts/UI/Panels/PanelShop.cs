using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelShop : PanelBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}

public class PanelShopFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelShopFile> { }

    VisualElement buttonsThemes;

    public PanelShopFile()
    {
        PanelMenuFile.OnShopClicked += () => {
            Translate(this, new Vector2(0, 0), new Vector2(0, 3000));
        };
        SaveSystem.OnAppStarted += () => {
            TranslateInstantly(this, new Vector2(0, 3000));
        };

        ThemedButtonSecond buttonBack = new();
        Add(buttonBack);
        buttonBack.name = "button-back";
        buttonBack.RegisterCallback((ClickEvent click) => {
            Translate(this, new Vector2(0, 3000));
            Back();
        });
        ThemedIconSecond iconBack = new();
        buttonBack.Add(iconBack);
        iconBack.name = "icon-back";

        ThemedLabelSecond labelThemes = new(new Translation("Buy themes", "Купите темы"));
        Add(labelThemes);
        labelThemes.AddClasses("title");

        buttonsThemes = new();
        Add(buttonsThemes);
        buttonsThemes.name = "buttons-themes";
        foreach (var profile in Themes.ListThemes) {
            ButtonTheme buttonTheme = new(profile);
            buttonsThemes.Add(buttonTheme);
        }
    }
}

public class ButtonTheme : Button {
    public new class UxmlFactory : UxmlFactory<ButtonTheme> { }

    ThemeProfile profile;

    public static Action<ThemeProfile> OnBuyThemeClicked, OnSelectThemeClicked;

    public ButtonTheme() { }
    public ButtonTheme(ThemeProfile profile) {
        Themes.OnThemeChanged += (ThemeProfile profile) => {
            Clear();
            Setup(this.profile);
        };
        Balance.OnItemBought += (PurchasableItem boughtItem) => {
            if (boughtItem is ThemeProfile) {
                Clear();
                Setup(this.profile);
            }
        };

        RegisterCallback((ClickEvent click) => {
            if (!profile.IfBought) {
                OnBuyThemeClicked?.Invoke(profile);
                return;
            }
            if (profile.IfBought) {
                if (!profile.IfSelected) {
                    OnSelectThemeClicked?.Invoke(profile);
                }
                else {
                    Debug.LogWarning("THEME ALREADY SELECTED");
                }
            }
        });
        Setup(profile);
    }

    void Setup(ThemeProfile profile) {
        this.profile = profile;

        this.AddClasses("button-theme");
        style.backgroundImage = profile.Theme.BackgroundImage.texture;
        style.borderTopColor = profile.Theme.ShopColor;
        style.borderRightColor = profile.Theme.ShopColor;
        style.borderBottomColor = profile.Theme.ShopColor;
        style.borderLeftColor = profile.Theme.ShopColor;

        #region details;

        VisualElement details = new();
        Add(details);
        details.name = "details";

        VisualElement boxColor = new();
        details.Add(boxColor);
        boxColor.name = "box-color";
        boxColor.style.backgroundColor = profile.Theme.ShopColor;

        ThemedLabelFirst name = new(profile.Theme.Name);
        details.Add(name);
        name.name = "name";
        name.DisableTheme();
        name.style.color = profile.Theme.LabelZero;

        if (!profile.IfBought) {
            VisualElement iconBlocked = new();
            boxColor.Add(iconBlocked);
            iconBlocked.name = "icon-blocked";
            iconBlocked.style.unityBackgroundImageTintColor = profile.Theme.LabelZero;
        }

        #endregion

        #region state

        VisualElement state = new();
        Add(state);
        state.name = "state";
        state.AddClasses(profile.IfBought ? "bought" : "not-bought", profile.IfSelected ? "selected" : "not-selected");

        if (!profile.IfBought) {
            VisualElement price = new();
            state.Add(price);
            price.name = "price";

            VisualElement iconPrice = new();
            price.Add(iconPrice);
            iconPrice.name = "icon-price";

            ThemedLabelFirst labelPrice = new($"{profile.Price}");
            price.Add(labelPrice);
            labelPrice.DisableTheme();
            labelPrice.name = "label-price";

            ThemedLabelFirst labelBuy = new(new Translation("Buy", "Купить"));
            state.Add(labelBuy);
            labelBuy.DisableTheme();
            labelBuy.name = "label-buy";
        }

        if (profile.IfBought) {
            if (!profile.IfSelected) {
                ThemedLabelFirst labelSelect = new(new Translation("Select", "Выбрать"));
                state.Add(labelSelect);
                labelSelect.DisableTheme();
                labelSelect.name = "label-select";
            }
            if (profile.IfSelected) {
                VisualElement iconSelected = new();
                state.Add(iconSelected);
                iconSelected.name = "icon-selected";
            }
        }


        #endregion
    }
}
