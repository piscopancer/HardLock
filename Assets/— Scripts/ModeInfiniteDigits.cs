using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

public class ModeInfiniteDigits : PuzzleMode
{
    int scoreCurrent, scoreBest;
    [Range(1, 50)] public int PuzzleSolvedReward, EveryTenthReward;
    [Range(1, 5)] public float MaxTimePerPiece, MinTimePerPiece;
    [Range(1, 50)] public float PuzzlesToMinTime;
    public List<GameObject> PuzzlePiecesLayoutsList;
    [Range(1, 100)] public int ActivePieceChance;
    [SerializeField] int activePieces;

    public override void EnableMode()
    {

    }

    public override void DisableMode()
    {

    }

    void Awake()
    {
        
    }

    public override void GeneratePuzzle()
    {
        GameObject layoutToSpawn = PuzzlePiecesLayoutsList[Random.Range(0, PuzzlePiecesLayoutsList.Count)];
    }

    void StartTimer()
    {
        float time = activePieces * Mathf.Lerp(MaxTimePerPiece, MinTimePerPiece, scoreCurrent / PuzzlesToMinTime);
        TimerSlider.Instance.StartTimer(time);
    }

    public virtual void ChangeScoreBy(int by)
    {
        scoreCurrent += by;
        OnScoreCurrentChanged?.Invoke(this, scoreCurrent);
        if (scoreCurrent >= scoreBest)
        {
            scoreBest = scoreCurrent;
            OnScoreBestChanged?.Invoke(this, scoreBest);
        }
    }

    public void CheckPuzzleSolved()
    {
        
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
