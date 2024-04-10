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
    [Header("���� ����ε���(�ڵ峻���� ���������� 0���� ����)")]
    public int currentSpeechIndex;
    [Header("ù��°����ε�����(�ڵ峻���� ���������� 0���� ����")]
    public int speechFirstIndex;
    [Header("��纯��(�����丮���� ���Ҽ� �ִ� ������ �ε�����)")]
    public List<int> speechIndex;
    [Header("���丮�б�(���丮�Ŵ����� ������ ���丮���� ���ƾ� ������)")]
    public List<int> storyIndex;
    [Header("npc ����")]
    public Sprite npcSprite;
    [Header("����Ʈ����")]
    public bool isQuest;
}

public class NPCDialogDB : MonoBehaviour
{
    [SerializeField]
    public List<DialogDB> npcDialogDB;

    public void Setting()
    {
        foreach(DialogDB i in npcDialogDB)
        {
            i.currentSpeechIndex = 0;
            i.speechFirstIndex = 0;
        }
    }
}