using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchReader : MonoBehaviour
{
    public static TouchReader Instance { get; private set; }

    public Vector3 TouchPosWorld;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        }
    }
}
