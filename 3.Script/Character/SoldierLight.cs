using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierLight : MonoBehaviour
{
    [Header("라이트")]
    [SerializeField] GameObject lightObj;
    [Header("플레이어 감지기")]
    [SerializeField] GameObject colliderObj;
    [Header("라이트 활성 시간")]
    [SerializeField] float lightOnTime = 2.0f;
    [Header("라이트 비활성 시간")]
    [SerializeField] float lightOffTime = 2.0f;

    void Start()
    {
        lightObj.SetActive(false);
        colliderObj.SetActive(false);
        StartCoroutine(ToggleObjectsRoutine());
    }

    IEnumerator ToggleObjectsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightOffTime);
            lightObj.SetActive(true);
            colliderObj.SetActive(true);
            yield return new WaitForSeconds(lightOnTime);
            lightObj.SetActive(false);
            colliderObj.SetActive(false);
        }
    }
}
