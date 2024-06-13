using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemChoiceMoveDialog
{
    [Header("아이템 설명")]
    public string explanation;
    [Header("아이템 사용하기전")]
    public string moveBefore;
    [Header("아이템 사용하지 않을때")]
    public string notMove;
    [Header("다음 시간대 오브젝트")]
    public GameObject nextTimeObj;
    [Header("다음 시간대 이동할 오브젝트")]
    public GameObject nextBed;
    [Header("이동할 시간대 이름")]
    public PlaceTime place;
}

public class ItemChoiceMove : MonoBehaviour
{
    [SerializeField] ItemChoiceMoveDialog dialog;

    int step;
    int nowStep;

    private void Awake()
    {
        step = 0;
        nowStep = 0;
    }

    public string getSpeech
    {
        get
        {
            string returnString = "";
            switch (step)
            {
                case 0:
                    nowStep = 0;
                    returnString = dialog.explanation;
                    step = 1;
                    break;
                case 1:
                    nowStep = 1;
                    returnString = dialog.moveBefore;
                    step = 2;
                    break;
                case 2:
                    nowStep = 2;
                    returnString = dialog.notMove;
                    step = 0;
                    break;
            }
            return returnString;
        }
    }

    public int getNowStep { get { return nowStep; } }
    public void acceptChoice() 
    {;
        GameManager.Manager.getScreenTransition.timeChange(dialog.place, dialog.nextBed, dialog.nextTimeObj);
    }
    public void failureChoice() { step = 2; }
}
