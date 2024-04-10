using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogState
{
    [Header("NPC아이디")]
    public int id;
    [Header("퀘스트유무")]
    public bool quest;
    [Header("퀘스트아이디")]
    public int[] questID;
}

public class NPC : MonoBehaviour
{
    [SerializeField]
    NPCDialogState npcDialog;

    public int GetID { get { return npcDialog.id; } }
}