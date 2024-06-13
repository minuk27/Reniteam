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
    STTManager sttManager; //stt매니저, stt관련 대화파일 사용 및 관리
    [SerializeField] UIManager uiManager; //ui매니저, 모든 ui 통제
    [SerializeField] ScreenTransition screenTransition; //화면전환 기능 제공

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

    private void ManagerInstance() // 동적 추가할 필요없을 경우 개로 인스턴스 생성
    {
        sttManager = new STTManager();
    }

    private void InitializeManagers() //각 매니저 초기화 작업(필요한 것만)
    {
        sttManager.Initialize();
        uiManager.Initialize();
    }

    public STTManager GetSttManager { get { return sttManager; } } // 매니저 호출
    public UIManager getUIManager { get { return uiManager; } } // 매니저 호출
    public ScreenTransition getScreenTransition { get { return screenTransition; } } // 매니저 호출
}