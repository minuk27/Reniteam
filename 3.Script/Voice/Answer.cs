using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] Question question;
    [SerializeField] Mic mic;
    private bool keyHasBeenPressed;
    void Start()
    {
        keyHasBeenPressed = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !keyHasBeenPressed)
        {
            keyHasBeenPressed = true;
            mic.RecSnd();
        }
    }

    public void startAnswer()
    {
        keyHasBeenPressed = false;
    }

    public void setAnswerText(string text)
    {
        bool isCorrect;
        string[] answerText = text.Split("\n");
        isCorrect = GameManager.Manager.GetSttManager.interrogate(answerText);
        if (isCorrect)
        {
            question.startQuestion();
            Debug.Log("맞음");
        }
        else
        {
            question.wrongQuestion();
            Debug.Log("틀림");
        }
    }
}
