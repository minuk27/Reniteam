using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogDB
{
    [Header("NPC���̵�")]
    public int id;
    [Header("���")]
    public string[] speechDB;
    [Header("���Ű(� ������ ��: �λ�, ����Ʈ")]
    public string[] speechID;
    [Header("����Ʈ ����")]
    public bool quest;
    [Header("����Ʈ���̵�")]
    public int[] questID;
}

public class Dialog
{
    public int id;
    public Dictionary<string, string> speech; //Ű: � ������ �Ǵ� ����, ��: Ű���� ���� ����
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