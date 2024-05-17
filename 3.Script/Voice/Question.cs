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
        //Ư�� �̺�Ʈ�� �߻��Ҷ� �����ؾ��Ҷ� �߰��� ����
    }

    public void startQuestion()
    {
        answerReady = false;
        questionEnd = false;
        GameManager.Manager.GetUIManager.ActiveUI(UIs.DialogWindow);
        /*if(GameManager.Manager.GetSttManager.getQuestion() == null)
        {
            GameManager.Manager.GetUIManager.startTalk("�ɹ�����");
            StartCoroutine(waitForCondition());
            return;
        }*///�ɹ������ڵ� �����ϱ�
        StartCoroutine(nextQuestion());
        //GameManager.Manager.GetUIManager.startTalk(GameManager.Manager.GetSttManager.getQuestion());
    }

    public void wrongQuestion() 
    {
        endTalk = true;
        questionEnd = false;
        GameManager.Manager.GetUIManager.startTalk("Ʋ�Ƚ��ϴ�");
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
                GameManager.Manager.GetUIManager.startTalk("���� ���ּ���: ");
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

