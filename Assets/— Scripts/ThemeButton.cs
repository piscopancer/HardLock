using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;
using System;

[RequireComponent(typeof(Button))]
public class ThemeButton : MonoBehaviour
{
    [SerializeField, ReadOnly] ThemeProfile theme;
    [SerializeField] GameObject PriceHolder, SelectionBox;
    [SerializeField] Image ColorImage;
    //[SerializeField] TextMeshProUGUI NameText, PriceText;
    delegate void delegateClick();
    delegateClick click;

    public static Action<ThemeProfile> OnThemeSelect;
    public static Action<PurchasableItemPermanent> OnThemeBuy;

    void Awake()
    {
        Themes.OnThemeChanged += CheckIfSelected;

        GetComponent<Button>().onClick.AddListener(delegate { 
            TryBuySelectTheme(); 
        });
    }

    public void Setup(ThemeProfile theme)
    {
        this.theme = theme;
        PriceHolder.SetActive(!theme.IfBought);
        //PriceText.text = theme.Price.ToString();
        SelectionBox.SetActive(theme.IfSelected);
        ColorImage.color = theme.ColorShop;
        //NameText.text = theme.ThemeData.name;
    }

    void TryBuySelectTheme()
    {
        click = theme.IfBought ? SelectTheme : BuyTheme;
        click();
        Setup(theme);
    }

    void BuyTheme()
    {
        if (Balance.CheckCanBuy(theme.Price))
        {
            OnThemeBuy?.Invoke(theme);
        }
        else
        {
            //out of cash
        }
    }

    void SelectTheme()
    {
        OnThemeSelect?.Invoke(theme);
    }

    void CheckIfSelected(ThemeProfile theme)
    {
        SelectionBox.SetActive(this.theme == theme);
    }
}
