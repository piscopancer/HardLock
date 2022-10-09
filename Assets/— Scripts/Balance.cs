using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Balance : MonoBehaviour
{
    [SerializeField, ReadOnly] int coins = 100;

    public static Action<int, int> OnBalanceChanged;
    public static Action<PurchasableItem> OnItemBought;

    void Awake()
    {
        ThemeButton.OnThemeBuy += BuyItem;
    }

    void BuyItem(PurchasableItem purchItem)
    {
        if (purchItem is PurchasableItemConsumable)
        {
            var item = (PurchasableItemConsumable)purchItem;
            item.Count += 1;
        }
        if (purchItem is PurchasableItemPermanent)
        {
            var item = (PurchasableItemPermanent)purchItem;
            item.IfBought = true;
        }
        ChangeCoins(-purchItem.Price);
        OnItemBought?.Invoke(purchItem);
    }

    static void ChangeCoins(int by)
    {
        var balance = FindObjectOfType<Balance>();
        balance.coins += by;
        OnBalanceChanged?.Invoke(balance.coins, by);
    }

    public static bool CheckCanBuy(int price)
    {
        return FindObjectOfType<Balance>().coins >= price;
    }
}

public interface PurchasableItemConsumable : PurchasableItem
{
    int Count { get; set; }
}

public interface PurchasableItemPermanent : PurchasableItem
{
    bool IfBought { get; set; }
}

public interface PurchasableItem
{
    int Price { get; set; }
}
