using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovePosition
{
    [Header("이동할 장면 이름")]
    public Place place;
    [Header("연결된 포탈")]
    public GameObject position;
    [Header("이동할 장면(장면에 최상위 부모오브젝트넣기)")]
    public GameObject nextScreen;
}

public class ScreenPortal : MonoBehaviour
{
    [Header("기본은 첫번째 인덱스")]
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
