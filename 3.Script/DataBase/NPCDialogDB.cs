using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogDB
{
    [Header("NPC아이디")]
    public int id;
    [Header("대사")]
    public string[] speechDB;
    [Header("대사키(어떤 말인지 예: 인사, 퀘스트")]
    public string[] speechID;
    [Header("퀘스트 유무")]
    public bool quest;
    [Header("퀘스트아이디")]
    public int[] questID;
}

public class Dialog
{
    public int id;
    public Dictionary<string, string> speech; //키: 어떤 말인지 또는 질문, 값: 키값에 의한 응답
    public int[] questID;
}

public class NPCDialogDB : MonoBehaviour
{
    [SerializeField]
    private List<DialogDB> npcDialogDB;
    public List<Dialog> npcDialog;

    public void Setting()
    {
        npcDialog = new List<Dialog>();
        Dialog newDialog;
        for (int i = 0; i < npcDialogDB.Count; i++)
        {
            newDialog = new Dialog();
            newDialog.id = npcDialogDB[i].id;
            newDialog.speech = new Dictionary<string, string>();
            for (int j = 0; j < npcDialogDB[i].speechDB.Length; j++)
            {
                newDialog.speech.Add(npcDialogDB[i].speechID[j], npcDialogDB[i].speechDB[j]);
            }
            if (npcDialogDB[i].quest)
            {
                for (int j = 0; j < npcDialogDB[i].questID.Length; j++)
                {
                    newDialog.questID[j] = npcDialogDB[i].questID[j];
                }
            }
            else
            {
                newDialog.questID = null;
            }
            npcDialog.Add(newDialog);
        }
    }
}