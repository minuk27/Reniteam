using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    [SerializeField] Stt stt;
    [SerializeField] GameObject timer;
    AudioClip record;
    AudioSource aud;
    private int recordTime;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        recordTime = 5;
    }

    

    public void PlaySnd()
    {
        aud.Play();
        //SavWav.Save("test", aud.clip);
    }

    public void RecSnd()
    {
        //����̽� Ȯ�ο� �ڵ��, �����ص� �ȴ�
        /*foreach (var device in Microphone.devices)
        {
            Debug.Log("��������");
        }*/
        Debug.Log("��������");
        record = Microphone.Start(Microphone.devices[0].ToString(), false, recordTime, 44100); // recordTime (�� 10)�� ����
        timer.SetActive(true);
        timer.GetComponent<Timer>().startTime();
        aud.volume = 100f;
        aud.clip = record;
        StartCoroutine(recordSaveStart());
    }

    IEnumerator recordSaveStart()
    {
        yield return new WaitForSeconds(recordTime+0.5f);
        SavWav.Save("test", aud.clip);
        yield return new WaitForSeconds(0.5f);
        stt.soundToText();
    }
}