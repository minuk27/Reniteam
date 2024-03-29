using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour, SelectPieces
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
        transform.position = vec;
    }

    public void Select()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Vector3 vec;
        bool ok;
        for (int i = 0; i < 64; i++)
        {
            ok = false;
            vec = transform.position;
            if (ChessManager.Chess.map[i].posX == x - 1 && ChessManager.Chess.map[i].posY == y + 2 && (ChessManager.Chess.map[i].name == "None"|| ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x -= 1; vec.y += 2; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x + 1 && ChessManager.Chess.map[i].posY == y + 2 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x += 1; vec.y += 2; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x - 2 && ChessManager.Chess.map[i].posY == y + 1 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x -= 2; vec.y += 1; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x - 2 && ChessManager.Chess.map[i].posY == y - 1 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x -= 2; vec.y -= 1; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x + 2 && ChessManager.Chess.map[i].posY == y + 1 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x += 2; vec.y += 1; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x + 2 && ChessManager.Chess.map[i].posY == y - 1 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x += 2; vec.y -= 1; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x - 1 && ChessManager.Chess.map[i].posY == y - 2 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x -= 1; vec.y -= 2; ok = true;
            }
            else if (ChessManager.Chess.map[i].posX == x + 1 && ChessManager.Chess.map[i].posY == y - 2 && (ChessManager.Chess.map[i].name == "None" || ChessManager.Chess.map[i].camp == "Black"))
            {
                vec.x += 1; vec.y -= 2; ok = true;
            }
            if (ok)
            {
                ChessManager.Chess.ShowPos(vec);
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
