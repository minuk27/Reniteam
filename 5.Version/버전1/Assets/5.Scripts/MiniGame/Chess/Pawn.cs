using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour, SelectPieces
{
    [SerializeField]
    private int posIndex;
    private bool first;
    void Start()
    {
        ChessManager.Chess.AddPiesec(gameObject.name, this, posIndex, "White");
        first = true;
    }

    void Update()
    {
        
    }

    public void Move(Vector2 vec, int index)
    {
        if(first)
            first = false;
        posIndex = index;
        transform.position = vec;
        Check(index);
    }

    public void Select()
    {
        Vector3 vec = transform.position;
        for (int i = 0; i<64; i++)
        {
            if(ChessManager.Chess.map[i].posX == transform.position.x && ChessManager.Chess.map[i].posY-1.0f == transform.position.y && (ChessManager.Chess.map[i].name == "None"|| ChessManager.Chess.map[i].camp == "Black"))
            {
                vec = transform.position;
                if (first)
                {
                    vec.y += 2;
                }
                else
                    vec.y += 1;
                ChessManager.Chess.ShowPos(vec);
                break;
            }
        }
        if (posIndex % 8 != 0)
        {
            if (posIndex > 8)
            {
                if (ChessManager.Chess.map[posIndex - 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 9].posX; vec.y = ChessManager.Chess.map[posIndex - 9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
        }
        if (posIndex + 1 % 8 != 0)
        {
            if (posIndex > 7)
            {
                if (ChessManager.Chess.map[posIndex - 7].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 7].posX; vec.y = ChessManager.Chess.map[posIndex - 7].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
        }
    }

    public void Check(int index)
    {
        if (posIndex > 7)
        {
            if (ChessManager.Chess.map[posIndex - 8].name == "BlackKing")
            {
                Vector2 vec;
                vec.x = ChessManager.Chess.map[posIndex - 8].posX; vec.y = ChessManager.Chess.map[posIndex - 8].posY;
                ChessManager.Chess.Check = true;
                ChessManager.Chess.CheckVec = vec;
                Debug.Log(vec);
                return;
            }
        }
        if (posIndex % 8 != 0)
        {
            if (posIndex > 8)
            {
                if (ChessManager.Chess.map[posIndex - 9].name == "BlackKing")
                {
                    Vector2 vec;
                    vec.x = ChessManager.Chess.map[posIndex - 9].posX; vec.y = ChessManager.Chess.map[posIndex - 9].posY;
                    ChessManager.Chess.Check = true;
                    ChessManager.Chess.CheckVec = vec;
                    Debug.Log(vec);
                    return;
                }
            }
        }
        if (posIndex + 1 % 8 != 0)
        {
            if (posIndex > 7)
            {
                if (ChessManager.Chess.map[posIndex - 7].name == "BlackKing")
                {
                    Vector2 vec;
                    vec.x = ChessManager.Chess.map[posIndex - 7].posX; vec.y = ChessManager.Chess.map[posIndex - 7].posY;
                    ChessManager.Chess.Check = true;
                    ChessManager.Chess.CheckVec = vec;
                    Debug.Log(vec);
                    return;
                }
            }
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
