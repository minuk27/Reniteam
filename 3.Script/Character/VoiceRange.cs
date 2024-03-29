using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRange : MonoBehaviour
{
    private Collider2D voiceRange;
    private List<int> talkPartner;
    private bool notTalk;

    private void Awake()
    {
        voiceRange = new Collider2D();
        talkPartner = new List<int>();

        notTalk = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "npc")
        {
            if (collision.gameObject.GetComponent<NPC>().GetBoolTalk)
            {
                int value = collision.gameObject.GetComponent<NPCDialog>().GetID;
                if (!talkPartner.Contains(value))
                    talkPartner.Add(value);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            if (collision.gameObject.GetComponent<NPC>().GetBoolTalk)
            {
                int value = collision.gameObject.GetComponent<NPCDialog>().GetID;
                if (talkPartner.Contains(value))
                    talkPartner.Remove(value);
            }
        }
    }

    public void CheckVoiceRange()
    {
        if (talkPartner.Count > 0 && notTalk)
        {           
            notTalk = false;
            int value;
            value = talkPartner[0];
            Debug.Log(value + "번 npc와의 대화를 시작합니다.");
            GameManager.Manager.GetUIManager.ChoiceUI(UIs.ChatWindow);
            //UI
            talkPartner.Remove(value);
            talkPartner.Add(value);
        }
    }

    public void SetNotTalk() { if (!notTalk) { notTalk = true; } }
}
