using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogState
{
    [Header("NPC아이디")]
    public int id;
    [Header("퀘스트유무")]
    public bool quest;
    [Header("퀘스트아이디")]
    public int[] questID;
}

public class NPCDialog : MonoBehaviour
{
    [SerializeField]
    NPCDialogState npcDialog;

    //특정 키를 클릭시 대화를 하는 코드, 조건: 캐릭터와 접촉상태, 특정키 클릭

    //음성이 들릴 시 대화를 하는 코드, 조건: 대화전달, 대화가 어떤 말인지 판단(판단이 힘들시 NPCDialog의 speechID의 값들을 해당 음성으로 교체)

}
