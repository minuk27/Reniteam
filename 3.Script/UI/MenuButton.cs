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
    [Header("��ư")]
    public Button button;
    [Header("��ư���")]
    public ButtonFunction bFun;
    [Header("�̵����")]
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

    // ��ư ���� �������� �� ȣ��Ǵ� �޼ҵ�
    public void OnDeselect(BaseEventData eventData)
    {
        buttonImage.color = new Color(1f, 1f, 1f, 0.5f);
    }
}
