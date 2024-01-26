using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCState
{
    [Header("NPC���̵�")]
    public int id;
    [Header("NPC���� ����")]
    public bool isMove;
    [Header("NPC�̵� ��ǥ(NPC�߽�)")]
    public float[] distance;
    [Header("NPC�ӵ�")]
    [Range(1, 5)]
    public float speed;
    [Header("NPC�̵� ������")]
    [Range(1, 5)]
    public float moveDelay;
    [Header("���")]
    public string[] speech;
}

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    NPCState state;
    private float dist;
    private float time;
    private int index;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        time = state.moveDelay;
        dist = state.isMove ? state.distance[0] + transform.position.x : 0f;
        index = 0;
        GameManager.Manager.GetSetTalkManager.SetTalk(state.id, state.speech);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!state.isMove)
            return;

        if (time < state.moveDelay)
        {
            time += Time.deltaTime;
            return;
        }
        else if (time >= state.moveDelay && transform.position.x != dist)
        {
            sprite.flipX = dist < transform.position.x ? false : true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(dist, transform.position.y, transform.position.z), state.speed * Time.deltaTime);
        }
        else
        {
            time = 0f;
            index = index + 1 >= state.distance.Length ? 0 : index + 1;
            dist = state.distance[index] + transform.position.x;
        }
    }
}
