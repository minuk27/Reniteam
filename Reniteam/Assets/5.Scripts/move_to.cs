using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_to : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed = 10;
    [SerializeField]
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    [SerializeField]
    private bool isJump;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isJump = false;
    }

    void FixedUpdate()
    {
        //Á¡ÇÁ(³»²¨´Â ÀÛµ¿¾ÈµÊ)
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        //¸ØÃçÁö´Â ¼Óµµ
        /*if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //¹æÇâÀüÈ¯(³»²¨´Â ÀÛµ¿¾ÈµÊ)
        if (Input.GetButtonDown("Horizontal"))
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * maxSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0 && sprite.flipX)
            sprite.flipX = !sprite.flipX;
        else if (Input.GetAxis("Horizontal") < 0 && !sprite.flipX)
            sprite.flipX = !sprite.flipX;
        anim.SetBool("run", Input.GetAxis("Horizontal") != 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "key")
        {
            GameManager.Manager.eventManager.EventPost(EventType.KeyItemPickUp);
            Destroy(collision.gameObject);
            Debug.Log("¾ÆÀÌÅÛ ¸Ô±â");
        }
        if (Input.GetKey(KeyCode.UpArrow) && collision.gameObject.tag == "portal")
        {
            GameManager.Manager.SceneTrans = GameManager.Scene.Test;
            Debug.Log("½ÇÇà");
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