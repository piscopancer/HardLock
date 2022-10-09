using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCircle : MonoBehaviour
{
    public GameObject CircleObject;
    [Range(0.1f, 5)] public float Lifetime, MinScale, MaxScale;
    public AnimationCurve CircleCurve;

    private void Start()
    {
        //Actions.OnPuzzleSolved += Play;
    }

    //private void Play()
    //{
    //    GameObject circle = Instantiate(CircleObject, TouchReader.Instance.TouchPosWorld, Quaternion.identity);
    //    StartCoroutine(IPlay(circle));

    //    IEnumerator IPlay(GameObject circle)
    //    {
    //        for (float i = 0; i < 1; i += Time.deltaTime / Lifetime)
    //        {
    //            float scale = Mathf.Lerp(MinScale, MaxScale, CircleCurve.Evaluate(i));
    //            circle.transform.localScale = new Vector3(scale, scale, 1);
    //            Color color = circle.GetComponent<SpriteRenderer>().color;
    //            color.a = 1 - CircleCurve.Evaluate(i);
    //            circle.GetComponent<SpriteRenderer>().color = color;
    //            yield return null;
    //        }

    //        Destroy(circle);
    //    }
    //}
}
