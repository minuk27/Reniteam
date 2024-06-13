using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStory : MonoBehaviour
{
    [SerializeField] ScreenPortal portal;
    [SerializeField] PlayerMove player;

    private void OnEnable()
    {
        StartCoroutine(explanation());
    }

    IEnumerator explanation()
    {
        while (true)
        {
            if (player.playerReady())
                break;
            yield return null;
        }
        player.moveStop();
        GameManager.Manager.getUIManager.getDialogWindow.changeText(FontStyle.BoldAndItalic);
        yield return null;
        GameManager.Manager.getUIManager.getDialogWindow.setText("어두워진 감옥 작업장을 탈출하세요");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("ㅁㅁ의 동생은 ㅁㅁ에 손전등을 비추어야만 움직입니다.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("손전등을 ON/OFF가 가능합니다.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("ㅁㅁ의 동생이 교도관에 불빛에 비추어 지게 되면 겁먹은 동생은 도망치게 됩니다.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("어두워진 곳에서 도망친 동생을 찾기란 힘듭니다.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("무사히 동생을 보호하며 감옥을 탈출하세요.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.changeText(FontStyle.Bold);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        player.moveStart();
    }

    void changePortalPos()
    {
        portal.changeStory(1);
    }

    public void setGameOver()
    {
        changePortalPos();
    }
}
