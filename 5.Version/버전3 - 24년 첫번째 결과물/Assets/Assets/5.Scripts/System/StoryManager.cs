using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private List<int> storySteps;
    private int nowStep;

    public void Initialize()
    {
        storySteps = new List<int>();
        for (int i = 0; i<10; i++) //스토리 추가될 시 더 넣기
        {
            storySteps.Add(i);
            //0번부터 0: 프롤로그, 1: 다음, 2: 다음...
        }
        nowStep = 0; //저장기능을 구현시 수정 저장된 부분에서 시작하게 하기, nowStep변수를 초기화해주는 새로운 메소드를 추가하여 새로시작이나 이어시작 버튼을 선택했을 시 실행시켜주기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CurrentStep()
    {
        return nowStep;
    }

    public void StepUp()
    {
        storySteps.RemoveAt(0);
        nowStep = storySteps[0];
    }
}
