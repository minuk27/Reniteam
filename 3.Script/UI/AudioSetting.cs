using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public Slider volumeSlider; // 오디오 볼륨 슬라이더

    private void Start()
    {
        // 저장된 볼륨 값 불러오기 또는 기본값 설정
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);

        // 슬라이더 값 변경 시 호출될 메소드를 설정
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // 전체 오디오 볼륨 설정
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}
