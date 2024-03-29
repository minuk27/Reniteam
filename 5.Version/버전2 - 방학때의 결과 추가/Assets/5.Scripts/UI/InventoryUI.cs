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
    [SerializeField]
    private List<Button> button;
    private int index;
    private bool[] slotFill;
    bool activeInventory = false;

    private void Awake()
    {
        slotFill = new bool[slot.Count];
        for(int i = 0; i<slot.Count; i++)
        {
            slotFill[i] = false;
        }

        for(int i = 0; i<button.Count; i++)
        {
            int buttonIndex = i;
            button[i].onClick.AddListener(() => UseItem(buttonIndex));
        }
    }

    void Start()
    {
        GameManager.Manager.GetSetEventManager.AddListeners(EventType.MapItemPickUp, this);
        GameManager.Manager.GetSetEventManager.AddListeners(EventType.KeyItemPickUp, this);
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
                SlotGet(0);
                break;
            case EventType.KeyItemPickUp:
                SlotGet(0);
                break;
        }
    }

    private void SlotGet(int itemIndex)
    {
        index = -1;
        for (int i = 0; i < slot.Count; i++)
        {
            if (!slotFill[i])
            {
                index = i;
                Instantiate(items[itemIndex], slot[index].transform);
                slotFill[i] = true;
                break;
            }
        }
        if(index == -1)
        {
            Debug.Log("아이템창 빈공간 없음");
        }
    }

    private void UseItem(int index)
    {
        if (!slotFill[index])
            return;
        Debug.Log("아이템사용");//아이템사용코드 작성하기
        Destroy(slot[index].transform.GetChild(0).gameObject);
        slotFill[index] = false;
    }
}