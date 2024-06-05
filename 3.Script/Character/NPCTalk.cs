using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TalkType
{
    Basic, Quest, Nothing
}

public class NPCTalk : MonoBehaviour
{
    NPCBasicTalk npcBasicTalk;
    NPCQuestTalk npcQuestTalk;
    [SerializeField] TalkType talkType;
    [SerializeField] int npcID;

    private void Awake()
    {
        switch (talkType)
        {
            case TalkType.Basic:
                npcBasicTalk = GetComponent<NPCBasicTalk>();
                npcQuestTalk = null;
                break;
            case TalkType.Quest:
                npcQuestTalk = GetComponent<NPCQuestTalk>();
                npcBasicTalk = null;
                break;
            case TalkType.Nothing:
                npcBasicTalk = null;
                npcQuestTalk = null;
                break;
        }
    }

    public TalkType getType { get { return talkType; } }
    public NPCBasicTalk getBasicTalk { get { return npcBasicTalk; } }
    public NPCQuestTalk getQuestTalk { get { return npcQuestTalk; } }
    public int getID { get { return npcID; } }
}
