using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour, EventListener
{
    [Header("아이템창")]
    [SerializeField]
    private GameObject inventoryPanel;

    [Header("아이템리스트")]
    [SerializeField]
    private List<Image> items;
    [SerializeField]
    private List<Image> slot;
    public int index;
    bool activeInventory = false;
    void Start()
    {
        GameManager.Manager.eventManager.AddListeners(EventType.MapItemPickUp, this);
        GameManager.Manager.eventManager.AddListeners(EventType.KeyItemPickUp, this);
        index = 0;
        inventoryPanel.SetActive(activeInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void OnEvent(EventType eventType)
    {
        switch (eventType)
        {
            case EventType.MapItemPickUp:
                Instantiate(items[0], slot[index].transform); index++;
                break;
            case EventType.KeyItemPickUp:
                Instantiate(items[0], slot[index].transform); index++;
                break;
        }
    }
}