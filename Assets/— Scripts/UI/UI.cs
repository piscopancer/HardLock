using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField, Required, SceneObjectsOnly] PanelBase panelMenu;
    //[SerializeField, Required, SceneObjectsOnly] PanelBase panelSettings, panelGame, panelModeDescription;

    void Awake()
    {
        //PanelBase.OnCloseClicked += delegate (PanelBase panelClosed)
        //{
        //    if (panelClosed is PanelModeDescription)
        //    {
        //        //panelModeDescription.Display(false);
        //        panelMenu.Display(true);
        //    }
        //};
        //PanelPuzzleMode.OnDescriptionClicked += delegate (PuzzleMode mode)
        //{
        //    panelMenu.Display(false);
        //    //panelModeDescription.Display(true);
        //    //panelModeDescription.GetComponent<PanelModeDescription>().Setup(mode);
        //};

        ////panelGame.Display(true);
        //panelMenu.Display(true);
        ////panelSettings.Display(true);
        ////panelModeDescription.Display(false);
    }
}
