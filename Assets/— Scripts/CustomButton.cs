using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IfScaleOnClick = true;
	[Range(0.5f, 1)] public float ScaleAfterClick = 0.9f;

	public void OnPointerDown(PointerEventData eventData)
	{
        if (IfScaleOnClick)
        {
            gameObject.transform.localScale = new Vector3(ScaleAfterClick, ScaleAfterClick, 1);
        }
	}

    public void OnPointerUp (PointerEventData eventData)
    {
        if (IfScaleOnClick)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
