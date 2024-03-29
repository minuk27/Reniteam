using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�켱���� ���
        if (ChessManager.Chess.Turn != 2)
            return;
        switch (Search())
        {
            case 1:
                ProtectKing();
                break;
            case 2:
                Capture(true);
                break;
            case 3:
                Move();
                break;
        }
        ChessManager.Chess.Turn = 1;
    }
    
    int Search()
    {
        int priority = 0;
        if (ChessManager.Chess.Check)
        {
            priority = 1;
        }
        else if (Capture())
        {
            priority = 2;
        }
        else
        {
            priority = 3;
        }
        return priority;
    }

    void ProtectKing() //ŷ��ȣ, �켱���� 1��, ���� �Ͽ� ŷ�� ���� ���(üũ����Ʈ���¿���) �����ϸ� �� ��Ȳ�� ȸ��
    {
        ChessManager.Chess.Select("BlackKing");
        //ŷ �̵�
        //�⹰ ����
    }

    bool Capture(bool start = false) //����� �⹰ �Ա�, �켱���� 2��, �켱���� 1���� �������� ������ �ѹ��� �̵����� �⹰�� ���� �� �ִ� ��Ȳ, �̶� ������ �⹰�� �Ÿ��� ���� ����� �� �� ����
    {
        bool state = false;
        if (!start)
        {
            //����� �⹰Ž��
            return state;
        }
        //Ž���� �⹰�� ���� �� �ִ� �츮 �⹰ Ž��
        //1���� �������� �ʴ� �⹰�� ������
        //1���� ��� ������ ��� �ܼ� �̵� �Ǵ� ŷ��ȣ�� ����(ŷ��ȣ�� �ʿ� ���� �� ����)
        return state;
    }

    void Move() //�̵�, �켱���� 3��, ������ �� �ִ� �⹰ �����ϰ� �̵�
    {
        //������ �� �ִ� �⹰ Ž��
        //�ټ� �⹰ �� ��������
        //������ �⹰ �̵�
    } 

}
