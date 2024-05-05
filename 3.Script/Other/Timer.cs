using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Slider time;
    private float totalTime;

    private void Awake()
    {
        totalTime = 3f;
        time.value = totalTime;
    }

    public void startTime()
    {
        totalTime = 3f;
        time.value = 0;
        StartCoroutine(goTime());
    }

    IEnumerator goTime()
    {
        while (true)
        {
            if (totalTime < 0)
                break;
            totalTime -= 0.1f;
            time.value = totalTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
