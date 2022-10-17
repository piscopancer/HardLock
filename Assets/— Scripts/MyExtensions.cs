using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum FadeMode { Show, Hide }

public static class MyExtensions
{
    public static VisualElement AddClasses(this VisualElement ve, params string[] classes)
    {
        foreach (var classItem in classes)
        {
            ve.AddToClassList(classItem);
        }
        return ve;
    }

    const float TIME_ANIM = 0.1f;

    public static async UniTask Translate(this VisualElement element, Vector2 to) {
        AnimationCurve curve = new AnimationCurve(
            new Keyframe(0, 0),
            new Keyframe(0.8f, 0.2f),
            new Keyframe(1, 1)
            );
        float t = 0;
        while (t < 1) {
            t += Time.deltaTime / TIME_ANIM;
            var translateOld = element.style.translate.value;
            var calcX = (int)(to.x * curve.Evaluate(t));
            var calcY = (int)(to.y * curve.Evaluate(t));
            element.style.translate = new Translate(new Length(Mathf.Lerp(translateOld.x.value, calcX, t), LengthUnit.Pixel), new Length(Mathf.Lerp(translateOld.y.value, calcY, t), LengthUnit.Pixel), 0);
            await UniTask.Yield();
        }
    }

    public static async UniTask Translate(this VisualElement element, Vector2 to, Vector2 from) {
        element.style.translate = new Translate(new Length(from.x, LengthUnit.Pixel), new Length(from.y, LengthUnit.Pixel), 0);
        await Translate(element, to);
    }

    public static void TranslateInstantly(this VisualElement element, Vector2 to) {
        element.style.translate = new Translate(new Length(to.x, LengthUnit.Pixel), new Length(to.y, LengthUnit.Pixel), 0);
    }

    public static async UniTask Fade(this VisualElement element, FadeMode mode) {
        float t = 0;
        while (t < 1) {
            t += Time.deltaTime / TIME_ANIM;
            element.style.opacity = mode == FadeMode.Show ? t : 1 - t;
            await UniTask.Yield();
        }
        element.style.opacity = mode == FadeMode.Show ? 1 : 0;
    }
}
