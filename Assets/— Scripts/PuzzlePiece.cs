using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public abstract class PuzzlePiece : MonoBehaviour
{
    protected delegate void Click();
    protected Click DelegateClick;
    protected int countNeighbors;

    public static Action<PuzzlePiece> OnClicked;

    protected virtual void Awake()
    {
        GetComponent<Button>().onClick.AddListener(delegate 
        {
            DelegateClick();
            OnClicked?.Invoke(this);
        });
    }

    protected virtual void SetNeighbors(int count)
    {
        countNeighbors = count;
    }
}
