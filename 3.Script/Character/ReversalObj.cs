using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversalObj : MonoBehaviour
{
    [SerializeField] Vector3 flippedPosition;
    [SerializeField] Quaternion flippedRotation;
    [SerializeField] Vector3 normalPosition;
    [SerializeField] Quaternion normalRotation;

    private SpriteRenderer parentSpriteRenderer;
    private bool previousFlipX;

    void Start()
    {
        // �θ� ������Ʈ�� SpriteRenderer ������Ʈ�� ������
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

        if (parentSpriteRenderer == null)
        {
            Debug.LogError("Parent does not have a SpriteRenderer component.");
            return;
        }

        // �ʱ� ���� ����
        previousFlipX = parentSpriteRenderer.flipX;

        // �ʱ� ���¿� ���� ��ġ�� ȸ�� ����
        if (previousFlipX)
        {
            transform.localPosition = flippedPosition;
            transform.localRotation = flippedRotation;
        }
        else
        {
            transform.localPosition = normalPosition;
            transform.localRotation = normalRotation;
        }
    }

    void Update()
    {
        // �θ� ������Ʈ�� flipX ���� ����Ǿ����� Ȯ��
        if (parentSpriteRenderer.flipX != previousFlipX)
        {
            // flipX ���� �����
            previousFlipX = parentSpriteRenderer.flipX;

            // ��ġ�� ȸ���� ����
            if (previousFlipX)
            {
                transform.localPosition = flippedPosition;
                transform.localRotation = flippedRotation;
            }
            else
            {
                transform.localPosition = normalPosition;
                transform.localRotation = normalRotation;
            }
        }
    }
}
