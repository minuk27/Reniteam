using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("걷기 속도")]
    [SerializeField]
    public float speed = 10;
    [Header("점프력")]
    [SerializeField]
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    private bool isJump;
    private float posX;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJump = false;
    }

    void Update()
    {
        posX = Input.GetAxis("Horizontal");
        if (posX > 0 && sprite.flipX)
            sprite.flipX = !sprite.flipX;
        else if (posX < 0 && !sprite.flipX)
            sprite.flipX = !sprite.flipX;

        anim.SetBool("run", posX != 0);

        if (Input.GetKey(KeyCode.Z))
        {
            GetComponentInChildren<VoiceRange>().CheckVoiceRange();
        }
    }

    void FixedUpdate()
    {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.S) && collision.gameObject.tag == "key")
        {
            GameManager.Manager.GetSetEventManager.EventPost(EventType.KeyItemPickUp);
            Destroy(collision.gameObject);
        }
        if (Input.GetKey(KeyCode.UpArrow) && collision.gameObject.tag == "portal")
        {
            GameManager.Manager.GetSceneManager.ChangeSceneInGame(collision.gameObject.GetComponent<Portal>().Position);
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