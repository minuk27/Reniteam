using UnityEngine;
//using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class STTManager : MonoBehaviour
{
    //private ProcessStartInfo testInfo;
    //private ProcessStartInfo wavfileInfo;

    public void Initialize()
    {
        // 실행할 파일의 경로 설정
        string testExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/test.exe");
        string wavfileExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/wavfile.exe");

        // 실행할 파일의 경로와 옵션을 지정하여 ProcessStartInfo 객체 생성
        //testInfo = new ProcessStartInfo(testExe);
        //wavfileInfo = new ProcessStartInfo(wavfileExe);

        // 프로세스 시작
        //Process.Start(testInfo); //api보냄
        //Process.Start(wavfileInfo); //녹음
    }

    public void StartSTT()
    {
        //Process.Start(wavfileInfo); //녹음
        //Process.Start(testInfo); //api보냄
    }
}