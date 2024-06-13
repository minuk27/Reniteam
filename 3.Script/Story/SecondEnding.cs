using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnding : MonoBehaviour
{
    [SerializeField] CamControl cam;
    [SerializeField] List<StoryMove> plaerPos;
    [SerializeField] List<GameObject> screens;
    [SerializeField] float speed = 5f;
    [SerializeField] float moveDistance = 0.1f;
    [SerializeField] GameObject mother;
    [SerializeField] GameObject father;
    [SerializeField] GameObject sister;

    Vector3 startPosition;

    private void OnEnable()
    {
        for(int i = 1; i<screens.Count; i++)
        {
            screens[i].SetActive(false);
        }
        StartCoroutine(storyStart());
    }

    IEnumerator storyStart()
    {
        plaerPos[0].gameObject.GetComponent<Animator>().SetTrigger("run");
        yield return null;
        plaerPos[0].moveStart(-25f);
        yield return new WaitForSeconds(2.5f);
        GameManager.Manager.getScreenTransition.setActiveBlackScreen("Yard");
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getScreenTransition.setInActiveBlackScreen();

        screens[0].SetActive(false);
        screens[1].SetActive(true);
        cam.CamMove(screens[1].transform.position);
        plaerPos[1].gameObject.GetComponent<Animator>().SetTrigger("run");
        yield return null;
        plaerPos[1].moveStart(-14f);
        yield return new WaitForSeconds(1.5f);
        GameManager.Manager.getScreenTransition.setActiveBlackScreen("LivingRoom");
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getScreenTransition.setInActiveBlackScreen();

        screens[1].SetActive(false);
        screens[2].SetActive(true);
        cam.CamMove(screens[2].transform.position);
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("(엄마...아빠...동생아....)");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        startPosition = mother.transform.position;
        while (true)
        {
            mother.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (mother.transform.position.y >= startPosition.y + moveDistance)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            mother.transform.position += Vector3.down * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (mother.transform.position.y <= startPosition.y)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("ㅁㅁ아 어서와 밥안먹었지? 엄마가 챙겨줄게");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        startPosition = father.transform.position;
        while (true)
        {
            father.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (father.transform.position.y >= startPosition.y + moveDistance)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            father.transform.position += Vector3.down * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (father.transform.position.y <= startPosition.y)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("늦게까지 고생했구나 어서 들어와라");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        startPosition = sister.transform.position;
        while (true)
        {
            sister.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (sister.transform.position.y >= startPosition.y + moveDistance)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            sister.transform.position += Vector3.down * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (sister.transform.position.y <= startPosition.y)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.01f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("오빠, 오빠, 어서 나랑 놀아줘");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        yield return new WaitForSeconds(1f);
        screens[2].GetComponent<ScreenIllusion>().illusionCancellation();
        yield return new WaitForSeconds(2.5f);
        plaerPos[2].gameObject.GetComponent<SpriteRenderer>().flipX = true;
        yield return new WaitForSeconds(0.2f);
        GameManager.Manager.getScreenTransition.setActiveBlackScreen("Yard");
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getScreenTransition.setInActiveBlackScreen();

        screens[2].SetActive(false);
        screens[3].SetActive(true);
        cam.CamMove(screens[3].transform.position);
        plaerPos[3].gameObject.GetComponent<Animator>().SetTrigger("run");
        yield return null;
        plaerPos[3].moveStart(15f);
        yield return new WaitForSeconds(1.5f);
        GameManager.Manager.getScreenTransition.setActiveBlackScreen("Town");
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getScreenTransition.setInActiveBlackScreen();

        screens[3].SetActive(false);
        screens[4].SetActive(true);
        cam.CamMove(screens[4].transform.position);
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("나 혼자구나...");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getGameOverUI.gameOverUIStart("2ndEnding");
    }
}
