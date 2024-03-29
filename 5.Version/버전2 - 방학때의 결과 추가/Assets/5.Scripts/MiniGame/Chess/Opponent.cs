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
        //우선순위 계산
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

    void ProtectKing() //킹보호, 우선순위 1번, 다음 턴에 킹이 먹힐 경우(체크메이트상태에서) 실행하며 그 상황을 회피
    {
        ChessManager.Chess.Select("BlackKing");
        //킹 이동
        //기물 방패
    }

    bool Capture(bool start = false) //상대편 기물 먹기, 우선순위 2번, 우선순위 1번을 위배하지 않을때 한번의 이동으로 기물을 먹을 수 있는 상황, 이때 움직일 기물은 거리상 가장 가까운 것 중 랜덤
    {
        bool state = false;
        if (!start)
        {
            //상대편 기물탐색
            return state;
        }
        //탐색한 기물을 먹을 수 있는 우리 기물 탐색
        //1번을 위배하지 않는 기물을 움직임
        //1번을 모두 위배할 경우 단순 이동 또는 킹보호로 이전(킹보호는 필요 없을 수 있음)
        return state;
    }

    void Move() //이동, 우선순위 3번, 움직일 수 있는 기물 랜덤하게 이동
    {
        //움직일 수 있는 기물 탐색
        //다수 기물 중 랜덤선택
        //선택한 기물 이동
    } 

}
