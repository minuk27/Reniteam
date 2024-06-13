using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTManager : MonoBehaviour
{
    Dictionary<int, VoiceDB> voiceDictionary;
    private Voice voice;
    private int voiceIndex;
    private int maxVoiceIndex;
    private int voiceEnd; //-1: 기본값, 0: 심문 통과 실패, 1: 심문 통과 성공 
    public void Initialize() //초기화 코드
    {
        voiceIndex = 0;
        voiceDictionary = new Dictionary<int, VoiceDB>();
        voice = Resources.Load<GameObject>("Voice").GetComponent<Voice>();
        for (int i = 0; i < voice.voiceDB.Count; i++)
        {
            voiceDictionary.Add(voice.voiceDB[i].index, voice.voiceDB[i]);
        }
        maxVoiceIndex = voiceDictionary.Count - 1;
        voiceEnd = -1;
    }

    public string[] getQuestion() //질문 전달
    {
        return voiceDictionary[voiceIndex].question;
    }

    public string[] getWrongResult() //질문 틀렸을때 결과 전달
    {
        voiceEnd = 0;
        return voiceDictionary[voiceIndex++].resultWrong;
    }

    public string[] getCorrentResult() //질문 맞았을때 결과 전달
    {
        if (voiceIndex == maxVoiceIndex)
        {
            voiceEnd = 1;
        }
        return voiceDictionary[voiceIndex++].resultCorrect;
    }

    public int getVoiceEnd { get { return voiceEnd; } }

    public bool interrogate(string[] answer) //답변 해석, 답변문장 파싱을 매개변수로 받은뒤 정답과 해석
    {
        bool isCorrect = false;
        for (int i = 0; i < voiceDictionary[voiceIndex].answer.Length; i++)
        {
            for(int j = 0; j< answer.Length; j++)
            {
                if (voiceDictionary[voiceIndex].answer[i].Equals(answer[j].Trim()))
                {
                    isCorrect = true;
                    break;
                }
            }
            if (!isCorrect)
            {
                break;
            }
        }
        return isCorrect;
    }
}