using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Microphonea : MonoBehaviour
{
    public string id = "A1AIG817u9N7svAaqBwuEqqiI5y2wKLfjROagNpo";
    public string serverKey = "s5cnwsoc86";

    void Start()
    {
        StartCoroutine(RecordAndTranscribe(id, serverKey));
    }

    IEnumerator RecordAndTranscribe(string id, string serverKey)
    {
        string lang = "Kor";
        string url = $"https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang={lang}";

        // 마이크에서 오디오 데이터 캡처
        AudioClip audioClip = Microphone.Start(null, false, 10, 44100);
        yield return new WaitForSeconds(10); // 캡처 시간 (초)

        // 오디오 데이터를 바이트 배열로 변환
        float[] samples = new float[audioClip.samples * audioClip.channels];
        audioClip.GetData(samples, 0);
        byte[] audioData = ConvertAudioClipData(samples);

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(audioData);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/octet-stream");
            www.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", id);
            www.SetRequestHeader("X-NCP-APIGW-API-KEY", serverKey);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("STT 결과: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("STT 요청 실패. 오류: " + www.error);
            }
        }

        // 마이크 중지
        Microphone.End(null);
    }

byte[] ConvertAudioClipData(float[] samples)
{
    byte[] audioData = new byte[samples.Length * 2]; // 16-bit PCM
    int rescaleFactor = 32767;

    for (int i = 0; i < samples.Length; i++)
    {
        short value = (short)(samples[i] * rescaleFactor);
        audioData[i * 2] = (byte)(value & 0xFF);
        audioData[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
    }

    return audioData;
}
}