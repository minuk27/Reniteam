using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;

    private void Awake()
    {
        time = 15f;
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
            Destroy(this.gameObject); //후에수정
    }
}
