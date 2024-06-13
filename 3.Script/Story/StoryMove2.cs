using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StoryMove2 : MonoBehaviour
{
    [SerializeField] GameObject nextScreen;
    [SerializeField] Light2D light2D;
    [SerializeField] Animator playerAnim;

    private void OnEnable()
    {
        StartCoroutine(timeDelay());
    }


    IEnumerator timeDelay()
    {
        while (true)
        {
            light2D.intensity -= 0.001f;
            yield return null;
            if (light2D.intensity <= 0.1f)
                break;
        }
        yield return new WaitForSeconds(0.5f);
        GameManager.Manager.getUIManager.getDialogWindow.setText("수감자들은 일을 마치고 복귀하시오");
        playerAnim.enabled = false;
        while (true)
        {
            yield return null;
            if (GameManager.Manager.getUIManager.getDialogWindow.isEndTalk)
                break;
        }
        yield return new WaitForSeconds(1f);
        GameManager.Manager.getUIManager.getDialogWindow.ActiveFalse();
        yield return new WaitForSeconds(0.5f);
        GameManager.Manager.getScreenTransition.changeScreen(Place.Prison, nextScreen.transform.position, nextScreen);
    }
}
