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
        // ������ ������ ��� ����
        string testExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/test.exe");
        string wavfileExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/wavfile.exe");

        // ������ ������ ��ο� �ɼ��� �����Ͽ� ProcessStartInfo ��ü ����
        //testInfo = new ProcessStartInfo(testExe);
        //wavfileInfo = new ProcessStartInfo(wavfileExe);

        // ���μ��� ����
        //Process.Start(testInfo); //api����
        //Process.Start(wavfileInfo); //����
    }

    public void StartSTT()
    {
        //Process.Start(wavfileInfo); //����
        //Process.Start(testInfo); //api����
    }
}