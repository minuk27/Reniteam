using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenIllusion : MonoBehaviour
{
    [SerializeField] Light2D Lamp;
    [SerializeField] List<SpriteRenderer> npcs;
    
    public void illusionCancellation()
    {
        StartCoroutine(cancellationLight());
        StartCoroutine(cancellationNPC());
    }

    IEnumerator cancellationLight()
    {
        while (true)
        {
            if (Lamp.intensity <= 0.2f)
                break;
            Lamp.intensity -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator cancellationNPC()
    {
        Color npcColor = npcs[0].color;
        Color npcNameColor = npcs[0].gameObject.GetComponentInChildren<TextMesh>().color;

        while (true)
        {
            if (npcColor.a <= 0f && npcNameColor.a <= 0f)
                break;
            npcColor.a -= 0.01f;
            npcNameColor.a -= 0.01f;
            npcs[0].color = npcColor;
            npcs[1].color = npcColor;
            npcs[2].color = npcColor;
            npcs[0].gameObject.GetComponentInChildren<TextMesh>().color = npcNameColor;
            npcs[1].gameObject.GetComponentInChildren<TextMesh>().color = npcNameColor;
            npcs[2].gameObject.GetComponentInChildren<TextMesh>().color = npcNameColor;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
