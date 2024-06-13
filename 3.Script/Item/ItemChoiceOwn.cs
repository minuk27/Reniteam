using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemChoiceOwnDialog
{
    [Header("������ ����")]
    public string explanation;
    [Header("������ ��� �� ���")]
    public string ownBefore;
    [Header("������ ���� �� ���")]
    public string ownAfter;
    [Header("������ ���� ������ ���")]
    public string notOwn;
}
public class ItemChoiceOwn : MonoBehaviour
{
    [SerializeField] ItemChoiceOwnDialog dialog;
    int step;
    int nowStep;

    private void Awake()
    {
        step = 0;
        nowStep = 0;
    }

    public string getSpeech { 
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
                    returnString = dialog.ownBefore;
                    break;
                case 2:
                    nowStep = 2;
                    returnString = dialog.ownAfter;
                    break;
                case 3:
                    nowStep = 3;
                    returnString = dialog.notOwn;
                    step = 0;
                    break;
            }
            return returnString;
        } 
    }
    public int getNowStep { get { return nowStep; } }
    public void acceptChoice() { step = 2; }
    public void failureChoice() { step = 3; }
}
