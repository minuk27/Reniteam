using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalkRange
{
    public Transform player;
    public Vector2 center;
    public Vector2 size;
}

public class TalkCheck : MonoBehaviour
{
    [SerializeField]
    TalkRange check = new TalkRange();
    Vector2 target;
    float minX, maxX, minY, maxY;
    int id;
    bool questStart;
    bool isMove;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(check.center, check.size);
    }

    // Start is called before the first frame update
    void Start()
    {
        minX = check.center.x - check.size.x / 2;
        maxX = check.center.x + check.size.x / 2;
        minY = check.center.y - check.size.y / 2;
        maxY = check.center.y + check.size.y / 2;
        questStart = false;
        isMove = false;
        target.y = this.gameObject.transform.position.y;

        //id = gameObject.GetComponent<NPC>().GetID;
    }

    
    void Update()
    {
        if (check.player.position.x >= minX && check.player.position.x <= maxX && check.player.position.y >= minY && check.player.position.y <= maxY && !isMove)
        {
            target.x = gameObject.transform.position.x < check.player.position.x ? gameObject.transform.position.x - 5f : gameObject.transform.position.x + 5f;
            isMove = true;            
            GameManager.Manager.GetQuestManager.GetQuest(id);
        }

        if (isMove && gameObject.transform.position.x != target.x)
        {
            transform.position = Vector3.Lerp(transform.position, target, 5f * Time.deltaTime);
        }
        else
        {
            isMove = false;
            questStart = true;
            check.player.GetComponent<Player>().MoveStop();
            GameManager.Manager.GetUIManager.GetChatWindow.StartTalk(id, TalkForm.QuestTalk);
        }
    }


}
