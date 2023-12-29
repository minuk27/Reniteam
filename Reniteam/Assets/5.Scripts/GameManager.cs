using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //������ �޴������� �����Ѵ�. �޴����� ���� ���� ��ġ�� �ʿ伺�� ����
    [Header("�Ŵ��� ����Ʈ")]
    public GameObject Event;
    public EventManager eventManager;


    //���ӻ��°�/ �Ͻ�����, ����, ����
    public enum GameState
    {
        Start, Pause, Stop
    };
    private GameState gameST;
    //���ӿ� ui����
    public enum Scene
    {
        Tutorial, MainGame,
        MainMenu, Option,
        OptionAudio, OptionVideo,
        TutorialVoice, Test
    };
    private Scene gameScene;
    //�ΰ��� ����ȯ��
    public enum GameProgress
    {
        Tutorial, Stage1, Stage2, Stage3
    };
    private GameProgress gameSave;
    //���Ӽ� �ڿ�������
    public enum Resource
    {
        Save, Story1, Story2
    };
    private Resource resou;

    private void Awake()
    {
        if (manager)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        manager = this;
        DontDestroyOnLoad(this.gameObject);
        eventManager = Event.GetComponent<EventManager>();
    }

    //���ӻ��º�ȭ(�Ͻ�����, ����, ��������)
    public GameState State
    {
        set
        {
            gameST = value;
            switch (gameST)
            {
                case GameState.Start:
                    Time.timeScale = 1f;
                    break;
                case GameState.Pause:
                    Time.timeScale = 0f;
                    break;
                case GameState.Stop:
                    Application.Quit();
                    break;
            }
        }
    }

    //����ȯ �޼ҵ�
    public Scene SceneTrans
    {
        set
        {
            gameScene = value;
            switch (gameScene)
            {
                case Scene.Tutorial:
                    SceneManager.LoadScene("1.Scenes/Tutorial");
                    break;
                case Scene.TutorialVoice:
                    SceneManager.LoadScene("1.Scenes/TutorialVoice");
                    break;
                case Scene.MainGame:
                    SceneManager.LoadScene("1.Scenes/MainGame");
                    if (gameSave == GameProgress.Tutorial)
                    {
                        //Ʃ�丮���
                    }
                    else if (gameSave == GameProgress.Stage1)
                    {
                        //��������1
                    }
                    else if (gameSave == GameProgress.Stage2)
                    {
                        //��������2
                    }
                    else if (gameSave == GameProgress.Stage3)
                    {
                        //��������3
                    }
                    break;
                case Scene.MainMenu:
                    SceneManager.LoadScene("1.Scenes/Mainmenu");
                    break;
                case Scene.Option:
                    SceneManager.LoadScene("1.Scenes/OptionMain");
                    break;
                case Scene.OptionAudio:
                    SceneManager.LoadScene("1.Scenes/OptionAudio");
                    break;
                case Scene.OptionVideo:
                    SceneManager.LoadScene("1.Scenes/OptionVideo");
                    break;
                case Scene.Test:
                    SceneManager.LoadScene("1.Scenes/test");
                    break;
            }
        }
    }
    /*�����ν� ����*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}