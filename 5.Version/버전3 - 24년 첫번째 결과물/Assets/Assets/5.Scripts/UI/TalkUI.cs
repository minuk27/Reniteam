using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TalkForm
{
    BasicTalk, QuestTalk
}

public class TalkUI : MonoBehaviour
{
    [SerializeField]
    private Text talkText;
    [SerializeField]
    private Image npcFace;
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject selectUI;
    private bool endTalk;

    private void Awake()
    {
        endTalk = true;
        arrow.SetActive(false);
        selectUI.SetActive(false);
    }

    private void Start()
    {
        GameManager.Manager.GetUIManager.CreateUI(this.gameObject, this.GetComponent<TalkUI>());
    }
    
    public void StartTalk(int npcID, TalkForm form)
    {
        npcFace.sprite = GameManager.Manager.GetSetTalkManager.GetSprite(npcID);
        talkText.text = "";
        endTalk = false;
        StartCoroutine(TypingEffect(GameManager.Manager.GetSetTalkManager.GetTalk(npcID), GameManager.Manager.GetQuestManager.IsQuest));

        /*switch (form)
        {
            case TalkForm.BasicTalk:
                arrow.SetActive(true);
                
                break;
            case TalkForm.QuestTalk:
                break;
        }*/
    }

    IEnumerator TypingEffect(string talk, bool isQuest)
    {
        for(int i = 0; i< talk.Length; i++)
        {
            talkText.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
        endTalk = true;
        arrow.GetComponent<Animator>().SetTrigger("Move");
        if (isQuest)
        {
            selectUI.SetActive(true);
        }
    }

    public bool EndTalk { get { return endTalk; } }

    public void OnDisable()
    {
        talkText.text = "";
        //npcFace = null;
    }

    public void OnClickPositive()
    {

    }

    public void OnClickNegetive()
    {

    }
}