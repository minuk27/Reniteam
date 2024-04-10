using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private string selectPiece;
    private bool select;
    private bool selectBefor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChessManager.Chess.Turn == 2 || ChessManager.Chess.Victory != 0)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��ġ���� ���� �߻�
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // ���̿��� �浹 �˻�
            if (hit.collider != null)
            {
                GameObject selectedObject = hit.collider.gameObject;
                if (selectedObject.tag == "chessPos") //��ǥ����
                {
                    ChessManager.Chess.Move(this.gameObject.transform.position, selectedObject.transform.position, selectPiece);
                    ChessManager.Chess.HidePos();
                    ChessManager.Chess.Turn = 2;
                }
                else //ü���⹰ ����
                {
                    if(selectPiece != null)
                    {
                        ChessManager.Chess.HidePos();
                    }
                    selectPiece = selectedObject.name;
                    ChessManager.Chess.Select(selectPiece);
                }
            }
        }
    }
}
