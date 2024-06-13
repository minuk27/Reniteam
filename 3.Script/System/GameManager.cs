using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            if (manager == null)
            {
                return null;
            }
            return manager;
        }
    }
    STTManager sttManager; //stt�Ŵ���, stt���� ��ȭ���� ��� �� ����
    [SerializeField] UIManager uiManager; //ui�Ŵ���, ��� ui ����
    [SerializeField] ScreenTransition screenTransition; //ȭ����ȯ ��� ����

    private void Awake()
    {
        if (manager)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        manager = this;
        DontDestroyOnLoad(this.gameObject);

        ManagerInstance(); InitializeManagers();
    }

    private void ManagerInstance() // ���� �߰��� �ʿ���� ��� ���� �ν��Ͻ� ����
    {
        sttManager = new STTManager();
    }

    private void InitializeManagers() //�� �Ŵ��� �ʱ�ȭ �۾�(�ʿ��� �͸�)
    {
        sttManager.Initialize();
        uiManager.Initialize();
    }

    public STTManager GetSttManager { get { return sttManager; } } // �Ŵ��� ȣ��
    public UIManager getUIManager { get { return uiManager; } } // �Ŵ��� ȣ��
    public ScreenTransition getScreenTransition { get { return screenTransition; } } // �Ŵ��� ȣ��
}