using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Map
{
    public float posX;
    public float posY;
    public string name;
    public string camp;
}

public class ChessManager : MonoBehaviour
{
    private static ChessManager chess;
    public static ChessManager Chess
    {
        get
        {
            if (chess == null)
            {
                return null;
            }
            return chess;
        }
    }
    [SerializeField]
    private GameObject Pos;
    private List<GameObject> pos;

    public Map[] map;
    private int index;
    //최상단 좌측부터 (0,0)~최하단 우측까지(63, 1)
    //최상단 (0, 0)/(0, 1) ~ (7, 0)/(7, 1)
    //[n,0] = x좌표, [n,1] = y좌표

    private int victory; //0:게임 진행중, 1:이김, 2:짐
    private int turn; //1:플레이어차례, 2:상대차례
    private bool check;
    private bool checkmate;
    private List<Vector2> checkvec;

    private Dictionary<string, SelectPieces> pieces = new Dictionary<string, SelectPieces>();

    private void Awake()
    {
        checkvec = new List<Vector2>();
        chess = this;
        map = new Map[64];
        index = 0;
        for (int i = 0; i<8; i++)
        {
            map[index].posX = -3.5f;
            if (i == 0) { map[index].posY = 3.5f; }
            else { map[index].posY = map[index - 1].posY - 1.0f; }
            map[index].name = "None";
            index++;
            for(int j = 1; j<8; j++)
            {
                map[index].posX = map[index - 1].posX + 1.0f;
                map[index].posY = map[index-1].posY;
                map[index].name = "None";
                index++;
            }
        }
        pos = new List<GameObject>();
        for(int i = 0; i<28; i++)
        {
            GameObject p = Instantiate(Pos);
            p.SetActive(false);
            pos.Add(p);
        }

        victory = 0; turn = 1;
        check = false;
        checkmate = false;
    }

    public void AddPiesec(string name, SelectPieces pie, int index, string camp)
    {
        if (!pieces.ContainsKey(name))
        {
            pieces.Add(name, pie);
            map[index].name = name;
            map[index].camp = camp;
        }
    }

    public int Victory
    {
        get { return victory; }
        set { victory = value;  }
    }

    public int Turn
    {
        get { return turn; }
        set { turn = value; }
    }

    public bool Check
    {
        get { return check; }
        set { check = value; }
    }

    public Vector2 CheckVec
    {
        set { checkvec.Add(value); }
    }

    public void ResetCheckVec()
    {
        checkvec.Clear();
    }

    public List<Vector2> ReturnCheckVec()
    {
        return checkvec;
    }

    public bool Checkmate
    {
        get { return checkmate; }
        set { checkmate = value;}
    }

    public void Select(string name)
    {
        pieces[name].Select();
    }

    public void Move(Vector3 before, Vector3 after, string name)
    {
        int find = 0;
        int index = 0;
        for (int i = 0; i<64; i++)
        {
            if (map[i].name == name)
            {
                map[i].name = "None";
                find += 1;
            }
            else if (after.x == map[i].posX && after.y == map[i].posY)
            {
                if (map[i].name != "None")
                    pieces[map[i].name].Delete();
                map[i].name = name;
                find += 1;
                index = i;
            }
            if (find == 2)
                break;
        }
        pieces[name].Move(after, index);
    }

    public void ShowPos(Vector3 vec)
    {
        for(int i = 0; i<pos.Count; i++)
        {
            if (!pos[i].activeSelf)
            {
                pos[i].SetActive(true);
                pos[i].transform.position = vec;
                break;
            }
        }

    }

    public void HidePos()
    {
        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].activeSelf)
            {
                pos[i].SetActive(false);
            }
        }
    }
}
