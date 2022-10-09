using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TriInspector;

public class PuzzlePieceWithArrows : PuzzlePiece
{
    public GameObject ArrowTop, ArrowRight, ArrowBottom, ArrowLeft, ArrowsHolder;
    static float timeRotation = 0.1f;
    Ease easeRot = Ease.OutQuad;
    Tween tweenRotate;
    
    protected override void Awake()
    {
        base.Awake();
        EnableArrows(false, false, false, false);
        DelegateClick += Rotate;
    }

    public void EnableArrows(bool top, bool right, bool bottom, bool left)
    {
        ArrowTop.SetActive(top);
        ArrowRight.SetActive(right);
        ArrowBottom.SetActive(bottom);
        ArrowLeft.SetActive(left);
    }

    void Rotate()
    {
        if (tweenRotate != null)
        {
            tweenRotate.Complete();
        }
        tweenRotate = transform.DOBlendableLocalRotateBy(Vector3.forward * 90, timeRotation, RotateMode.LocalAxisAdd).SetEase(easeRot);
    }
}
