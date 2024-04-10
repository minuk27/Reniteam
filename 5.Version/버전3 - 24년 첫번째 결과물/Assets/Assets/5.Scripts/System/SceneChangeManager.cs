using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    inGame, mainScreen
}

public class SceneChangeManager : MonoBehaviour
{
    State state;

    public void Initialize()
    {
        
    }

    public void ChangeSceneInGame(string name)
    {
        //캐릭터 좌표값 변경
        //화면암전
    }

    public void ChangeSceneMainScreen(string name)
    {   
        switch (name)
        {
            case "GameStart":
                SceneManager.LoadScene("1.Scenes/Menu/3.Tutorial");
                break;
            case "Option":
                SceneManager.LoadScene("1.Scenes/Menu/2.OptionMain");
                break;
            case "QuitGame":
                Application.Quit();
                break;
            case "MainBack":
                SceneManager.LoadScene("1.Scenes/Menu/1.Mainmenu");
                break;
            case "Audio":
                SceneManager.LoadScene("1.Scenes/Menu/2_2.Audio");
                break;
            case "Video":
                SceneManager.LoadScene("1.Scenes/Menu/2_1.Video");
                break;
            case "Start":
                SceneManager.LoadScene("1.Scenes/InGame/MainGame"); //임시
                break;
            case "TutorialVoice":
                SceneManager.LoadScene("1.Scenes/Menu/3_1.Voice");
                break;
        }
    }
}
