using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnding : MonoBehaviour
{
    [SerializeField] StoryMove sister;
    bool detect;

    private void Awake()
    {
        detect = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detect)
            return;
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().moveStop();
            detect = true;
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return null;
        GameManager.Manager.getUIManager.getDialogWindow.setText("(집안에서 사람들의 웃는 소리가 들린다)");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("...");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        sister.moveStart(-5f);
        yield return new WaitForSeconds(1f);
        sister.moveStop();
        GameManager.Manager.getUIManager.getDialogWindow.setText("오빠...");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("(동생에 손을 꼭 잡아준다)");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getGameOverUI.gameOverUIStart("1stEnding");
    }
}
