using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("����Ʈ���̵�")]
    public int questID;
    [Header("����Ʈ ������")]
    public string acceptSpeech;
    [Header("����Ʈ ������")]
    public string rejectSppech;
    [Header("����Ʈ ���� ����(0: ����(������ ����), 1: ������, 2: 2������Ʈ)")]
    public int form;
    [Header("���丮�б�(��纯��, ���丮�����)")]
    public bool change;
    [Header("����Ʈ ������(�ݵ�� �������� �ƴ���)")]
    public bool certainly;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
