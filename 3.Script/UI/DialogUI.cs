using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    [SerializeField] GameObject talkContents;
    [SerializeField] Text talkText;
    [SerializeField] GameObject talkArrow;
    [SerializeField] GameObject selectWindow;
    private Coroutine textCoroutine;
    private bool endTalk;
    private bool isQuest;

    private void Awake()
    {
        ActiveFalse();
    }

    public void ActiveFalse()
    {
        talkContents.SetActive(false);
        talkArrow.SetActive(false);
        selectWindow.SetActive(false);
        endTalk = false;
        isQuest = false;
        textCoroutine = null;
    }

    public void setText(string text)
    {
        if(textCoroutine != null)
            StopCoroutine(textCoroutine);
        endTalk = false;
        textCoroutine = StartCoroutine(writeText(text));
    }

    IEnumerator writeText(string text)
    {
        talkContents.SetActive(true);
        talkText.text = "";
        foreach (char t in text)
        {
            talkText.text += t;
            yield return new WaitForSeconds(0.05f);
        }
        endTalk = true;
        talkArrow.SetActive(true);
        talkArrow.GetComponent<Animator>().SetTrigger("Move");
        if (isQuest)
            selectWindow.SetActive(true);
    }

    public void startQuestWindow()  { isQuest = true; }

    public void endQuestWindow() 
    { 
        isQuest = false;
        selectWindow.SetActive(false);
    }

    public bool isEndTalk 
    { 
        get 
        {
            if (isQuest)
            {
                return false;
            }
            return endTalk; 
        } 
    }

    public void changeText(FontStyle style)
    {
        talkText.fontStyle = style;
    }
}
