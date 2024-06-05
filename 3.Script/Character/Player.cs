using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMove move;
    PlayerTalk talk;
    NPCRange rangeNPC;
    ItemRange rangeItem;
    int targetType;

    private void Awake()
    {
        move = GetComponent<PlayerMove>();
        talk = GetComponent<PlayerTalk>();
        rangeNPC = GetComponentInChildren<NPCRange>();
        rangeItem = GetComponentInChildren<ItemRange>();
        targetType = -1;
    }

    public void moveStart()
    {
        move.moveStart();
    }
    public void moveStop()
    {
        move.moveStop();
    }

    public GameObject getNPCItem(Vector2 playerPos)
    {
        GameObject npc = rangeNPC.getnpcGameObject(playerPos);
        GameObject item = rangeItem.getitemGameObject(playerPos);

        if (npc == null && item == null)
        {
            Debug.Log("½ÇÇà");
            targetType = -1;
            return null;
        }

        if (rangeNPC.getDistance < rangeItem.getDistance)
        {
            targetType = 0;
            return npc;
        }
        targetType = 1;
        return item;
    }

    public void rangeReset()
    {
        rangeNPC.rangeReset();
        rangeItem.rangeReset();
    }

    public int getTargetType { get { return targetType; } }
}
