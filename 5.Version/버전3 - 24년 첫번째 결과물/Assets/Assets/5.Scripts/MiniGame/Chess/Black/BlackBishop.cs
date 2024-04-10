using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBishop : MonoBehaviour, SelectPieces
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

    public void Check(int index)
    {
        throw new System.NotImplementedException();
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void Move(Vector2 vec, int index)
    {
        throw new System.NotImplementedException();
    }

    public void Select()
    {
        throw new System.NotImplementedException();
    }
}
