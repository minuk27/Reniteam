using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour, SelectPieces
{
    [SerializeField]
    private int posIndex;
    void Start()
    {
        ChessManager.Chess.AddPiesec(gameObject.name, this, posIndex, "White");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 vec, int index)
    {
        posIndex = index;
        transform.position = vec;
    }
    public void Select()
    {
        Vector2 vec = transform.position;

        if (posIndex - 8 >= 0)
        {
            if (ChessManager.Chess.map[posIndex - 8].name == "None" || ChessManager.Chess.map[posIndex - 8].camp == "Black")
            {
                vec.y = ChessManager.Chess.map[posIndex - 8].posY;
                ChessManager.Chess.ShowPos(vec);
            }
        }
        if(posIndex + 8 <= 63)
        {
            if (ChessManager.Chess.map[posIndex + 8].name == "None" || ChessManager.Chess.map[posIndex + 8].camp == "Black")
            {
                vec.y = ChessManager.Chess.map[posIndex + 8].posY;
                ChessManager.Chess.ShowPos(vec);
            }
        }
        if(posIndex % 8 != 0)
        {
            if(ChessManager.Chess.map[posIndex - 1].name == "None" || ChessManager.Chess.map[posIndex - 1].camp == "Black")
            {
                vec.x = ChessManager.Chess.map[posIndex - 1].posX; vec.y = transform.position.y;
                ChessManager.Chess.ShowPos(vec);
            }
            if (posIndex <= 56)
            {
                if (ChessManager.Chess.map[posIndex + 7].name == "None" || ChessManager.Chess.map[posIndex + 7].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 7].posX; vec.y = ChessManager.Chess.map[posIndex + 7].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
            if (posIndex > 8)
            {
                if (ChessManager.Chess.map[posIndex - 9].name == "None" || ChessManager.Chess.map[posIndex - 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 9].posX; vec.y = ChessManager.Chess.map[posIndex - 9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
        }
        if (posIndex + 1 % 8 != 0)
        {
            if (posIndex <= 62)
            {
                if (ChessManager.Chess.map[posIndex + 1].name == "None" || ChessManager.Chess.map[posIndex + 1].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 1].posX; vec.y = transform.position.y;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
            if (posIndex > 6)
            {
                if (ChessManager.Chess.map[posIndex - 7].name == "None" || ChessManager.Chess.map[posIndex - 7].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex - 7].posX; vec.y = ChessManager.Chess.map[posIndex - 7].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
            if (posIndex <= 54)
            {
                if (ChessManager.Chess.map[posIndex + 9].name == "None" || ChessManager.Chess.map[posIndex + 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[posIndex + 9].posX; vec.y = ChessManager.Chess.map[posIndex + 9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
            }
        }
    }
    public void Check(int index)
    {

    }
    public void Delete()
    {
        Destroy(this);
    }
}
