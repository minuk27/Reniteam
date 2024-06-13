using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Place //모든 장면들의 이름
{
    Room, LivingRoom, Yard, Town, Voice, Prison, WorkPlace, Hospital
}

public enum PlaceTime //스토리별 시간 이름
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

    public void changeScreen(Place place, Vector2 camPos, GameObject nextScreen) //같은 시간대의 장면전환
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

    public void timeChange(PlaceTime time, GameObject vec, GameObject nextScreen) //다른 시간으로 이동
    {
        nowTime.SetActive(false);
        nowScreen.SetActive(false);
        nowScreen = vec;
        cam.CamMove(vec.transform.position);
        StartCoroutine(screenTimeDelay(time, nextScreen));
    }

    IEnumerator screenMoveDelay(Place placeName, GameObject nextScreen) //장면전환전 장면의 이름이 있는 검은 화면 보여준 뒤 화면전환을 보여주는 코드
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.GetComponentInChildren<Text>().text = placeName.ToString();
        yield return new WaitForSeconds(1f);
        blackScreen.gameObject.SetActive(false);
        nextScreen.SetActive(true);
        nowScreen = nextScreen;
    }

    IEnumerator screenTimeDelay(PlaceTime placeTimeName, GameObject nextScreen) //시간장면전환전 장면의 이름이 있는 검은 화면 보여준 뒤 화면전환을 보여주는 코드
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