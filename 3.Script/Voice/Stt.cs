using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

public class Stt : MonoBehaviour
{

    public void soundToText()
    {
        string filePath = @"C:/unityGame/CapStone/Assets/6.STT/dist/test.exe";

        // 실행할 외부 프로그램의 경로와 옵션을 포함한 문자열
        string arguments = ""; // 필요한 경우에만 사용

        // 프로세스 시작 정보 설정
        ProcessStartInfo psi = new ProcessStartInfo(filePath);
        psi.Arguments = arguments;
        Process.Start(psi);
        StartCoroutine(conversionTime());
    }

    IEnumerator conversionTime()
    {
        yield return new WaitForSeconds(5f); //녹음과 stt에 문제가 없는 데도 녹음된 내용이 전부 테스트로 전달이 안될경우 이것을 수정
        GameManager.Manager.GetUIManager.getVoiceWindow().voiceText();
    }
}
