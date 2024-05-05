using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    private bool isTeleprot;
    private float nowTime;
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        isTeleprot = true;
        delay = 0.5f;
        nowTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTeleprot)
            return;
        if (nowTime < delay)
        {
            nowTime += Time.deltaTime;
        }
        else
            isTeleprot = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.UpArrow) && collision.gameObject.tag == "portal" && isTeleprot)
        {
            nowTime = 0f;
            isTeleprot = false;
            CamMove.camM.PlaceCam(collision.gameObject.GetComponent<Portal>().GetPlace);
            this.gameObject.transform.position = collision.gameObject.GetComponent<Portal>().Position;
        }
    }
}
