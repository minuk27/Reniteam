using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogState
{
    [Header("NPC���̵�")]
    public int id;
    [Header("����Ʈ����")]
    public bool quest;
    [Header("����Ʈ���̵�")]
    public int[] questID;
}

public class NPC : MonoBehaviour
{
    [SerializeField]
    NPCDialogState npcDialog;

    public int GetID { get { return npcDialog.id; } }
}