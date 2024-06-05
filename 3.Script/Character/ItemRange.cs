using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRange : MonoBehaviour
{
    private Dictionary<int, GameObject> itemDetect;
    float itemMinDistance;

    private void Awake()
    {
        itemDetect = new Dictionary<int, GameObject>();
    }

    public void rangeReset()
    {
        itemDetect.Clear();
    }

    public GameObject getitemGameObject(Vector2 playerPos)
    {
        GameObject returnNPC = null;
        itemMinDistance = 9999f;
        float distance;
        foreach (GameObject npc in itemDetect.Values)
        {
            distance = Vector3.Distance(npc.transform.position, playerPos);
            if (distance < itemMinDistance)
            {
                itemMinDistance = distance;
                returnNPC = npc;
            }
        }
        return returnNPC;
    }

    public float getDistance { get { return itemMinDistance; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            int id = collision.gameObject.GetComponent<Item>().getID;
            if (!itemDetect.ContainsKey(id))
            {
                itemDetect.Add(id, collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            int id = collision.gameObject.GetComponent<Item>().getID;
            if (itemDetect.ContainsKey(id))
            {
                itemDetect.Remove(id);
            }
        }
    }
}
