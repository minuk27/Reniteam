using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonFunction
{
    ChangeScene, StartVoice
}

[System.Serializable]
public class ButtonEvent
{
    [Header("��ư")]
    public Button button;
    [Header("��ư���")]
    public ButtonFunction bFun;
    [Header("�̵����")]
    public string name;
}

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    ButtonEvent btnEvent;

    void Start()
    {
        switch (btnEvent.bFun)
        {
            case ButtonFunction.ChangeScene:
                btnEvent.button.onClick.AddListener(() => OnClick_ChangeScene(btnEvent.name));
                break;
            case ButtonFunction.StartVoice:
                btnEvent.button.onClick.AddListener(() => OnClick_StartVoice());
                break;
        }        
    }

    void OnClick_ChangeScene(string name)
    {
        GameManager.Manager.GetSceneManager.ChangeSceneMainScreen(name);
    }

    void OnClick_StartVoice()
    {
        GameManager.Manager.GetSttManager.StartSTT();
    }
}
