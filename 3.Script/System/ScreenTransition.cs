using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Place //��� ������ �̸�
{
    Room, LivingRoom, Yard, Town, Voice, Prison, WorkPlace, Hospital
}

public enum PlaceTime //���丮�� �ð� �̸�
{
    OneDay, TwoDay, ThreeDay, Final
}

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] CamControl cam;
    [SerializeField] Image blackScreen;
    [SerializeField] GameObject firstScreen;
    [SerializeField] GameObject firstTimeScreen;
    GameObject nowScreen;
    GameObject nowTime;

    private void Awake()
    {
        nowScreen = firstScreen;
        nowTime = firstTimeScreen;
        blackScreen.gameObject.SetActive(false);
    }

    public void setActiveBlackScreen(string screenName)
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.GetComponentInChildren<Text>().text = screenName;
    }

    public void setInActiveBlackScreen()
    {
        blackScreen.gameObject.SetActive(false);
    }

    public void changeScreen(Place place, Vector2 camPos, GameObject nextScreen) //���� �ð����� �����ȯ
    {
        nowScreen.SetActive(false);
        if(place == Place.Voice)
        {
            cam.camMoveVoice(camPos);
        }
        else
        {
            cam.CamMove(camPos);
        }
        StartCoroutine(screenMoveDelay(place, nextScreen));
    }

    public void timeChange(PlaceTime time, GameObject vec, GameObject nextScreen) //�ٸ� �ð����� �̵�
    {
        nowTime.SetActive(false);
        nowScreen.SetActive(false);
        nowScreen = vec;
        cam.CamMove(vec.transform.position);
        StartCoroutine(screenTimeDelay(time, nextScreen));
    }

    IEnumerator screenMoveDelay(Place placeName, GameObject nextScreen) //�����ȯ�� ����� �̸��� �ִ� ���� ȭ�� ������ �� ȭ����ȯ�� �����ִ� �ڵ�
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.GetComponentInChildren<Text>().text = placeName.ToString();
        yield return new WaitForSeconds(1f);
        blackScreen.gameObject.SetActive(false);
        nextScreen.SetActive(true);
        nowScreen = nextScreen;
    }

    IEnumerator screenTimeDelay(PlaceTime placeTimeName, GameObject nextScreen) //�ð������ȯ�� ����� �̸��� �ִ� ���� ȭ�� ������ �� ȭ����ȯ�� �����ִ� �ڵ�
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.GetComponentInChildren<Text>().text = placeTimeName.ToString();
        yield return new WaitForSeconds(1f);
        blackScreen.gameObject.SetActive(false);
        nowScreen.SetActive(true);
        nextScreen.SetActive(true);
        nowTime = nextScreen;
    }
}