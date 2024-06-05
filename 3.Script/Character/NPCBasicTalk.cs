using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NPCBasicDialog
{
    [Header("대사")]
    public List<string> speech;
    [Header("스토리 영향")]
    public bool storyEffect;
}
public class NPCBasicTalk : MonoBehaviour
{
    [SerializeField] NPCBasicDialog dialog;
    [SerializeField] StoryCondition storyCondition;
    NPCTalk npcTalk;
    int speechIndex;
    int endSpeechIndex;

    private void Awake()
    {
        npcTalk = GetComponent<NPCTalk>();
        speechIndex = -1;
        endSpeechIndex = dialog.speech.Count - 1;
    }

    public string getSpeech
    {
        get 
        {
            if(speechIndex < endSpeechIndex)
            {
                speechIndex += 1;
            }
            if (dialog.storyEffect && speechIndex == endSpeechIndex)
                storyCondition.conditionType(ConditionType.NPCTalk, this.gameObject);
            return dialog.speech[speechIndex]; 
        } 
    }
}