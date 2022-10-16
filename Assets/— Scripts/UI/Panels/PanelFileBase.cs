using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class PanelFileBase : VisualElement
{
    const float TIME_FADE = 0.1f;

    public static Action<PanelFileBase> OnShow, OnHide, OnBack;

    public PanelFileBase() {

    }

    public void Hide()
    {
        parent.style.display = DisplayStyle.None;
        OnHide?.Invoke(this);
    }

    public void Show()
    {
        parent.style.display = DisplayStyle.Flex;
        OnShow?.Invoke(this);
    }

    public void Back()
    {
        OnBack?.Invoke(this);
    }

    public async UniTask Translate(VisualElement element, Vector2 to)
    {
        AnimationCurve curve = new AnimationCurve(
            new Keyframe(0, 0),
            new Keyframe(0.8f, 0.2f),
            new Keyframe(1, 1)
            );
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / TIME_FADE;
            var translateOld = style.translate.value;
            var calcX = (int)(to.x * curve.Evaluate(t));
            var calcY = (int)(to.y * curve.Evaluate(t));
            element.style.translate = new Translate(new Length(Mathf.Lerp(translateOld.x.value, calcX, t), LengthUnit.Pixel), new Length(Mathf.Lerp(translateOld.y.value, calcY, t), LengthUnit.Pixel), 0);
            await UniTask.Yield();
        }

    }

    public async UniTask Translate(VisualElement element, Vector2 to, Vector2 from)
    {
        element.style.translate = new Translate(new Length(from.x, LengthUnit.Pixel), new Length(from.y, LengthUnit.Pixel), 0);
        await Translate(element, to);
    }

    public void TranslateInstantly(VisualElement element, Vector2 to)
    {
        element.style.translate = new Translate(new Length(to.x, LengthUnit.Pixel), new Length(to.y, LengthUnit.Pixel), 0);
    }
}
