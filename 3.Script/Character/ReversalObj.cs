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
        // 부모 오브젝트의 SpriteRenderer 컴포넌트를 가져옴
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

        if (parentSpriteRenderer == null)
        {
            Debug.LogError("Parent does not have a SpriteRenderer component.");
            return;
        }

        // 초기 상태 저장
        previousFlipX = parentSpriteRenderer.flipX;

        // 초기 상태에 따라 위치와 회전 설정
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
        // 부모 오브젝트의 flipX 값이 변경되었는지 확인
        if (parentSpriteRenderer.flipX != previousFlipX)
        {
            // flipX 값이 변경됨
            previousFlipX = parentSpriteRenderer.flipX;

            // 위치와 회전을 변경
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
