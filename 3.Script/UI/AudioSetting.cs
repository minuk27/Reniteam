using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public Slider volumeSlider; // ����� ���� �����̴�

    private void Start()
    {
        // ����� ���� �� �ҷ����� �Ǵ� �⺻�� ����
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);

        // �����̴� �� ���� �� ȣ��� �޼ҵ带 ����
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // ��ü ����� ���� ����
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}
