using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalk : MonoBehaviour
{
    Player player;
    NPCTalk npcTalk;
    Item item;
    [SerializeField] Button questYesButton;
    [SerializeField] Button questNoButton;
    float delayTime, nowTime;
    bool isTalk;
    int talkTarget;
    bool questTalk;

    private void Awake()
    {
        nowTime = 0f;
        delayTime = 0.5f;
        isTalk = false;
        questTalk = false;
        talkTarget = -1;
        questYesButton.onClick.AddListener(yesOnClick);
        questNoButton.onClick.AddListener(noOnClick);
    }

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nowTime < delayTime)
        {
            nowTime += Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Z))
            {
                GameObject target = player.getNPCItem(this.gameObject.transform.position);
                switch (player.getTargetType)
                {
                    case -1:
                        talkTarget = -1;
                        return;
                    case 0:
                        npcTalk = target.GetComponent<NPCTalk>();
                        talkTarget = 0;
                        break;
                    case 1:
                        item = target.GetComponent<Item>();
                        talkTarget = 1;
                        break;
                }
                player.moveStop();
                if (talkTarget == 0)
                {
                    nowTime = 0f;
                    if (!isTalk)
                    {
                        isTalk = true;
                        switch (npcTalk.getType)
                        {
                            case TalkType.Basic:
                                GameManager.Manager.getUIManager.getDialogWindow.setText(npcTalk.getBasicTalk.getSpeech);
                                break;
                            case TalkType.Quest:
                                GameManager.Manager.getUIManager.getDialogWindow.setText(npcTalk.getQuestTalk.getSpeech);
                                if (npcTalk.getQuestTalk.getNowStep == 1 && npcTalk.getQuestTalk.getIsQuestSpeech)
                                {
                                    isTalk = false;
                                }
                                if (npcTalk.getQuestTalk.getNowStep == 1 && !npcTalk.getQuestTalk.getIsQuestSpeech)
                                {
                                    GameManager.Manager.getUIManager.getDialogWindow.startQuestWindow();
                                    //questTalk = true;
                                    return;
                                }
                                break;
                        }
                    }
                    else if (isTalk)
                    {
                        if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                        {
                            isTalk = false;
                            player.moveStart();
                            GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
                        }
                    }
                }
                if(talkTarget == 1)
                {
                    if (!isTalk)
                    {                        
                        isTalk = true;
                        switch (item.getType)
                        {
                            case ItemType.Basic:
                                GameManager.Manager.getUIManager.getDialogWindow.setText(item.getBasicItem.getSpeech);
                                break;
                            case ItemType.ChoiceOwn:
                                GameManager.Manager.getUIManager.getDialogWindow.setText(item.getChoiceOwnItem.getSpeech);
                                isTalk = false;
                                if (item.getChoiceOwnItem.getNowStep == 1)
                                {
                                    GameManager.Manager.getUIManager.getDialogWindow.startQuestWindow();
                                }
                                else if (item.getChoiceOwnItem.getNowStep == 2)
                                    isTalk = true;
                                break;
                            case ItemType.ChoiceMove:
                                GameManager.Manager.getUIManager.getDialogWindow.setText(item.getChoiceMoveItem.getSpeech);
                                isTalk = false;
                                if (item.getChoiceMoveItem.getNowStep == 1)
                                {
                                    GameManager.Manager.getUIManager.getDialogWindow.startQuestWindow();
                                }
                                break;
                            case ItemType.Nothing:
                                return;
                        }
                    }
                    else if (isTalk)
                    {
                        if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                        {
                            isTalk = false;
                            player.moveStart();
                            GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
                        }
                    }
                    nowTime = 0f;
                }
            }
        }
    }

    public void yesOnClick()
    {
        questTalk = false;
        if (talkTarget == -1)
            return;
        else if (talkTarget == 0)
        {
            npcTalk.getQuestTalk.acceptQuest();
            GameManager.Manager.getUIManager.getDialogWindow.setText(npcTalk.getQuestTalk.getSpeech);
        }
        else if (talkTarget == 1)
        {
            switch (item.getType)
            {
                case ItemType.ChoiceOwn:
                    item.getChoiceOwnItem.acceptChoice();
                    GameManager.Manager.getUIManager.getDialogWindow.setText(item.getChoiceOwnItem.getSpeech);
                    Destroy(item.gameObject);
                    break;
                case ItemType.ChoiceMove:
                    item.getChoiceMoveItem.acceptChoice();
                    GameManager.Manager.getUIManager.getDialogWindow.endQuestWindow();
                    GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
                    break;
            }
        }
        GameManager.Manager.getUIManager.getDialogWindow.endQuestWindow();
    }
    public void noOnClick()
    {
        if (talkTarget == -1)
            return;
        else if(talkTarget == 0)
        {
            npcTalk.getQuestTalk.failureQuest();
            GameManager.Manager.getUIManager.getDialogWindow.setText(npcTalk.getQuestTalk.getSpeech);
        }
        else if(talkTarget == 1)
        {
            switch (item.getType)
            {
                case ItemType.ChoiceOwn:
                    item.getChoiceOwnItem.failureChoice();
                    GameManager.Manager.getUIManager.getDialogWindow.setText(item.getChoiceOwnItem.getSpeech);
                    break;
                case ItemType.ChoiceMove:
                    item.getChoiceMoveItem.failureChoice();
                    GameManager.Manager.getUIManager.getDialogWindow.setText(item.getChoiceMoveItem.getSpeech);
                    isTalk = true;
                    break;
            }
        }
        questTalk = false;
        GameManager.Manager.getUIManager.getDialogWindow.endQuestWindow();
    }
    
    public void setTalkState()
    {
        isTalk = true;
        questTalk = true;
    }
}
