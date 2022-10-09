using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TriInspector;

public class MainCamera : MonoBehaviour
{
    const float TIME_MOVE = 0.2f;
    public AnimationCurve TravelCurve;
    public CameraPosition MenuPosition, PuzzlePosition, ShopPosition, SettingsPosition;
    Tween tweenMove;

    void Start()
    {
        //PanelBase.OnCloseClicked += delegate (PanelBase panelClosed)
        //{
        //    if (panelClosed is PanelShop || panelClosed is PanelSettings)
        //    {
        //        Move(MenuPosition); 
        //    }
        //};
        PanelMenu.OnPlayClicked += delegate { Move(PuzzlePosition); };
        PanelMenu.OnShopClicked += delegate { Move(ShopPosition); };
        PanelMenu.OnSettingsClicked += delegate { Move(SettingsPosition); };
        ModeLevelsArrows.OnLevelCompleted += delegate { Move(MenuPosition); };
        // timer
    }

    public void Move (CameraPosition cameraPosition)
    {
        tweenMove = transform.DOMove(cameraPosition.Point.position, TIME_MOVE);
    }
}

[System.Serializable]
public class CameraPosition
{
    [Required] public Transform Point;
}
