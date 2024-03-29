using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour, SelectPieces
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
            bool end = false;
            index++;
            while (index <= maxX)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.x = ChessManager.Chess.map[index].posX; vec.y = posY;
                    ChessManager.Chess.ShowPos(vec);
                    index++;
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
        if (index != minX)
        {
            bool end = false;
            index--;
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
            bool end = false;
            index += 8;
            while (index <= maxY)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                    index += 8;
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
            bool end = false;
            index -= 8;
            while (index >= minY)
            {
                if (ChessManager.Chess.map[index].name == "None")
                {
                    vec.y = ChessManager.Chess.map[index].posY; vec.x = posX;
                    ChessManager.Chess.ShowPos(vec);
                    index -= 8;
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
        while (index - 9 >= 0)
        {
            if (index % 8 == 0 || ChessManager.Chess.map[index - 9].name != "None")
            {
                if (index % 8 != 0 && ChessManager.Chess.map[index - 9].camp == "Black")
                {
                    vec.x = ChessManager.Chess.map[index - 9].posX; vec.y = ChessManager.Chess.map[index - 9].posY;
                    ChessManager.Chess.ShowPos(vec);
                }
                break;
            }
            index -= 9;
            vec.x = ChessManager.Chess.map[index].posX; vec.y = ChessManager.Chess.map[index].posY;
            ChessManager.Chess.ShowPos(vec);
        }
        index = posIndex;
        while (index - 7 >= 1)
        {
            if ((index + 1) % 8 == 0 || ChessManager.Chess.map[index - 7].name != "None")
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
        while (index + 7 <= 62)
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
        while (index + 9 <= 63)
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
