using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [Header("����� ������Ʈ")]
    [SerializeField] Transform followObj;
    [Header("���� ������ ��")]
    [SerializeField] int delayFrames = 10;
    private Queue<Vector3> positions;

    void Start()
    {
        positions = new Queue<Vector3>();

        for (int i = 0; i < delayFrames; i++)
        {
            positions.Enqueue(transform.position);
        }
    }

    void Update()
    {
        positions.Enqueue(transform.position);
    }

    void LateUpdate()
    {
        if (positions.Count > delayFrames)
        {
            Vector3 delayedPosition = positions.Dequeue();
            followObj.position =  new Vector3(delayedPosition.x, delayedPosition.y, followObj.position.z);
        }
    }
}
