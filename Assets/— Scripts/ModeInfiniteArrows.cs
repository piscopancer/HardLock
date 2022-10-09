using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeInfiniteArrows : PuzzleMode
{
    int scoreCurrent, scoreBest;
    [Range(1, 5)] public float MaxTimePerPiece, MinTimePerPiece;
    [Range(1, 50)] public float PuzzlesToMinTime;
    public GameObject PuzzlePiecesLayout;
    [SerializeField] int PiecesToActivate;
    public int LeftToActivate;
    [SerializeField] int activePieces;

    public override void EnableMode()
    {
        //OnCreated += GeneratePuzzle;
        //OnCreated += ShowScore;
        //Actions.OnAllPuzzlesActivated += DisableRestPieces;
        //Actions.OnAllPuzzlesActivated += ActivateArrowsOnPieces;
        //Actions.OnAllPuzzlesActivated += RotatePieces;
        //Actions.OnRestPiecesDeactivated += StartTimer;
        //OnSolved += GeneratePuzzle;
        //OnSolved += UpdateScore;
        //OnSolved += GiveRewardPuzzleSolved;
        //Actions.OnTimerOut += ResetPuzzle;
        //Actions.OnPieceRotated += CheckPuzzleSolved;
    }

    public override void DisableMode()
    {

    }

    public override void GeneratePuzzle()
    {

    }

    void RotatePieces()
    {
        
    }

    void StartTimer()
    {
        
    }

    public void CheckPuzzleSolved()
    {
        PuzzlePieceWithArrows[] puzzlePieces = FindObjectsOfType<PuzzlePieceWithArrows>();
        int i = 0;
        foreach (PuzzlePieceWithArrows piece in puzzlePieces)
        {
            for (int o = 0; o < piece.ArrowsHolder.transform.childCount; o++)
            {

            }
        }
        if (i == 0)
        {
            OnSolved?.Invoke(this);
        }
    }

    public override void DestroyPuzzle()
    {
        
    }

    public override int GetProgressValue()
    {
        return scoreBest;
    }

    public override void SolvePuzzle()
    {
        
    }
}
