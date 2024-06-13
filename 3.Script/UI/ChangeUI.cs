using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] ScenesName moveScenes;
    [SerializeField] UIScenesManager scenesManger;
    [SerializeField] Button btn;
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        btn.onClick.AddListener(() => OnClick_ChangeScene(moveScenes));     
    }

    void OnClick_ChangeScene(ScenesName name)
    {
        scenesManger.changeScenes(name);
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
