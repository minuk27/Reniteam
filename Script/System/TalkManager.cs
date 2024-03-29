using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, Dialog> talkDictionary = new Dictionary<int, Dialog>();
    private NPCDialogDB dialog;
    private int talkTarget;

    // Update is called once per frame
    public void Initialize()
    {
        SetTalk();
        talkTarget = -1;
    }

    public void SetTalk()
    {
        dialog = Resources.Load<GameObject>("NPCDialogDB").GetComponent<NPCDialogDB>();
        dialog.Setting();
        for (int i = 0; i < dialog.npcDialog.Count; i++)
        {
            talkDictionary.Add(dialog.npcDialog[i].id, dialog.npcDialog[i]);
        }
    }

    public void GetTalk(string voice) //����
    {

    }
}