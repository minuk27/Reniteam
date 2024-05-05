using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    VoiceRange vRange;

    private float speed;
    private float jumpPower;
    private float posX;
    private float nowTime;
    private float delayTime;

    private bool isJump;
    private bool isTalk;
    private bool stop;
    private bool isQuest;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        vRange = GetComponentInChildren<VoiceRange>();

        speed = 10f;
        jumpPower = 8f;
        nowTime = 0f;
        delayTime = 0.5f;

        isJump = false;
        isTalk = false;
        stop = false;
        isQuest = false;
    }

    void Update()
    {
        Talk();
        if (stop)
            return;
        posX = Input.GetAxis("Horizontal");
        if (posX > 0 && sprite.flipX)
            sprite.flipX = !sprite.flipX;
        else if (posX < 0 && !sprite.flipX)
            sprite.flipX = !sprite.flipX;

        anim.SetBool("run", posX != 0);
    }

    void FixedUpdate()
    {
        if (stop)
            return;
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, sprite.flipX ? Vector3.left : Vector3.right, 2f, LayerMask.GetMask("Wall"));
        Debug.DrawRay(transform.position, sprite.flipX ? Vector3.left : Vector3.right, Color.red); //레이캐스트를 씬화면에서 체크하기 위한 코드
        if (hit)
        {
            speed = 0f;
            Debug.Log("실행");

        }*/
        rigid.velocity = new Vector2(posX * speed, rigid.velocity.y);

        if (Input.GetButton("Jump") && !isJump)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    public void Talk()
    {
        if (nowTime >= delayTime) {
            if (Input.GetKey(KeyCode.Z) && !isTalk)
            {
                int id = vRange.getnpcID(transform.position);
                if (id == 0)
                    return;
                nowTime = 0f;
                isTalk = true;                
                MoveStop();
                GameManager.Manager.GetUIManager.StartTalk(id);
            }
            else if (Input.GetKey(KeyCode.Z) && isTalk)
            {
                if (GameManager.Manager.GetUIManager.IsEndTalk())
                {
                    nowTime = 0f;
                    isTalk = false;
                    MoveStart();
                    GameManager.Manager.GetUIManager.EndTalk();
                }
            } 
        }
        else { 
            nowTime += Time.deltaTime; 
        }
    }

    public void Quest()
    {
        if (!isQuest)
            return;

    }

    public void MoveStop()
    {
        stop = true;
        speed = 0f;
        jumpPower = 0f;
        posX = 0f;
        rigid.velocity = Vector2.zero;
        if (anim.GetBool("run"))
            anim.SetBool("run", false);
    }

    public void MoveStart()
    {
        stop = false;
        speed = 10f;
        jumpPower = 8f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.S) && collision.gameObject.tag == "key")
        {
            //GameManager.Manager.GetSetEventManager.EventPost(EventType.KeyItemPickUp);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            isJump = false;
        }
    }
}