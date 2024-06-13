using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTManager : MonoBehaviour
{
    Dictionary<int, VoiceDB> voiceDictionary;
    private Voice voice;
    private int voiceIndex;
    private int maxVoiceIndex;
    private int voiceEnd; //-1: �⺻��, 0: �ɹ� ��� ����, 1: �ɹ� ��� ���� 
    public void Initialize() //�ʱ�ȭ �ڵ�
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

    public string[] getQuestion() //���� ����
    {
        return voiceDictionary[voiceIndex].question;
    }

    public string[] getWrongResult() //���� Ʋ������ ��� ����
    {
        voiceEnd = 0;
        return voiceDictionary[voiceIndex++].resultWrong;
    }

    public string[] getCorrentResult() //���� �¾����� ��� ����
    {
        if (voiceIndex == maxVoiceIndex)
        {
            voiceEnd = 1;
        }
        return voiceDictionary[voiceIndex++].resultCorrect;
    }

    public int getVoiceEnd { get { return voiceEnd; } }

    public bool interrogate(string[] answer) //�亯 �ؼ�, �亯���� �Ľ��� �Ű������� ������ ����� �ؼ�
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