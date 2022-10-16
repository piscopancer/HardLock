using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Balance : MonoBehaviour
{
    static int coins = 100;

    public static Action<int> OnNewBalance, OnMoneySpent;
    public static Action<PurchasableItem> OnItemBought;

    void Awake()
    {
        ButtonTheme.OnBuyThemeClicked += TryBuyItem;
    }

    void TryBuyItem(PurchasableItem purchItem) {
        if (coins >= purchItem.Price) {
            BuyItem(purchItem);
        }
        else {
            Debug.Log("not enough money");
        }
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
            if (item.IfBought) {
                Debug.LogError("item is already bought");
            }
            item.IfBought = true;
        }
        ChangeCoins(-purchItem.Price);
        OnItemBought?.Invoke(purchItem);
    }

    void ChangeCoins(int by)
    {
        coins += by;
        OnNewBalance?.Invoke(coins);
        OnMoneySpent?.Invoke(by);
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
