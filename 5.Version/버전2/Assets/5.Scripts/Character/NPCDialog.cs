using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogState
{
    [Header("NPC���̵�")]
    public int id;
    [Header("����Ʈ����")]
    public bool quest;
    [Header("����Ʈ���̵�")]
    public int[] questID;
}

public class NPCDialog : MonoBehaviour
{
    [SerializeField]
    NPCDialogState npcDialog;

    //Ư�� Ű�� Ŭ���� ��ȭ�� �ϴ� �ڵ�, ����: ĳ���Ϳ� ���˻���, Ư��Ű Ŭ��

    //������ �鸱 �� ��ȭ�� �ϴ� �ڵ�, ����: ��ȭ����, ��ȭ�� � ������ �Ǵ�(�Ǵ��� ����� NPCDialog�� speechID�� ������ �ش� �������� ��ü)

}
