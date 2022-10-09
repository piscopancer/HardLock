using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLayouts : MonoBehaviour
{
    [SerializeField] List<int[][]> listLayouts = new List<int[][]>
    {
        new int[3][]
        {
            new int[3] { 1, 1, 1 },
            new int[3] { 1, 1, 1 },
            new int[3] { 0, 0, 0 },
        },
        new int[][]
        {
            new int[] { 1, 1, 1 },
            new int[] { 1, 1, 1 },
            new int[] { 1, 1, 1 },
        },
        new int[][]
        {
            new int[] { 1, 1, 1 },
            new int[] { 1, 1, 1 },
            new int[] { 0, 0, 0 },
        },
    };

    public int[][] GetRandomLayout()
    {
        return listLayouts[UnityEngine.Random.Range(0, listLayouts.Count)];
    }
    
}
