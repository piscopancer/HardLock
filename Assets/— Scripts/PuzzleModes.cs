using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Explorer;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleModes : MonoBehaviour
{
    public static PuzzleMode PuzzleModeCurrent
    {
        get
        {
            var puzzleModes = FindObjectOfType<PuzzleModes>();
            foreach (var mode in puzzleModes.listPuzzleModes)
            {
                if (mode.IfSelected)
                {
                    return mode;
                }
            }
            return puzzleModes.listPuzzleModes[0];
        }
    }
    public static int IndexModeCurrent
    {
        get
        {
            return ListPuzzleModes.IndexOf(PuzzleModeCurrent);
        }
    }
    [SerializeField] List<PuzzleMode> listPuzzleModes;
    public static List<PuzzleMode> ListPuzzleModes
    {
        get
        {
            return FindObjectOfType<PuzzleModes>().listPuzzleModes;
        }
    }

    public static Action<PuzzleMode, int, int> OnPuzzleModeChanged;

    void Awake()
    {
        SaveSystem.OnSaveLoaded += (SaveSystem.SaveData save) =>
        {
            SetMode(save.PuzzleModeCurrent);
        };
        SaveSystem.OnSaveDoesNotExist += () =>
        {
            SetMode(0);
            Debug.Log("default mode loaded");
        };
        PanelMenu.OnSliderModesDrag += SetMode;
    }

    void SetMode(PuzzleMode newMode)
    {
        for (int i = 0; i < ListPuzzleModes.Count; i++)
        {
            if (newMode == ListPuzzleModes[i])
            {
                ListPuzzleModes[i].IfSelected = true;
                OnPuzzleModeChanged?.Invoke(ListPuzzleModes[i], IndexModeCurrent, i);
            }
            else
            {
                ListPuzzleModes[i].IfSelected = false;
            }
        }
    }

    void SetMode(int indexNewMode)
    {
        SetMode(ListPuzzleModes[indexNewMode]);
    }
}
