using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceDB
{
    [Header("��ȭ���̵�")]
    public int index;
    [Header("����")]
    public string[] question;
    [Header("�亯")]
    public string[] answer;
}

public class Voice : MonoBehaviour
{
    public List<VoiceDB> voiceDB;
}
