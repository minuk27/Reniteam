using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRange : MonoBehaviour
{
    private Dictionary<int, GameObject> npcDetect;
    float npcMinDistance;

    private void Awake()
    {
        npcDetect = new Dictionary<int, GameObject>();
    }

    public void rangeReset()
    {
        npcDetect.Clear();
    }

    public GameObject getnpcGameObject(Vector2 playerPos)
    {
        GameObject returnNPC = null;
        npcMinDistance = 9999f;
        float distance;
        foreach (GameObject npc in npcDetect.Values)
        {
            distance = Vector3.Distance(npc.transform.position, playerPos);
            if (distance < npcMinDistance)
            {
                npcMinDistance = distance;
                returnNPC = npc;
            }
        }
        return returnNPC;
    }

    public float getDistance { get { return npcMinDistance; } }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            int id = collision.gameObject.GetComponent<NPCTalk>().getID;
            if (!npcDetect.ContainsKey(id))
            {
                npcDetect.Add(id, collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            int id = collision.gameObject.GetComponent<NPCTalk>().getID;
            if (npcDetect.ContainsKey(id))
            {
                npcDetect.Remove(id);
            }
        }
    }
}