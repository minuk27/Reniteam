using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{
    private string filePath = "./Assets/8.Data/nouns.json"; // JSON ���� ���
    [SerializeField] Answer answer;


    public void voiceText()
    {
        string jsonString = File.ReadAllText(filePath); // ���Ϸκ��� JSON �б�
        answer.setAnswerText(jsonString);
    }
}