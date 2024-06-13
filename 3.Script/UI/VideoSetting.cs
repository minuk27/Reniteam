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
        // 현재의 전체 화면 설정을 기반으로 토글 상태 초기화
        fullscreenToggle.isOn = Screen.fullScreen;
        micToggle.isOn = PlayerPrefs.GetInt("MicUsage", 0) == 1;

        // 토글 값 변경 시 호출될 메소드를 설정
        fullscreenToggle.onValueChanged.AddListener(SetFullScreen);
        micToggle.onValueChanged.AddListener(SetMicUsage);
    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen; // 전체 화면 모드 설정
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetMicUsage(bool useMic)
    {
        PlayerPrefs.SetInt("MicUsage", useMic ? 1 : 0); // 마이크 사용 설정 저장
        PlayerPrefs.Save();
    }
}
