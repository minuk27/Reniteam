using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemChoiceOwnDialog
{
    [Header("아이템 설명")]
    public string explanation;
    [Header("아이템 얻기 전 대사")]
    public string ownBefore;
    [Header("아이템 얻은 후 대사")]
    public string ownAfter;
    [Header("아이템 얻지 않을때 대사")]
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
