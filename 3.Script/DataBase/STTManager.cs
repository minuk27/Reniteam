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
        // ������ ������ ��� ����
        string testExe = Path.Combine(Application.dataPath, "6.STT/test_noconsole/dist/test.exe");

        // ������ ������ ��ο� �ɼ��� �����Ͽ� ProcessStartInfo ��ü ����
        testInfo = new ProcessStartInfo(testExe);

        // ���μ��� ����
        //Process.Start(testInfo); //api����
    }

    public void StartSTT()
    {
        Process.Start(testInfo); //api����
    }
}