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

    //각각의 메니저들을 저장한다. 메니저를 따로 씬에 배치할 필요성을 지움
    [Header("매니저 리스트")]
    public GameObject Event;
    public EventManager eventManager;


    //게임상태값/ 일시정지, 시작, 종료
    public enum GameState
    {
        Start, Pause, Stop
    };
    private GameState gameST;
    //게임에 ui씬값
    public enum Scene
    {
        Tutorial, MainGame,
        MainMenu, Option,
        OptionAudio, OptionVideo,
        TutorialVoice, Test
    };
    private Scene gameScene;
    //인게임 씬전환값
    public enum GameProgress
    {
        Tutorial, Stage1, Stage2, Stage3
    };
    private GameProgress gameSave;
    //게임속 자원종류값
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

    //게임상태변화(일시정지, 시작, 게임종료)
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

    //씬전환 메소드
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
                        //튜토리얼씬
                    }
                    else if (gameSave == GameProgress.Stage1)
                    {
                        //스테이지1
                    }
                    else if (gameSave == GameProgress.Stage2)
                    {
                        //스테이지2
                    }
                    else if (gameSave == GameProgress.Stage3)
                    {
                        //스테이지3
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
    /*음성인식 구간*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}