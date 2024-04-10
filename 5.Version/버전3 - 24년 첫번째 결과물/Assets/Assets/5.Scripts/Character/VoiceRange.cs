using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRange : MonoBehaviour
{
    private Dictionary<int, GameObject> npcDetect;
    private int npcID;

    private void Awake()
    {
        npcID = 0;
        npcDetect = new Dictionary<int, GameObject>();
    }

    public int getnpcID(Vector2 playerPos)
    {
        float minDistance = 9999f;
        float distance;
        npcID = 0;
        foreach (int id in npcDetect.Keys)
        {
            distance = Vector3.Distance(npcDetect[id].transform.position, playerPos);
            if(distance < minDistance)
            {
                minDistance = distance;
                npcID = id;
            }

        }
        return npcID;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            int id = collision.gameObject.GetComponent<NPC>().GetID;
            if (!npcDetect.ContainsKey(id))
            {
                npcDetect.Add(id, collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            int id = collision.gameObject.GetComponent<NPC>().GetID;
            if (npcDetect.ContainsKey(id))
            {
                npcDetect.Remove(id);
            }
        }
    }
    //들어왔을때 캐릭터 움직임 일시 멈추게 하고
    //TalkManager
}