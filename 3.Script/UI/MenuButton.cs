using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    ButtonEvent btnEvent;
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();

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
        //GameManager.Manager.GetSceneManager.ChangeSceneMainScreen(name);
    }

    void OnClick_StartVoice()
    {
        GameManager.Manager.GetSttManager.StartSTT();
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonImage.color = Color.white;        
    }

    // 버튼 선택 해제됐을 때 호출되는 메소드
    public void OnDeselect(BaseEventData eventData)
    {
        buttonImage.color = new Color(1f, 1f, 1f, 0.5f);
    }
}
