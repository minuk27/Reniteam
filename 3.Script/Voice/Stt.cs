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

        // ������ �ܺ� ���α׷��� ��ο� �ɼ��� ������ ���ڿ�
        string arguments = ""; // �ʿ��� ��쿡�� ���

        // ���μ��� ���� ���� ����
        ProcessStartInfo psi = new ProcessStartInfo(filePath);
        psi.Arguments = arguments;
        Process.Start(psi);
        StartCoroutine(conversionTime());
    }

    IEnumerator conversionTime()
    {
        yield return new WaitForSeconds(5f); //������ stt�� ������ ���� ���� ������ ������ ���� �׽�Ʈ�� ������ �ȵɰ�� �̰��� ����
        GameManager.Manager.GetUIManager.getVoiceWindow().voiceText();
    }
}
