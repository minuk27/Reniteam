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
    private string audioFilePath = "Assets/8.Data/output.wav"; // 오디오 파일의 올바른 경로로 변경하세요

    public void StartRecoding()
    {
        // 음성인식(STT) 함수 호출
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

        // 비동기로 요청 보내기
        AsyncOperation asyncOperation = www.SendWebRequest();

        // 요청이 완료될 때까지 대기
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // 요청이 완료되면 처리
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError($"음성인식(STT)이 실패했습니다: {www.error}");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            // 감정 분석 함수 호출
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
        www.downloadHandler = new DownloadHandlerBuffer(); // 수정된 부분
        www.SetRequestHeader("Content-Type", "application/json");

        www.SendWebRequest().completed += (operation) =>
        {
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError($"감정 분석이 실패했습니다: {www.error}");
            }
            else
            {
                Debug.Log($"감정 분석 결과가 저장되었습니다: {www.downloadHandler.text}");
                Debug.Log(www.downloadHandler.text);
            }
        };
    }
}