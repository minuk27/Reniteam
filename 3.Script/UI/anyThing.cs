using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anyThing : MonoBehaviour
{
    [SerializeField] UIScenesManager scenesManger;
    void Update() 
    {
        if (Input.anyKeyDown) 
        {
            scenesManger.changeScenes(ScenesName.Voice);
        }
    }
}
