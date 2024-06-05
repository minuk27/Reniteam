using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    private bool isTeleprot;
    private float nowTime;
    private float delay;
    private Place nowPlace;

    // Start is called before the first frame update
    void Start()
    {
        isTeleprot = true;
        delay = 0.1f;
        nowTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTeleprot)
            return;
        if (nowTime < delay)
        {
            nowTime += Time.deltaTime;
        }
        else
            isTeleprot = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal" && isTeleprot)
        {
            Place place = collision.gameObject.GetComponent<ScreenPortal>().getPlaceName;
            Vector2 camPos = collision.gameObject.GetComponent<ScreenPortal>().getCamPos;
            GameObject nextScreen = collision.gameObject.GetComponent<ScreenPortal>().getNextScreen;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                nowTime = 0f;
                isTeleprot = false;
                GameManager.Manager.getScreenTransition.changeScreen(place, camPos, nextScreen);
                nowPlace = place;
            }
            else if(Input.GetKey(KeyCode.D) && nowPlace == Place.Voice)
            {
                nowTime = 0f;
                isTeleprot = false;
                GameManager.Manager.getScreenTransition.changeScreen(place, camPos, nextScreen);
                nowPlace = place;
            }
        }
    }
}
