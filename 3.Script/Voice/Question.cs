using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] Answer answer;
    bool answerReady;
    bool questionEnd;
    bool endTalk;
    bool isNextQuestion;

    private void Awake()
    {
        endTalk = false;
        isNextQuestion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNextQuestion)
        {
            if (Input.GetKey(KeyCode.N))
            {
                isNextQuestion = false;
            }
            return;
        }
        if (endTalk && Input.GetKey(KeyCode.X))
        {
            GameManager.Manager.GetUIManager.endTalk();
        }
        else if(endTalk)
        {
            return;
        }
        if (!questionEnd && !answerReady)
        {
            questionEnd = GameManager.Manager.GetUIManager.isEndTalk;
        }
        else if(questionEnd && !answerReady)
        {
            answerReady = true;
            answer.startAnswer();
        }
    }

    private void OnEnable()
    {
        startQuestion();
        //특정 이벤트가 발생할때 실행해야할때 추가로 수정
    }

    public void startQuestion()
    {
        answerReady = false;
        questionEnd = false;
        GameManager.Manager.GetUIManager.ActiveUI(UIs.DialogWindow);
        /*if(GameManager.Manager.GetSttManager.getQuestion() == null)
        {
            GameManager.Manager.GetUIManager.startTalk("심문종료");
            StartCoroutine(waitForCondition());
            return;
        }*///심문종료코드 구현하기
        StartCoroutine(nextQuestion());
        //GameManager.Manager.GetUIManager.startTalk(GameManager.Manager.GetSttManager.getQuestion());
    }

    public void wrongQuestion() 
    {
        endTalk = true;
        questionEnd = false;
        GameManager.Manager.GetUIManager.startTalk("틀렸습니다");
        StartCoroutine(waitForCondition());
    }

    IEnumerator nextQuestion()
    {
        string text;
        while (true)
        {
            text = GameManager.Manager.GetSttManager.getQuestion();
            if(text == null)
            {
                GameManager.Manager.GetUIManager.startTalk("답을 해주세요: ");
                break;
            }
            else
            {
                GameManager.Manager.GetUIManager.startTalk(text);
                isNextQuestion = true;
            }
            while (isNextQuestion)
            {
                yield return null;
            }
        }
    }

    IEnumerator waitForCondition()
    {
        while (!questionEnd)
        {
            questionEnd = GameManager.Manager.GetUIManager.isEndTalk;
            yield return null;
        }
    }
}

