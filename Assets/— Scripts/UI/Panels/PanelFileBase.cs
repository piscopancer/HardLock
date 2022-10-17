using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class PanelFileBase : VisualElement
{
    public static Action<PanelFileBase> OnShow, OnHide, OnBack;

    public PanelFileBase() {

    }

    public async void Hide()
    {
        parent.style.display = DisplayStyle.None;
        OnHide?.Invoke(this);
        await UniTask.Yield();
    }

    public void Show()
    {
        parent.style.display = DisplayStyle.Flex;
        OnShow?.Invoke(this);
    }

    public virtual void Back()
    {
        OnBack?.Invoke(this);
    }


}
