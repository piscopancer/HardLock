using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Balance
{
    public static int Coins { get; private set; } = 1000;

    public static Action<int> OnNewBalance, OnMoneySpent;
    public static Action<PurchasableItem> OnItemBought;

    static Balance()
    {
        ButtonTheme.OnBuyThemeClicked += TryBuyItem;
    }

    static void TryBuyItem(PurchasableItem purchItem) {
        if (Coins >= purchItem.Price) {
            BuyItem(purchItem);
        }
        else {
            Debug.Log("not enough money");
        }
    }

    static void BuyItem(PurchasableItem purchItem) {
        if (purchItem is PurchasableItemConsumable) {
            var item = (PurchasableItemConsumable)purchItem;
            item.Count += 1;
        }
        if (purchItem is PurchasableItemPermanent) {
            var item = (PurchasableItemPermanent)purchItem;
            if (item.IfBought) {
                Debug.LogError("item is already bought");
            }
            item.IfBought = true;
        }
        Coins += -purchItem.Price;
        OnNewBalance?.Invoke(Coins);
        OnMoneySpent?.Invoke(-purchItem.Price);
        OnItemBought?.Invoke(purchItem);
    }
}

public interface PurchasableItemConsumable : PurchasableItem {
    int Count { get; set; }
}

public interface PurchasableItemPermanent : PurchasableItem {
    bool IfBought { get; set; }
}

public interface PurchasableItem {
    int Price { get; set; }
}
