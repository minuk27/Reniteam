using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierLight : MonoBehaviour
{
    [Header("����Ʈ")]
    [SerializeField] GameObject lightObj;
    [Header("�÷��̾� ������")]
    [SerializeField] GameObject colliderObj;
    [Header("����Ʈ Ȱ�� �ð�")]
    [SerializeField] float lightOnTime = 2.0f;
    [Header("����Ʈ ��Ȱ�� �ð�")]
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
