using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesName
{
    MainMenu, OptionMenu, Video, Audio, Tutorial, Voice, InGame, Quite
}

public class UIScenesManager : MonoBehaviour
{
    [SerializeField] GameObject[] uiScenes;
    int nowScenes;

    private void Awake()
    {
        nowScenes = 0;
        for(int i = 1; i< uiScenes.Length; i++)
        {
            uiScenes[i].SetActive(false);
        }
    }

    public void changeScenes(ScenesName name)
    {
        switch (name)
        {
            case ScenesName.MainMenu:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[0].SetActive(true);
                nowScenes = 0;
                break;
            case ScenesName.OptionMenu:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[1].SetActive(true);
                nowScenes = 1;
                break;
            case ScenesName.Video:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[2].SetActive(true);
                nowScenes = 2;
                break;
            case ScenesName.Audio:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[3].SetActive(true);
                nowScenes = 3;
                break;
            case ScenesName.Tutorial:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[4].SetActive(true);
                nowScenes = 4;
                break;
            case ScenesName.Voice:
                uiScenes[nowScenes].SetActive(false);
                uiScenes[5].SetActive(true);
                nowScenes = 5;
                break;
            case ScenesName.InGame:
                SceneManager.LoadScene("MainGameTown");
                //nowScenes = 0;
                break;
            case ScenesName.Quite:
                Application.Quit();
                break;
        }
    }
}
