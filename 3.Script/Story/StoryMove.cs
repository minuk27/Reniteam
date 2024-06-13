using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMove : MonoBehaviour
{
    // 이동 속도
    [SerializeField] float speed;
    float targetX;
    bool isMove;

    // 초기 위치 저장
    float initialX;

    void Start()
    {
        targetX = transform.position.x;
        isMove = false;
    }

    private void OnEnable()
    {
        targetX = transform.position.x;
        isMove = false;
    }

    void Update()
    {
        if (!isMove)
            return;

        float distanceToTarget = Mathf.Abs(targetX - transform.position.x);

        if (distanceToTarget <= 0.01f)
        {
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
            initialX = transform.position.x;
            isMove = false;
            return;
        }

        float step = speed * Time.deltaTime;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, step);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void moveStart(float value)
    {
        targetX -= value;
        isMove = true;
        initialX = transform.position.x;
    }

    public void moveStop()
    {
        isMove = false;
    }

    public void speedUp()
    {
        speed += 2;
    }

    public bool getIsMove { get { return isMove; } }
}
