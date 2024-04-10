using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("�ε������� ������ ���� ����Ʈ")]
    [Header("����Ʈ ������ npc���̵�")]
    public int npcID;
    [Header("����Ʈ���̵�(����Ʈ������ �ƴ����� �Ǻ��ؾ��ϱ� ������ �ʿ�)")]
    public List<int> questID;
    [Header("����Ʈ�� ���� ���(����Ʈ��ü ���� ��絥���ͺ��̽��� �����)")]
    public List<int> questSpeech;
    [Header("����Ʈ ����(����Ʈâ�� ���鶧 ����ϸ� �ȸ���� ����)")]
    public List<string> contents;
    [Header("����Ʈ ������")]
    public List<string> acceptSpeech;
    [Header("����Ʈ ������")]
    public List<string> rejectSppech;
    [Header("����Ʈ ���� ����(0: ����(������ ����), 1: ������, 2: 2������Ʈ)")]
    public List<int> form;
    [Header("����Ʈ ����(�����۾��̵�, 2������Ʈ-����Ʈ�����ε�����)")]
    public List<int> compensation;
    [Header("����Ʈ �Ϸ�� ��� +  �������� ������ ������ ���⿡ �߰�")]
    public List<string> qespeech;
    [Header("����Ʈ ������(�ݵ�� �������� �ƴ���)")]
    public List<bool> certainly;
}

public class QuestDB : MonoBehaviour
{
    public List<Quest> quest;
}
