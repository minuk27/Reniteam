using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    // Update is called once per frame
    public void GenerateData()
    {
        talkData = new Dictionary<int, string[]>();
    }

    public void SetTalk(int id, string[] speech)
    {
        talkData[id] = speech;
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }
}