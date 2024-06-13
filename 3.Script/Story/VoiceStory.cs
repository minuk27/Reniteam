using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceStory : MonoBehaviour
{
    [Header("심문전대사")]
    [SerializeField] List<string> speech;
    [SerializeField] PlayerMove player;
    [SerializeField] StoryMove Soldier;
    [SerializeField] GameObject nowScreen;
    [SerializeField] GameObject nextScreenPos;
    [SerializeField] GameObject nextScreen;
    int speechStartIndex;
    int speechEndIndex;

    private void Awake()
    {
        speechStartIndex = 0;
        speechEndIndex = speech.Count - 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.moveStop();
            Soldier.moveStart(13f);
            StartCoroutine(moveDelay());
        }
    }

    IEnumerator moveDelay()
    {
        while (true)
        {
            if (!Soldier.getIsMove)
                break;
            yield return null;
        }
        yield return null;
        foreach (string s in speech)
        {
            GameManager.Manager.getUIManager.getDialogWindow.setText(s);
            while (true)
            {
                if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                    break;
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        }
        yield return null;
        GameManager.Manager.getScreenTransition.changeScreen(Place.Voice, nextScreen.transform.position, nextScreen);
    }
}
