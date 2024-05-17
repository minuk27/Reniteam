using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class JsonTest : MonoBehaviour
{
    private string filePath = "./Assets/8.Data/nouns.json"; // JSON 파일 경로
    [SerializeField] Answer answer;


    public void voiceText()
    {
        string jsonString = File.ReadAllText(filePath); // 파일로부터 JSON 읽기
        answer.setAnswerText(jsonString);
    }
}