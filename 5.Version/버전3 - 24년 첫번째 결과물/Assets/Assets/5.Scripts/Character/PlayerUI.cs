using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    private VoiceRange voiceRange;

    public bool isTalk;
    private float nowTime;
    private float delay;
    private int id;

    private void Awake()
    {
        inventory.SetActive(false);

        voiceRange = GetComponentInChildren<VoiceRange>();

        isTalk = false;
        nowTime = 1.1f;
        delay = 0.2f;
        id = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowTime < delay)
        {
            nowTime += Time.deltaTime;
            return;
        }
        if (Input.GetKey(KeyCode.I))
        {
            inventory.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Z))
        {            
            if (!isTalk)
            {
                id = voiceRange.getnpcID(this.gameObject.transform.position);
                if (id == 0)
                    return;
                isTalk = true;
                GetComponent<Player>().MoveStop();
                nowTime = 0f;
                GameManager.Manager.GetUIManager.ActiveUI(UIs.ChatWindow);
                GameManager.Manager.GetUIManager.GetChatWindow.StartTalk(id, TalkForm.BasicTalk);
            }
            else if(GameManager.Manager.GetUIManager.GetChatWindow.EndTalk && !GameManager.Manager.GetQuestManager.IsQuest)
            {
                if (GameManager.Manager.GetSetTalkManager.RemineTalk(id))
                {
                    GameManager.Manager.GetUIManager.GetChatWindow.StartTalk(id, TalkForm.BasicTalk);
                    nowTime = 0f;
                }
                else
                {
                    isTalk = false;
                    GetComponent<Player>().MoveStart();
                    nowTime = 0f;
                    GameManager.Manager.GetSetTalkManager.ResetTalk(id);
                    id = 0;
                    GameManager.Manager.GetUIManager.InactiveUI(UIs.ChatWindow);
                }
            }
            if(isTalk && GameManager.Manager.GetQuestManager.IsQuest)
            {

            }
        }
        if (Input.GetKey(KeyCode.X) && isTalk && !GameManager.Manager.GetQuestManager.IsQuest)
        {
            if (isTalk)
            {
                isTalk = false;
                GetComponent<Player>().MoveStart();
                nowTime = 0f;
                GameManager.Manager.GetSetTalkManager.ResetTalk(id);
                id = 0;
                GameManager.Manager.GetUIManager.InactiveUI(UIs.ChatWindow);
            }
        }
    }
}
