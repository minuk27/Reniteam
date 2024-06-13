using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSetting : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle micToggle;

    private void Start()
    {
        // ������ ��ü ȭ�� ������ ������� ��� ���� �ʱ�ȭ
        fullscreenToggle.isOn = Screen.fullScreen;
        micToggle.isOn = PlayerPrefs.GetInt("MicUsage", 0) == 1;

        // ��� �� ���� �� ȣ��� �޼ҵ带 ����
        fullscreenToggle.onValueChanged.AddListener(SetFullScreen);
        micToggle.onValueChanged.AddListener(SetMicUsage);
    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen; // ��ü ȭ�� ��� ����
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetMicUsage(bool useMic)
    {
        PlayerPrefs.SetInt("MicUsage", useMic ? 1 : 0); // ����ũ ��� ���� ����
        PlayerPrefs.Save();
    }
}
