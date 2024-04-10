using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPawn : MonoBehaviour, SelectPieces
{
    [SerializeField]
    private int posIndex;
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
