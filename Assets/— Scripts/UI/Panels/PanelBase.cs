using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using TriInspector;
using Cysharp.Threading.Tasks;
using UnityEditorInternal;

[RequireComponent(typeof(UIDocument))]
public class PanelBase : MonoBehaviour
{
    [SerializeField, Required] protected UIDocument document;
    [SerializeField] bool isActiveOnStart = false;

    const float TIME_FADE = 0.1f;
    
    public static Action<PanelBase> OnShow, OnHide;

    protected virtual void Awake()
    {
        document.rootVisualElement.style.display = isActiveOnStart ? DisplayStyle.Flex : DisplayStyle.None;
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
        while (t < 1)
        {
            t += Time.deltaTime / TIME_FADE;
            document.rootVisualElement.style.opacity = t;
            await UniTask.Yield();
        }
    }

    async UniTask FadeHide()
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime / TIME_FADE;
            document.rootVisualElement.style.opacity = t;
            await UniTask.Yield();
        }
    }
}
