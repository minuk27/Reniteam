using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anyThing : MonoBehaviour
{
    void Start() 
    {
    
    }

    void Update() 
    {
        if (Input.anyKeyDown) 
        {
            GameManager.Manager.SceneTrans = GameManager.Scene.TutorialVoice;
        }
    }
}
