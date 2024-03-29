using UnityEngine;
using System.IO;



public class JsonParser : MonoBehaviour
{
    public string filePath = "./Assets/8.Data/Test.json"; // JSON ���� ���
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
        string jsonString = File.ReadAllText(filePath); // ���Ϸκ��� JSON �б�

        MyData data = JsonUtility.FromJson<MyData>(jsonString);

        if (data != null && data.sentences.Length > 0)
        {
            string extractedText = data.sentences[0].content;
            Debug.Log("Extracted Text: " + extractedText);
            string[] values = extractedText.Split('"');
            if (values.Length >= 2)
            {
                UnityEngine.Debug.Log(values[3]);
            }
        }
        else
        {
            Debug.Log("Error parsing JSON or no data found.");
        }
    }
}