using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKing : MonoBehaviour, SelectPieces
{
    [SerializeField]
    private int posIndex;
    // Start is called before the first frame update
    void Start()
    {
        ChessManager.Chess.AddPiesec(gameObject.name, this, posIndex, "Black");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector2 vec, int index) //이동
    {
        posIndex = index;
        transform.position = vec;
    }

    public void Check(int index)
    {
        
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void Select() //이동 가능한 좌표 넘기기
    {
        Debug.Log("실행");
        List<Vector2> checkVec;
        List<Vector2> vecList = new List<Vector2>();
        Vector2 vec;
        checkVec = ChessManager.Chess.ReturnCheckVec();

        if (posIndex - 8 >= 0)
        {
            if (ChessManager.Chess.map[posIndex - 8].name == "None" || ChessManager.Chess.map[posIndex - 8].camp == "White")
            {
                vec.x = ChessManager.Chess.map[posIndex - 8].posX; vec.y = ChessManager.Chess.map[posIndex - 8].posY;
                vecList.Add(vec);
            }
        }
        if (posIndex + 8 <= 63)
        {
            if (ChessManager.Chess.map[posIndex + 8].name == "None" || ChessManager.Chess.map[posIndex + 8].camp == "White")
            {
                vec.x = ChessManager.Chess.map[posIndex + 8].posX; vec.y = ChessManager.Chess.map[posIndex + 8].posY;
                vecList.Add(vec);
            }
        }
        if (posIndex % 8 != 0)
        {
            if (ChessManager.Chess.map[posIndex - 1].name == "None" || ChessManager.Chess.map[posIndex - 1].camp == "White")
            {
                vec.x = ChessManager.Chess.map[posIndex - 1].posX; vec.y = ChessManager.Chess.map[posIndex - 1].posY;
                vecList.Add(vec);
            }
            if (posIndex <= 56)
            {
                if (ChessManager.Chess.map[posIndex + 7].name == "None" || ChessManager.Chess.map[posIndex + 7].camp == "White")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 7].posX; vec.y = ChessManager.Chess.map[posIndex + 7].posY;
                    vecList.Add(vec);
                }
            }
            if (posIndex > 8)
            {
                if (ChessManager.Chess.map[posIndex - 9].name == "None" || ChessManager.Chess.map[posIndex - 9].camp == "White")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 9].posX; vec.y = ChessManager.Chess.map[posIndex - 9].posY;
                    vecList.Add(vec);
                }
            }
        }
        if (posIndex + 1 % 8 != 0)
        {
            if (posIndex <= 62)
            {
                if (ChessManager.Chess.map[posIndex + 1].name == "None" || ChessManager.Chess.map[posIndex + 1].camp == "White")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 1].posX; vec.y = ChessManager.Chess.map[posIndex + 1].posY;
                    vecList.Add(vec);
                }
            }
            if (posIndex > 6)
            {
                if (ChessManager.Chess.map[posIndex - 7].name == "None" || ChessManager.Chess.map[posIndex - 7].camp == "White")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 7].posX; vec.y = ChessManager.Chess.map[posIndex - 7].posY;
                    vecList.Add(vec);
                }
            }
            if (posIndex <= 54)
            {
                if (ChessManager.Chess.map[posIndex + 9].name == "None" || ChessManager.Chess.map[posIndex + 9].camp == "White")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 9].posX; vec.y = ChessManager.Chess.map[posIndex + 9].posY;
                    vecList.Add(vec);
                }
            }
        }

        List<Vector2> result = new List<Vector2>();

        foreach (Vector2 value in vecList)
        {
            if (!checkVec.Contains(value))
            {
                result.Add(value);
            }
        }

        if (result.Count > 0)
        {
            int randomIndex = Random.Range(0, result.Count);
            Vector2 randomValue = result[randomIndex];
            Debug.Log(randomValue);
            ChessManager.Chess.Move(gameObject.transform.position, randomValue, "BlackKing");
        }
        else
        {
            //게임종류 체크나이트상태
        }
    }
}
