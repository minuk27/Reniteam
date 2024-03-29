using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("����Ʈ ���̵�")]
    public int questID;
    [Header("����Ʈ ������ npc���̵�")]
    public int npcID;
    [Header("����Ʈ ����")]
    public string contents;
    [Header("����Ʈ ���� ����(1: ����, 2: ������)")]
    public int form;
    [Header("����Ʈ ����(����: ��ȭ���̵�, ������: �����۾��̵�)")]
    public int compensation;
    [Header("����Ʈ ���� ����")]
    public bool succes;
    [Header("����Ʈ ����2����")]
    public bool form2;//����Ʈ ����2���� -> 2������Ʈ(��������Ʈ�� ������ ����Ʈ) -> ����2�� �� ���� ��(��: ������ ������ ���ÿ� �ٰ��) int������ ��ü
    [Header("2������Ʈ ���̵�(������ 0)")]
    public int compensation2;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
