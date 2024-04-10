using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIs
{
    Invectory,
    ChatWindow
}

public class UIManager : MonoBehaviour
{
    //private GameObject inventory;
    //private InventoryUI invetoryUI;
    private GameObject chatWindow;
    private TalkUI talkUI;

    public void Initialize()
    {
        
    }

    public void CreateUI(GameObject chat, TalkUI talk)
    {
        chatWindow = chat;
        talkUI = talk;
        chatWindow.SetActive(false);
    }

    public void ActiveUI(UIs cui) //후에 활성, 비활성으로 수정
    {
        switch (cui)
        {
            case UIs.ChatWindow:
                chatWindow.SetActive(true);
                break;
            case UIs.Invectory:
                //inventory.SetActive(true);
                break;
        }
    }

    public void InactiveUI(UIs cui) //후에 활성, 비활성으로 수정
    {
        switch (cui)
        {
            case UIs.ChatWindow:
                chatWindow.SetActive(false);
                break;
            case UIs.Invectory:
                //inventory.SetActive(false);
                break;
        }
    }

    public TalkUI GetChatWindow { get { return talkUI; } }
    //public InventoryUI GetInventory { get { return invetoryUI; } }
}
