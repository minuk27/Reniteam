using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class NaverApiManager : MonoBehaviour
{
    private string id = "phj39le2su";
    private string server = "ZpILLdKt80pCTaKYtLOIysCioD4fQMApCnDkFUa0";
    private string audioFilePath = "Assets/8.Data/output.wav"; // ����� ������ �ùٸ� ��η� �����ϼ���

    public void StartRecoding()
    {
        // �����ν�(STT) �Լ� ȣ��
        StartCoroutine(STT(id, server, audioFilePath));
    }

    IEnumerator STT(string Id, string Server, string audioFilePath)
    {
        string lang = "Kor";
        string url = "https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang=" + lang;

        byte[] audioData = File.ReadAllBytes(audioFilePath);

        UnityWebRequest www = new UnityWebRequest(url, "POST");
        UploadHandlerRaw uH = new UploadHandlerRaw(audioData);
        www.uploadHandler = uH;

        www.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", Id);
        www.SetRequestHeader("X-NCP-APIGW-API-KEY", Server);
        www.SetRequestHeader("Content-Type", "application/octet-stream");

        // �񵿱�� ��û ������
        AsyncOperation asyncOperation = www.SendWebRequest();

        // ��û�� �Ϸ�� ������ ���
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // ��û�� �Ϸ�Ǹ� ó��
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError($"�����ν�(STT)�� �����߽��ϴ�: {www.error}");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            // ���� �м� �Լ� ȣ��
            EmotionAnalysis(Id, Server, www.downloadHandler.text);
        }
    }

    void EmotionAnalysis(string Id, string Server, string contents)
    {
        string url = "https://naveropenapi.apigw.ntruss.com/sentiment-analysis/v1/analyze";

        Dictionary<string, string> headers = new Dictionary<string, string>
    {
        { "X-NCP-APIGW-API-KEY-ID", Id },
        { "X-NCP-APIGW-API-KEY", Server },
        { "Content-Type", "application/json" }
    };

        Dictionary<string, string> data = new Dictionary<string, string>
    {
        { "content", contents }
    };

        byte[] postData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));

        UnityWebRequest www = new UnityWebRequest(url, "POST");
        UploadHandlerRaw uH = new UploadHandlerRaw(postData);
        www.uploadHandler = uH;
        www.downloadHandler = new DownloadHandlerBuffer(); // ������ �κ�
        www.SetRequestHeader("Content-Type", "application/json");

        www.SendWebRequest().completed += (operation) =>
        {
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError($"���� �м��� �����߽��ϴ�: {www.error}");
            }
            else
            {
                Debug.Log($"���� �м� ����� ����Ǿ����ϴ�: {www.downloadHandler.text}");
                Debug.Log(www.downloadHandler.text);
            }
        };
    }
}