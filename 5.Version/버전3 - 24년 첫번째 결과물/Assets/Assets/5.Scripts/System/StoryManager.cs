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
        for (int i = 0; i<10; i++) //���丮 �߰��� �� �� �ֱ�
        {
            storySteps.Add(i);
            //0������ 0: ���ѷα�, 1: ����, 2: ����...
        }
        nowStep = 0; //�������� ������ ���� ����� �κп��� �����ϰ� �ϱ�, nowStep������ �ʱ�ȭ���ִ� ���ο� �޼ҵ带 �߰��Ͽ� ���ν����̳� �̾���� ��ư�� �������� �� ��������ֱ�
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
