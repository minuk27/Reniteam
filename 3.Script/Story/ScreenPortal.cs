using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovePosition
{
    [Header("�̵��� ��� �̸�")]
    public Place place;
    [Header("����� ��Ż")]
    public GameObject position;
    [Header("�̵��� ���(��鿡 �ֻ��� �θ������Ʈ�ֱ�)")]
    public GameObject nextScreen;
}

public class ScreenPortal : MonoBehaviour
{
    [Header("�⺻�� ù��° �ε���")]
    public List<MovePosition> movePosition;
    int nowIndex;

    private void Awake()
    {
        nowIndex = 0;
    }

    public void changeStory(int stroyIndex)
    {
        if(movePosition.Count > 1)
            nowIndex = stroyIndex;
    }

    public Place getPlaceName { get { return movePosition[nowIndex].place; } }
    public Vector2 getCamPos { get { return movePosition[nowIndex].nextScreen.transform.position; } }
    public GameObject getNextScreen 
    { 
        get 
        {
            if (movePosition[nowIndex].nextScreen == null)
                return null;
            return movePosition[nowIndex].nextScreen; 
        } 
    }
}
