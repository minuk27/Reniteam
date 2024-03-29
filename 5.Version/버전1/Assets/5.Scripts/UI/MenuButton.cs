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
    [Header("버튼")]
    public Button button;
    [Header("버튼기능")]
    public ButtonFunction bFun;
    [Header("이동경로")]
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
