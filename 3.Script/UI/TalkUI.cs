using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI : MonoBehaviour
{
    [SerializeField]
    private GameObject talkContents;
    [SerializeField]
    private Text talkText;
    [SerializeField]
    private GameObject talkArrow;
    [SerializeField]
    private GameObject selectWindow;
    private bool endTalk;
    private bool isQuest;

    public void ActiveFalse()
    {
        talkContents.SetActive(false);
        talkArrow.SetActive(false);
        selectWindow.SetActive(false);
        endTalk = false;
        isQuest = false;
    }

    public void SetText(string talk)
    {
        talkContents.SetActive(true);
        talkArrow.SetActive(true);
        StartCoroutine(WriteText(talk));
    }

    public bool IsEndTalk { get { return isQuest ? false : endTalk; } }

    IEnumerator WriteText(string talk)
    {
        talkText.text = "";
        foreach (char s in talk)
        {
            talkText.text += s;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.1f);
        talkArrow.GetComponent<Animator>().SetTrigger("Move");
        endTalk = true;
        if (isQuest)
        {
            selectWindow.SetActive(true);
        }
    }

    public void ActiveQuest()
    {
        isQuest = true;
    }

    public void OnClickPositive()
    {
        isQuest = false;
        Debug.Log("네");
    }

    public void OnClickNegative()
    {
        isQuest = false;
        Debug.Log("아니요");
    }
}
