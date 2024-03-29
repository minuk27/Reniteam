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
            // 마우스 클릭 위치에서 레이 발사
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // 레이와의 충돌 검사
            if (hit.collider != null)
            {
                GameObject selectedObject = hit.collider.gameObject;
                if (selectedObject.tag == "chessPos") //좌표선택
                {
                    ChessManager.Chess.Move(this.gameObject.transform.position, selectedObject.transform.position, selectPiece);
                    ChessManager.Chess.HidePos();
                    ChessManager.Chess.Turn = 2;
                }
                else //체스기물 선택
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
