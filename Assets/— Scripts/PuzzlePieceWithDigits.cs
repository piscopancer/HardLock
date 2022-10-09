using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;
using DG.Tweening;

public class PuzzlePieceWithDigits : PuzzlePiece
{
    //[SerializeField] TextMeshProUGUI textValue;
    [SerializeField, ReadOnly] int value;

    protected override void Awake()
    {
        base.Awake();

        //value = 0;
        //IncreaseValue();
        //textValue.text = value.ToString();
    }

    void IncreaseValue()
    {
        //if (value == 4)
        //{
        //    value = 1;
        //}
        //else
        //{
        //    value++;
        //}
        //textValue.text = value.ToString();
        //textValue.color = new Color(textValue.color.r, textValue.color.g, textValue.color.b, 0.4f + 0.15f * value);
        //textValue.fontSize = 0.5f + value * 0.1f;
    }
}
