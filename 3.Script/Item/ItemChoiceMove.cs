using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemChoiceMoveDialog
{
    [Header("������ ����")]
    public string explanation;
    [Header("������ ����ϱ���")]
    public string moveBefore;
    [Header("������ ������� ������")]
    public string notMove;
    [Header("���� �ð��� ������Ʈ")]
    public GameObject nextTimeObj;
    [Header("���� �ð��� �̵��� ������Ʈ")]
    public GameObject nextBed;
    [Header("�̵��� �ð��� �̸�")]
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
