using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogDB
{
    [Header("NPC아이디")]
    public int id;
    [Header("대사")]
    public string[] speechDB;
    [Header("현재 대사인덱스(코드내에서 수정됨으로 0으로 고정)")]
    public int currentSpeechIndex;
    [Header("첫번째대사인덱스값(코드내에서 수정됨으로 0으로 고정")]
    public int speechFirstIndex;
    [Header("대사변경(현스토리에서 말할수 있는 마지막 인덱스값)")]
    public List<int> speechIndex;
    [Header("스토리분기(스토리매니저에 지정된 스토리값과 같아야 대사실행)")]
    public List<int> storyIndex;
    [Header("npc 사진")]
    public Sprite npcSprite;
    [Header("퀘스트유무")]
    public bool isQuest;
}

public class NPCDialogDB : MonoBehaviour
{
    [SerializeField]
    public List<DialogDB> npcDialogDB;

    public void Setting()
    {
        foreach(DialogDB i in npcDialogDB)
        {
            i.currentSpeechIndex = 0;
            i.speechFirstIndex = 0;
        }
    }
}