using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class STTManager : MonoBehaviour
{
    private ProcessStartInfo testInfo;

    public void Initialize()
    {
        // 실행할 파일의 경로 설정
        string testExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/test.exe");

        // 실행할 파일의 경로와 옵션을 지정하여 ProcessStartInfo 객체 생성
        testInfo = new ProcessStartInfo(testExe);

        // 프로세스 시작
        //Process.Start(testInfo); //api보냄
    }

    public void StartSTT()
    {
        Process.Start(testInfo); //api보냄
    }
}