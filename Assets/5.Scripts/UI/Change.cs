using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void ChangeSceneBtn()
    {   
        switch (this.gameObject.name)
        {
            case "GameStart":
                GameManager.Manager.SceneTrans = GameManager.Scene.Tutorial;
                break;
            case "Option":
                GameManager.Manager.SceneTrans = GameManager.Scene.Option;
                break;
            case "QuitGame":
                Application.Quit();
                break;
            case "OptionBack":
                GameManager.Manager.SceneTrans = GameManager.Scene.Option;
                break;
            case "MainBack":
                GameManager.Manager.SceneTrans = GameManager.Scene.MainMenu;
                break;
            case "Audio":
                GameManager.Manager.SceneTrans = GameManager.Scene.OptionAudio;
                break;
            case "Video":
                GameManager.Manager.SceneTrans = GameManager.Scene.OptionVideo;
                break;
            case "Resume":
                Debug.Log("계속하기");
                break;
            case "Start":
                GameManager.Manager.SceneTrans = GameManager.Scene.MainGame;
                break;
        }
    }
}
