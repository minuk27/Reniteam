using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMoveState
{
    [Header("NPC동작 여부")]
    public bool isMove;
    [Header("NPC이동 좌표(NPC중심)")]
    public float[] distance;
    [Header("NPC속도")]
    [Range(1, 5)]
    public float speed;
    [Header("NPC이동 딜레이")]
    [Range(1, 5)]
    public float moveDelay;
    [Header("NPC대사 유무")]
    public bool talk;
}


public class NPCMove : MonoBehaviour
{
    [SerializeField]
    NPCMoveState move;
    private float dist;
    private float time;
    private int index;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        time = move.moveDelay;
        dist = move.isMove ? move.distance[0] + transform.position.x : 0f;
        index = 0;
    }

    void Update()
    {
        if (!move.isMove)
            return;

        if (time < move.moveDelay)
        {
            time += Time.deltaTime;
            return;
        }
        else if (time >= move.moveDelay && transform.position.x != dist)
        {
            sprite.flipX = dist < transform.position.x ? false : true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(dist, transform.position.y, transform.position.z), move.speed * Time.deltaTime);
        }
        else
        {
            time = 0f;
            index = index + 1 >= move.distance.Length ? 0 : index + 1;
            dist = move.distance[index] + transform.position.x;
        }
    }

    public bool GetBoolTalk { get { return move.talk; } }
}
