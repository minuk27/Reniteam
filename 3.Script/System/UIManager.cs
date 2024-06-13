using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIs
{
    Invectory,
    DialogWindow
}

public class UIManager : MonoBehaviour
{
    [SerializeField] DialogUI dialogWindow;
    [SerializeField] GameOverUI gameOverWindow;

    public void Initialize()
    {
        dialogWindow.gameObject.SetActive(true);
        gameOverWindow.gameObject.SetActive(true);
    }

    public DialogUI getDialogWindow { get { return dialogWindow; } }
    public GameOverUI getGameOverUI { get { return gameOverWindow; } }
}