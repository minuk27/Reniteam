using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Place p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.UpArrow) && collision.gameObject.tag == "Player")
        {
            player.SetActive(false);
            CamMove.camM.PlaceCam(Place.Voice);
            GameManager.Manager.GetUIManager.ActiveUI(UIs.VoiceWindow);
        }
    }

    public void onClick_VoiceExit()
    {
        player.SetActive(true);
        CamMove.camM.PlaceCam(p);
        GameManager.Manager.GetUIManager.InActiveUI(UIs.VoiceWindow);
    }
}
