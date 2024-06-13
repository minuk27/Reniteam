using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StoryMove3 : MonoBehaviour
{
    [SerializeField] Light2D light2D;
    [SerializeField] StoryMove playerMove;
    [SerializeField] GameObject nextTime;
    [SerializeField] GameObject nextScreen;
    bool isMove;

    private void Awake()
    {
        light2D.gameObject.SetActive(false);
        playerMove.enabled = false;
        isMove = false;
    }

    private void OnEnable()
    {
        light2D.gameObject.SetActive(false);
        playerMove.enabled = false;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().moveStop();
            isMove = true;
            StartCoroutine(lightDelay());
            StartCoroutine(storyDelay());
        }
    }

    IEnumerator lightDelay()
    {
        light2D.gameObject.SetActive(true);
        while (true)
        {
            light2D.intensity = light2D.intensity == 5f ? 3f : 5f;
            yield return new WaitForSeconds(0.5f);
            if (!isMove)
                break;
        }
    }

    IEnumerator storyDelay()
    {
        GameManager.Manager.getUIManager.getDialogWindow.changeText(FontStyle.BoldAndItalic);
        for (int i = 0; i < 2; i++)
        {
            GameManager.Manager.getUIManager.getDialogWindow.setText("탈옥자가 발생했습니다.");
            while (true)
            {
                if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                    break;
                yield return null;
            }
            yield return new WaitForSeconds(0.7f);
            GameManager.Manager.getUIManager.getDialogWindow.setText("감옥 전체의 전원을 차단합니다.");
            while (true)
            {
                if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                    break;
                yield return null;
            }
            yield return new WaitForSeconds(0.7f);
            GameManager.Manager.getUIManager.getDialogWindow.setText("교도관들은 플래시를 사용하여 탈옥자를 찾으십시오.");
            while (true)
            {
                if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                    break;
                yield return null;
            }
            yield return new WaitForSeconds(0.7f);
        }
        yield return null;
        GameManager.Manager.getUIManager.getDialogWindow.changeText(FontStyle.Bold);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        playerMove.enabled = true;
        yield return null;
        playerMove.gameObject.GetComponent<Animator>().SetBool("run", true);
        playerMove.moveStart(-20f);
        yield return new WaitForSeconds(2f);
        isMove = true;
        GameManager.Manager.getScreenTransition.timeChange(PlaceTime.Final, nextScreen, nextTime);
    }
}
