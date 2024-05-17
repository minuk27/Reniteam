using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceDB
{
    [Header("대화아이디")]
    public int index;
    [Header("질문")]
    public string[] question;
    [Header("답변")]
    public string[] answer;
}

public class Voice : MonoBehaviour
{
    public List<VoiceDB> voiceDB;
}
