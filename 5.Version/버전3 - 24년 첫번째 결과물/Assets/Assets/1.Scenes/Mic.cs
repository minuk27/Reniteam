using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    AudioClip record;
    AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySnd()
    {
        aud.Play();
        SavWav.Save("./Assets/8.Data", aud.clip);
    }

    public void RecSnd()
    {
        // ����̽� Ȯ�ο� �ڵ��, �����ص� �ȴ�
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        record = Microphone.Start(Microphone.devices[0].ToString(), false, 3, 44100); // 3�� ����
        aud.clip = record;
        aud.volume = 10f;

    }
}
