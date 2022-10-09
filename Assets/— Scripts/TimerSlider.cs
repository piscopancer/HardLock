using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    public static TimerSlider Instance { get; private set; }
    private Coroutine timerCoroutine;
    private Slider slider;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void StartTimer(float time)
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(ITimer());
        }
        else
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = StartCoroutine(ITimer()); ;
        }

        slider.maxValue = time;
        slider.value = time;

        IEnumerator ITimer()
        {
            for (float i = 0; i < time; i += Time.deltaTime)
            {
                slider.value -= Time.deltaTime;
                yield return null;
            }

            Actions.OnTimerOut.Invoke();
        }
    }

    public void ResetTimer()
    {
        StopCoroutine(timerCoroutine);
        slider.value = slider.maxValue;
    }
}
