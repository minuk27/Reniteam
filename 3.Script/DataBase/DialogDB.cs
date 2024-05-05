using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [Header("NPC���̵�")]
    public int id;
    [Header("���")]
    public List<string> speechDB;
    [Header("���۴��(���� ���� �� �ִ� ���� ����ε�����)")]
    public int startSpeech;
    [Header("���������(��纯�濡�� ����� �ε���)")]
    public int endSpeech;
    [Header("��纯��(���� ���� �� �ִ� ������ ����ε�����)")]
    public List<int> speechIndex;
    [Header("���丮�ε�����(����Ʈ�ε����� �������� ��)")]
    public int startQuest;
    [Header("��� �� ����Ʈ�� �ش��ϴ� �ε���")]
    public List<int> questIndex;
    [Header("����Ʈ���̵�")]
    public List<int> questID;
}

public class DialogDB : MonoBehaviour
{
    public List<Dialog> npcDialogDB;
    public void Setting()
    {
        foreach(Dialog i in npcDialogDB)
        {
            i.startSpeech = 0;
            i.endSpeech = 0;
        }
    }
}