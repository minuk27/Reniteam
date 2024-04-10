using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, DialogDB> talkDictionary;

    private NPCDialogDB dialog;

    public void Initialize()
    {
        talkDictionary = new Dictionary<int, DialogDB>();
        SetTalk();
    }

    public void SetTalk()
    {
        dialog = Resources.Load<GameObject>("NPCDialogDB").GetComponent<NPCDialogDB>();
        dialog.Setting();
        for (int i = 0; i < dialog.npcDialogDB.Count; i++)
        {
            talkDictionary.Add(dialog.npcDialogDB[i].id, dialog.npcDialogDB[i]);
        }
    }

    public string GetTalk(int npcID)
    {
        int speechIndex = talkDictionary[npcID].currentSpeechIndex;
        Debug.Log(talkDictionary[npcID].isQuest);
        if (talkDictionary[npcID].isQuest && speechIndex == GameManager.Manager.GetQuestManager.GetQuest(npcID))
        {
            Debug.Log("����");
            GameManager.Manager.GetQuestManager.StartQuest();
        }
        talkDictionary[npcID].currentSpeechIndex += 1;
        return talkDictionary[npcID].speechDB[speechIndex];
    }

    public bool RemineTalk(int npcID) //���翡�� �Ҽ��ִ� ��簡 �����ֳ� �ƴϳĸ� �Ǵ�
    {
        return talkDictionary[npcID].currentSpeechIndex <= talkDictionary[npcID].speechIndex[GameManager.Manager.GetStoryManager.CurrentStep()];
    }

    public void ResetTalk(int npcID) {talkDictionary[npcID].currentSpeechIndex = talkDictionary[npcID].speechFirstIndex;}

    public Sprite GetSprite(int npcID)
    {
        return talkDictionary[npcID].npcSprite;
    }
}