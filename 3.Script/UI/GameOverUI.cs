using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] Text endText;
    [SerializeField] Button reStart;
    [SerializeField] Button end;

    private void Awake()
    {
        window.SetActive(false);
        reStart.onClick.AddListener(gameReStart);
        end.onClick.AddListener(gameEnd);
    }

    public void gameOverUIStart(string text = "GameOver")
    {
        endText.text = text;
        window.SetActive(true);
    }

    void gameReStart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void gameEnd()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
