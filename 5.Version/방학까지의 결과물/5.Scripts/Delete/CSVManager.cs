using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CSVManager : MonoBehaviour
{
    private DateTime currentTime;
    private bool check = false;
    public TextMeshProUGUI TextTMP;
    public string filePath = "./Assets/8.Data/Test.json";
    [System.Serializable]
    public class MyData
    {
        public MySentence[] sentences;
    }

    [System.Serializable]
    public class MySentence
    {
        public string content;
    }
    void Start() 
    {
        currentTime = File.GetLastWriteTime(filePath);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            Debug.Log("안녕 입력");
            PrintDialog("안녕");
        }
        if (Input.GetKeyDown(KeyCode.S)){
            Debug.Log("안 입력");
            PrintDialog("안");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            check = true;
        }
        if (check)
        {
            JSONCheck();
        }

    }
    private string[] lines;
    private void Awake()
    {
        string filePath2 = "./Assets/7.StreamingAssets/Test.csv";
        if (!File.Exists(filePath2))
        {
            Debug.LogError("File not found: " + filePath2);
        }

        lines = File.ReadAllLines(filePath2);

    }

    public void JSONCheck()
    {
        DateTime lastWriteTime = File.GetLastWriteTime(filePath);
        if (currentTime != lastWriteTime)
        {
            currentTime = lastWriteTime;
            Debug.Log("변환완료시간" + currentTime);
            PrintDialog(LoadSTTText());
            check = false;
        }
    }

    public string LoadSTTText() 
    {
        string jsonString = File.ReadAllText(filePath); // 파일로부터 JSON 읽기

        MyData data = JsonUtility.FromJson<MyData>(jsonString);

        if (data != null && data.sentences.Length > 0)
        {
            string extractedText = data.sentences[0].content;
            Debug.Log("Extracted Text: " + extractedText);
            string[] values = extractedText.Split('"');
            if (values.Length >= 4)
            {
                return values[3];
            }
        }
        return "";
    }

    public void PrintDialog(string inputString)
    {
        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            if (values.Length >= 2 && values[0].Trim() == inputString)
            {
                TextTMP.text = values[1];
            }
        }
        //Debug.LogWarning("Not Found");
    }
}