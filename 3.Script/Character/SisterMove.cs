using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterMove : MonoBehaviour
{
    BoxCollider2D coll;
    [SerializeField] RunStory runStory;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] float speed;
    bool isColliding;
    bool run;
    bool notMove;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        anim.enabled = false;
        isColliding = false;
        run = false;
        notMove = false;
    }

    private void Update()
    {
        if (run)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        if (notMove || run)
            return;

        if (isColliding)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            gameObject.SetActive(false);
        if (run)
            return;
        if (collision.gameObject.tag == "SisterRange")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (run)
            return;
        if (collision.gameObject.tag == "SisterRange")
        {
            isColliding = false;
        }
    }

    public void startRun()
    {
        notMove = true;
        rend.flipX = false;
        coll.isTrigger = true;
        runStory.setGameOver();
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return null;
        anim.enabled = true;
        yield return new WaitForSeconds(0.8f);
        anim.enabled = false;
        yield return null;
        yield return null;
        notMove = false;
        run = true;
        isColliding = false;
        speed *= 2f;
    }
}
