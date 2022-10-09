using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using TriInspector;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(UIDocument))]
public class PanelBase : MonoBehaviour
{
    [SerializeField, Required] protected UIDocument document;

    const float TIME_FADE = 0.2f;
    
    public static Action<PanelBase> OnShow, OnHide;

    protected virtual void Awake()
    {

    }

    public async void Hide()
    {
        await FadeHide();
        document.rootVisualElement.style.display = DisplayStyle.None;
        OnHide?.Invoke(this);
    }

    public async void Show()
    {
        document.rootVisualElement.style.display = DisplayStyle.Flex;
        await FadeShow();
        OnShow?.Invoke(this);
    }

    async UniTask FadeShow()
    {
        float t = 0;
        while (t < TIME_FADE)
        {
            t += Time.deltaTime;
            document.rootVisualElement.style.opacity = t;
            await UniTask.Yield();
        }
    }

    async UniTask FadeHide()
    {
        float t = TIME_FADE;
        while (t > 0)
        {
            t -= Time.deltaTime;
            document.rootVisualElement.style.opacity = t;
            await UniTask.Yield();
        }
    }
}
