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
    private GameObject inventory;
    private GameObject chatWindow;
    private bool[] uiSurvival; //ui들이 현재 씬에서 한번이라도 생성을 했는지:true 안했는지:false

    public void Initialize()
    {
        inventory = Resources.Load<GameObject>("Inventroy");
        chatWindow = Resources.Load<GameObject>("ChantWindow");

        uiSurvival = new bool[2];
        for(int index = 0; index<uiSurvival.Length; index++)
        {
            uiSurvival[index] = false;
        }
    }

    public void ChoiceUI(UIs cui)
    {
        switch (cui)
        {
            case UIs.ChatWindow:
                if (uiSurvival[0])
                    chatWindow.SetActive(true);
                else
                {
                    Instantiate(chatWindow);
                    chatWindow.SetActive(true);
                    uiSurvival[0] = true;
                }
                break;
            case UIs.Invectory:
                if (uiSurvival[1])
                    inventory.SetActive(true);
                else
                {
                    Instantiate(inventory);
                    inventory.SetActive(true);
                    uiSurvival[1] = true;
                }
                break;
        }
    }

    public void UISurvival()
    {
        for (int index = 0; index < uiSurvival.Length; index++)
        {
            uiSurvival[index] = false;
        }
    }
}
