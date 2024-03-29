using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour, SelectPieces
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
        int index = posIndex;
        while (index-9 >= 0)
        {
            if (index % 8 == 0 || ChessManager.Chess.map[index-9].name != "None")
            {
                if(index % 8 != 0 && ChessManager.Chess.map[index - 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[index-9].posX; vec.y = ChessManager.Chess.map[index-9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                break;
            }
            index -= 9;
            vec.x = ChessManager.Chess.map[index].posX; vec.y = ChessManager.Chess.map[index].posY;
            ChessManager.Chess.ShowPos(vec);
        }
        index = posIndex;
        while (index-7 >= 1)
        {
            if ((index+1) % 8 == 0 || ChessManager.Chess.map[index - 7].name != "None")
            {
                if ((index + 1) % 8 != 0 && ChessManager.Chess.map[index - 7].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[index - 7].posX; vec.y = ChessManager.Chess.map[index - 7].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                break;
            }
            index -= 7;
            vec.x = ChessManager.Chess.map[index].posX; vec.y = ChessManager.Chess.map[index].posY;
            ChessManager.Chess.ShowPos(vec);
        }
        index = posIndex;
        while (index+7 <= 62)
        {
            if (index % 8 == 0 || ChessManager.Chess.map[index + 7].name != "None")
            {
                if (index % 8 != 0 && ChessManager.Chess.map[index + 7].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[index + 7].posX; vec.y = ChessManager.Chess.map[index + 7].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                break;
            }
            index += 7;
            vec.x = ChessManager.Chess.map[index].posX; vec.y = ChessManager.Chess.map[index].posY;
            ChessManager.Chess.ShowPos(vec);
        }
        index = posIndex;
        while (index+9 <= 63)
        {
            if ((index + 1) % 8 == 0 || ChessManager.Chess.map[index + 9].name != "None")
            {
                if ((index + 1) % 8 != 0 && ChessManager.Chess.map[index + 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[index + 9].posX; vec.y = ChessManager.Chess.map[index + 9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                break;
            }
            index += 9;
            vec.x = ChessManager.Chess.map[index].posX; vec.y = ChessManager.Chess.map[index].posY;
            ChessManager.Chess.ShowPos(vec);
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
