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
        GameManager.Manager.getUIManager.getDialogWindow.setText("��ο��� ���� �۾����� Ż���ϼ���");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("������ ������ ������ �������� ���߾�߸� �����Դϴ�.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("�������� ON/OFF�� �����մϴ�.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);

        GameManager.Manager.getUIManager.getDialogWindow.setText("������ ������ �������� �Һ��� ���߾� ���� �Ǹ� �̸��� ������ ����ġ�� �˴ϴ�.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("��ο��� ������ ����ģ ������ ã��� ����ϴ�.");
        while (true)
        {
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(0.7f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("������ ������ ��ȣ�ϸ� ������ Ż���ϼ���.");
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
