using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, SelectPieces
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
        float posX = transform.position.x;
        float posY = transform.position.y;
        int maxX, minX, maxY, minY;
        int index = posIndex;
        minX = posIndex - posIndex % 8;
        maxX = minX + 7;
        minY = posIndex % 8;
        maxY = minY + 56;

        if (index != maxX)
        {
            index++;
            bool end = false;
            while (index <= maxX)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.x = ChessManager.Chess.map[index].posX; vec.y = posY;
                    ChessManager.Chess.ShowPos(vec);
                    index++;
                }
                else if(!end && ChessManager.Chess.map[index].camp == "Black")
                {
                    end = true;
                    vec.x = ChessManager.Chess.map[index].posX; vec.y = posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                else
                    break;
            }
        }
        index = posIndex;
        if (index != minX)
        {
            index--;
            bool end = false;
            while (index >= minX)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.x = ChessManager.Chess.map[index].posX; vec.y = posY;
                    ChessManager.Chess.ShowPos(vec);
                    index--;
                }
                else if (!end && ChessManager.Chess.map[index].camp == "Black")
                {
                    end = true;
                    vec.x = ChessManager.Chess.map[index].posX; vec.y = posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                else
                    break;
            }
        }
        index = posIndex;
        if (index != maxY)
        {
            index += 8;
            bool end = false;
            while (index <= maxY)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                    index+=8;
                }
                else if (!end && ChessManager.Chess.map[index].camp == "Black")
                {
                    end = true;
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                }
                else
                    break;
            }
        }
        index = posIndex;
        if (index != minY)
        {
            index -= 8;
            bool end = false;
            while (index >= minY)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                    index-=8;
                }
                else if (!end && ChessManager.Chess.map[index].camp == "Black")
                {
                    end = true;
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                }
                else
                    break;
            }
        }
    }
    public void Check(int index)
    {

    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
