using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MicrophoneExample : MonoBehaviour
{
    private string id = "ZpILLdKt80pCTaKYtLOIysCioD4fQMApCnDkFUa0";
    private string serverKey = "phj39le2su";

    public void StartRecoding()
    {
        StartCoroutine(RecordAndTranscribe(this.id, this.serverKey));
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

    byte[] ConvertAudioClipData(float[] Samples)
    {
        byte[] audioData = new byte[Samples.Length * 2]; // 16-bit PCM
        int rescaleFactor = 32767;

        for (int i = 0; i < Samples.Length; i++)
        {
            short value = (short)(Samples[i] * rescaleFactor);
            audioData[i * 2] = (byte)(value & 0xFF);
            audioData[i * 2 + 1] = (byte)((value >> 8) & 0xFF);
        }

        return audioData;
    }
}