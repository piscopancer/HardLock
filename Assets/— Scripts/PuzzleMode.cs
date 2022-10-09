using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TriInspector;

public abstract class PuzzleMode : MonoBehaviour
{
    [field: SerializeField, Required] public Translation Name { get; private set; }
    [field: SerializeField, Required] public Translation Description { get; private set; }
    [field: SerializeField, Required] public Translation TextScore { get; private set; }
    public bool IfSelected { get; set; }
    [TriInspector.ReadOnly] protected PuzzleLayouts LayoutCurrent; 
    [Min(0)] public int rewardSolved = 1;

    public static Action<PuzzleMode> OnCreated, OnDestroyed, OnSolved;
    public static Action<PuzzleMode, int> OnScoreCurrentChanged, OnScoreBestChanged;

    public abstract void EnableMode();
    public abstract void DisableMode();
    public abstract void GeneratePuzzle();
    public abstract void DestroyPuzzle();
    public abstract void SolvePuzzle();

    public abstract int GetProgressValue();
}
