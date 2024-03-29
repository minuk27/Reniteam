using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            if (manager == null)
            {
                return null;
            }
            return manager;
        }
    }

    private EventManager eventManager; //�̺�Ʈ �Ŵ���
    private TalkManager talkManager; //��ȭ �Ŵ���
    private SceneChangeManager sceneManager; //����ȯ �Ŵ���
    private QuestManager questManager; //����Ʈ �Ŵ���
    private STTManager sttManager; //stt�Ŵ���
    private UIManager uiManager;


    private void Awake()
    {
        if (manager)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        manager = this;
        DontDestroyOnLoad(this.gameObject);

        ManagerInstance();
        InitializeManagers();
    }

    private void ManagerInstance()
    {
        eventManager = new EventManager();
        talkManager = new TalkManager();
        sceneManager = new SceneChangeManager();
        questManager = new QuestManager();
        sttManager = new STTManager();
        uiManager = new UIManager();
    }

    private void InitializeManagers()
    {
        talkManager.Initialize();
        questManager.Initialize();
        sttManager.Initialize();
        uiManager.Initialize();
    }

    public EventManager GetSetEventManager { get { return eventManager; } }

    public TalkManager GetSetTalkManager { get { return talkManager; } }

    public SceneChangeManager GetSceneManager { get { return sceneManager; } }

    public STTManager GetSttManager { get { return sttManager; } }

    public UIManager GetUIManager { get { return uiManager; } }
}