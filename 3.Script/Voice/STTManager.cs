using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class STTManager : MonoBehaviour
{
    private ProcessStartInfo testInfo;
    private ProcessStartInfo wavfileInfo;

    public void Initialize()
    {
        // ������ ������ ��� ����
        string testExe = Path.Combine(Application.dataPath, "6.STT/asd/dist/test.exe");
        string wavfileExe = Path.Combine(Application.dataPath, "6.STT/asd/dist/wavfile.exe");

        // ������ ������ ��ο� �ɼ��� �����Ͽ� ProcessStartInfo ��ü ����
        testInfo = new ProcessStartInfo(testExe);
        wavfileInfo = new ProcessStartInfo(wavfileExe);

        // ���μ��� ����
        //Process.Start(testInfo); //����
        //Process.Start(wavfileInfo); //api����
    }

    public void StartSTT()
    {
        Process.Start(testInfo); //����
        Process.Start(wavfileInfo); //api����
    }
}