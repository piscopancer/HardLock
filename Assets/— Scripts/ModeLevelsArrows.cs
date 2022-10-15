using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeLevelsArrows : PuzzleMode
{
    [SerializeField] int levelCurrent;
    [SerializeField] int levelCompleteReward;
    public Vector2 MinMaxStages;
    [Range(1, 5)] public float TimePerPiece = 1.1f;
    public GameObject StageCellsHolder, StageCell;
    public int StagesCount, CurrentStage;
    public GameObject PuzzlePiecesLayout;
    [SerializeField] int PiecesToActivate;
    public int LeftToActivate;
    [SerializeField] int activePieces;

    public static Action OnLevelCompleted;

    public override void EnableMode()
    {
        
    }

    public override void DisableMode()
    {
        
    }

    public override void GeneratePuzzle()
    {

    }

    void SpawnStageCells()
    {
        StagesCount = UnityEngine.Random.Range((int)MinMaxStages.x, (int)MinMaxStages.y + 1);
        for (int i = 0; i < StagesCount; i++)
        {
            GameObject cell = Instantiate(StageCell, StageCellsHolder.transform);
            cell.GetComponent<StageCell>().Center.SetActive(false);
            cell.GetComponent<StageCell>().SelectionBox.SetActive(false);
            if (i == 0)
            {
                cell.GetComponent<StageCell>().SelectionBox.SetActive(true);
            }
        }
    }

    void StartTimer()
    {
        TimerSlider.Instance.StartTimer(activePieces * TimePerPiece);
    }

    void RotatePieces()
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
                Transform arrow = piece.ArrowsHolder.transform.GetChild(o);
                //if (!arrow.GetComponent<BoxCollider2D>().IsTouchingLayers(ArrowLayerMask)
                //    && arrow.gameObject.activeInHierarchy)
                //{
                //    i++;
                //}
            }
        }
        if (i == 0)
        {
            OnSolved?.Invoke(this);
        }
    }

    void GoToNextStage()
    {
        if (CurrentStage != StagesCount)
        {
            StageCellsHolder.transform.GetChild(CurrentStage).GetComponent<StageCell>().Center.SetActive(true);
            StageCellsHolder.transform.GetChild(CurrentStage).GetComponent<StageCell>().SelectionBox.SetActive(false);

            CurrentStage++;
            if (CurrentStage <  StagesCount)
            {
                StageCellsHolder.transform.GetChild(CurrentStage).GetComponent<StageCell>().SelectionBox.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in StageCellsHolder.transform)
            {
                child.GetComponent<StageCell>().Center.SetActive(false);
                child.GetComponent<StageCell>().SelectionBox.SetActive(false);
            }
        }
    }

    void CheckLevelCompleted()
    {
        
    }

    public override void DestroyPuzzle()
    {
        
    }

    public override int GetProgressValue()
    {
        return levelCurrent;
    }

    public override void SolvePuzzle()
    {
        throw new System.NotImplementedException();
    }
}

