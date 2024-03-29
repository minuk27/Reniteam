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

    private EventManager eventManager; //이벤트 매니저
    private TalkManager talkManager; //대화 매니저
    private SceneChangeManager sceneManager; //씬전환 매니저
    private QuestManager questManager; //퀘스트 매니저
    private STTManager sttManager; //stt매니저
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